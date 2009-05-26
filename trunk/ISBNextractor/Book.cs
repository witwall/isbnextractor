using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Text;
using System.Windows.Forms;
using System.Collections;
using System.IO;
using System.Runtime.InteropServices;
using System.Data.Odbc;
using System.Threading;
using System.Xml;
using System.Drawing;
using System.Net;

namespace ISBNextractor
{

    public class ResultISBN
    {
        string result;

        public string Result
        {
            get { return result; }
            set { result = value; }
        }
        string isbn ;

        public string Isbn
        {
            get { return isbn; }
            set { isbn = value; }
        }

        public ResultISBN(string i, string r)
        {
            isbn = i;
            result = r;
        }
    }

    [Serializable]
    public class SimpleBook
    {
        private string path = "";
        private string name="";
        private string isbn = "";
        private string naslov = "";
        private string podnaslov = "";
        private string jezik = "";
        private string izdavac = "";
        private string abstrakt = "";
        private string stranica = "";
        private string izdanje = "";
        private int ImageIndex;
        private Image slika;
        ArrayList autori;
        ArrayList tags;

        public SimpleBook(Book b)
        {
            path = b.Path;
            name = b.Name;
            isbn = b.Isbn;
            naslov = b.Naslov;
            podnaslov = b.Podnaslov;
            jezik = b.Jezik;
            izdavac = b.Izdavac;
            abstrakt = b.Abstrakt;
            stranica = b.Stranica;
            izdanje = b.Izdanje;
            autori = b.Autori;
            tags = b.Tags;
            slika = b.Slika;
            ImageIndex = b.ImageIndex;
        }

        public Book LoadData()
        {
            Book b = new Book(path,name);
            b.Naslov = naslov;
            b.Podnaslov = podnaslov;
            b.Isbn = isbn;
            b.Jezik = jezik;
            b.Izdavac = izdavac;
            b.Abstrakt = abstrakt;
            b.Stranica = stranica;
            b.Izdanje = izdanje;
            b.Autori = autori;
            b.Tags = tags;
            b.Slika = slika;
            b.ImageIndex = ImageIndex;

            return b;
        }
    }



    public class Book : ListViewItem
    {
        [DllImport("kernel32")]
        private static extern int GetPrivateProfileString(string section, string key, string def, StringBuilder retVal, int size, string filePath);

        private string path = "", isbn="", naslov = "", podnaslov = "", jezik = "", izdavac = "", abstrakt = "", stranica = "", izdanje = "", authors = "";
        ArrayList autori = new ArrayList();
        ArrayList tags = new ArrayList();
        private string name;
        Image slika = Image.FromFile(Application.StartupPath + "\\noImage.png");

        //protected Book(SerializationInfo info, StreamingContext context) : base(info, context) { }
        public string Izdanje
        {
            get { return izdanje; }
            set { izdanje = value; }
        }

        public string Stranica
        {
            get { return stranica; }
            set { stranica = value; }
        }

        public string Abstrakt
        {
            get { return abstrakt; }
            set { abstrakt = value; }
        }

        public string Izdavac
        {
            get { return izdavac; }
            set { izdavac = value; }
        }


        public ArrayList Tags
        {
            get { return tags; }
            set { tags = value; }
        }

        public ArrayList Autori
        {
            get { return autori; }
            set { autori = value; }
        }

        public string Jezik
        {
            get { return jezik; }
            set { jezik = value; }
        }

        public string Podnaslov
        {
            get { return podnaslov; }
            set { podnaslov = value; }
        }

        public string Naslov
        {
            get { return naslov; }
            set { naslov = value; }
        }

        public string Isbn
        {
            get { return isbn; }
            set { isbn = value; }
        }


        public System.Drawing.Image Slika
        {
            get { return slika; }
            set { slika = value; }
        }

        public string Path
        {
            get { return path; }
            set { path = value; }
        }


        public string Name
        {
            get { return name; }
            set { name = value; }
        }

        public Book(string p, string n)
        {
            path = p;
            name = n;
            Text = n;
            this.ImageIndex = 0;
        }

        public override string ToString()
        {
            return name;
        }

        public bool Save()
        {
            if (isbn == "" || isbn == null)
            {
                EnterISBN ei = new EnterISBN(path.Split('\\')[path.Split('\\').Length - 1]);
                ei.ShowDialog();
                isbn = ei.Isbn;
            }

            // save image to bit array
            byte[] slikica = null;
            try
            {
                using (MemoryStream ms = new MemoryStream())
                {
                    slika.Save(ms, System.Drawing.Imaging.ImageFormat.Png);
                    slikica = ms.ToArray();
                }
            }
            catch (Exception e) { MessageBox.Show("Cant find book picture: "+e.Message); }

            // prepare authors for database
            foreach (string author in Autori)
                authors += author + ";";

            StringBuilder temp = new StringBuilder(255);
            StringBuilder isscp = new StringBuilder(255);
            String repoPath;

            int x = GetPrivateProfileString("eBook", "isscp", "", isscp, 1024, Application.StartupPath + "\\settings.ini");
            x = GetPrivateProfileString("eBook", "Repozitorij", "", temp, 1024, Application.StartupPath + "\\settings.ini");
            repoPath = temp.ToString();

            // if we don't use local repository or SMB create an temp ebook
            if (isscp.ToString() == "True") repoPath = Application.StartupPath; else repoPath = temp.ToString();
            repoPath += "\\" + isbn + ".ebook.zip";


            CreateUeBF(repoPath);

            createBook(slikica, authors, true);

            if (isscp.ToString() == "True") SendViaSCP(isbn, repoPath);

            return true;



 

        //    eLibrary.ZilverLine.IndexService InSe = new eLibrary.ZilverLine.IndexService();
        //    InSe.indexAsync();
        }

        private void SendViaSCP(string isbn, string repoPath)
        {
            StringBuilder temp = new StringBuilder(255);
            // copy the book from temp over SCP to the repository
                if (File.Exists(repoPath))
                {
                    int x = GetPrivateProfileString("eBook", "host", "", temp, 1024, Application.StartupPath + "\\settings.ini");
                    String Host = temp.ToString();
                    x = GetPrivateProfileString("eBook", "user", "", temp, 1024, Application.StartupPath + "\\settings.ini");
                    String Username = temp.ToString();
                    x = GetPrivateProfileString("eBook", "pass", "", temp, 1024, Application.StartupPath + "\\settings.ini");
                    String Password = temp.ToString();

                    Tamir.SharpSsh.Scp scpSession = new Tamir.SharpSsh.Scp(Host, Username, Password);

                    x = GetPrivateProfileString("eBook", "remotePath", "", temp, 1024, Application.StartupPath + "\\settings.ini");
                    scpSession.Connect();

                    if (scpSession.Connected) scpSession.To(repoPath, temp.ToString() + "/" + isbn + ".ebook.zip");
                    else MessageBox.Show("Could not send file over SCP !!");
                }
                else MessageBox.Show("Error: UEBF generator doesn't work");
        }


        public void GetDataFromAmazon()
        {
            try
            {
                int x = 0;
                string upit = "http://webservices.amazon.com/onca/xml?Service=AWSECommerceService&SubscriptionId=0GXDV2YTQ8ZD4JSG0DG2&Operation=ItemSearch&SearchIndex=Books&Keywords=" + isbn + "&ResponseGroup=ItemAttributes,EditorialReview,Images";
                XmlTextReader citac = new XmlTextReader(upit);
                while (citac.Read())
                {
                    if (citac.NodeType == XmlNodeType.Element)
                        switch (citac.Name)
                        {

                            case "Title":
                                x = 2; break;
                            case "Author":
                                x = 3; break;
                            case "PublicationDate":
                                x = 4; break;
                            case "Publisher":
                                x = 5; break;
                            case "URL": //image
                                x = 6; break;
                            case "Content":
                                x = 7; break;
                            case "Manufacturer":
                                x = 8; break;
                            case "Height":
                                x = 9; break;
                            case "Width":
                                x = 10; break;
                            case "NumberOfPages":
                                x = 11; break;
                            case "Edition":
                                x = 12; break;

                        }
                    if (citac.NodeType == XmlNodeType.Text)
                        switch (x)
                        {
                            case 2:
                                string[] a = citac.Value.Split(':');
                                naslov = a[0];
                                podnaslov = a[1].Trim();
                                x = 0; break;
                            case 3:
                                autori.Add(citac.Value);
                                x = 0; break;
                            case 4:
                                x = 0; break;
                            case 5:
                                izdavac = citac.Value;
                                x = 0; break;
                            case 6:
                                Bitmap b = new Bitmap(WebRequest.Create(citac.Value).GetResponse().GetResponseStream());
                                slika = (System.Drawing.Image)Main.Smanji(b, 143, 169);
                                x = 0; break;
                            case 7:
                                abstrakt += citac.Value + Environment.NewLine;
                                x = 0; break;
                            case 8:
                                //propPrintingHouse.Text = citac.Value;
                                x = 0; break;
                            case 9:
                                //propX.Text += citac.Value;
                                x = 0; break;
                            case 10:
                                //propY.Text += citac.Value;
                                x = 0; break;
                            case 11:
                                stranica = citac.Value;
                                x = 0; break;
                            case 12:
                                izdanje = citac.Value;
                                x = 0; break;
                        }
                }
            }
            catch (Exception exe) { Console.WriteLine(exe.Message); }
        }

        private void createBook(byte[] slikica, string authors, bool p)
        {
            string sUpit = "insert into katalog (naslov,podnaslov,isbn,izdavac,fk_jezik,broj_stranica,izdanje,autori,slika,sadrzaj)" +
            "values ('"
            + naslov.Replace('\'', '`') + "','"
            + podnaslov.Replace('\'', '`') + "','"
            + isbn.Replace('\'', '`') + "',"
            + "(select id from izdavaci where naziv='" + izdavac.Replace('\'', '`') + "' limit 0,1)" + ","
            + "(select id from jezik where naziv='" + jezik.Replace('\'', '`') + "' limit 0,1)" + ",'"
            + stranica.Replace('\'', '`') + "','"
            + "ebook" + "','"
            + authors.Replace('\'', '`') + "',?,'"
            + abstrakt.Replace('\'', '`') + "')";
            OdbcCommand upit = new OdbcCommand(sUpit, Main.ConObj);
            OdbcParameterCollection parameters = upit.Parameters;
            parameters.Add("slika", OdbcType.Image);
            parameters["slika"].Value = slikica;
            upit.ExecuteNonQuery();

            // Get free ID
            upit = new OdbcCommand("select max(id) from katalog", Main.ConObj);
            OdbcDataReader citac = upit.ExecuteReader();
            citac.Read();
            string id = citac[0].ToString();

            // Adding tags
            for (int i = 0; i < tags.Count; i++)
            {
                sUpit = "insert into zanr_katalog (fk_knjiga,fk_zanr) values (" + id + ",(select id from zanrovi where naziv='" + tags[i] + "' limit 0,1))";
                upit = new OdbcCommand(sUpit, Main.ConObj);
                upit.ExecuteNonQuery();
            }
        }

        private void CreateUeBF(string putanjaDoKnjige)
        {
            java.io.FileOutputStream fos = new java.io.FileOutputStream(putanjaDoKnjige);
            java.util.zip.ZipOutputStream zos = new java.util.zip.ZipOutputStream(fos);


            string[] priv = path.Substring(3).Replace('\\', '/').Split('/');
            AddToZip(fos, zos, path, priv[priv.Length - 1]);


            saveMeta(fos, zos);

       /*     if (path.Contains("pdf"))
            {
                CreateSWF(path);
                string swfPath = Application.StartupPath + "\\" + isbn + ".swf";
                while (!File.Exists(swfPath)) { Thread.Sleep(2000); };
                AddToZip(fos, zos, swfPath, isbn + ".swf");
                System.IO.File.Delete(swfPath);
            } */

            zos.close();
            fos.close();
        }

        private void CreateSWF(string path)
        {
                StringBuilder temp = new StringBuilder(255);
                int x = GetPrivateProfileString("eBook", "FlashPrinter", "", temp, 1024, Application.StartupPath + "\\settings.ini");
                if (temp.ToString() != "") 
                   System.Diagnostics.Process.Start(temp.ToString(), "\"" + path + "\" -o " + "\"" + Application.StartupPath + "\\"+isbn + ".swf\"");
        }

        private void CreateHTML(string path)
        {
            StringBuilder temp = new StringBuilder(255);
            int x = GetPrivateProfileString("eBook", "ChmDecoder", "", temp, 1024, Application.StartupPath + "\\settings.ini");
            string dir = " \"" + Application.StartupPath + "\\"+isbn + "\"";
            if (temp.ToString() != "")
                System.Diagnostics.Process.Start(temp.ToString(), "\"" + path + "\"" + dir);
        }

        private void saveStreamToZip(string name, System.IO.Stream data, java.util.zip.ZipOutputStream zos)
        {
            java.util.zip.ZipEntry ze = new java.util.zip.ZipEntry(name);
            zos.putNextEntry(ze);

            byte[] buffer = new byte[1024];
            int ReadBytes;
            while ((ReadBytes = data.Read(buffer, 0, 1024)) > 0)
                try
                {
                    byte[] b2 = new byte[ReadBytes];
                    for (int i = 0; i < ReadBytes; i++) b2[i] = (byte)buffer[i];
                    zos.write(b2, 0, ReadBytes);
                }
                catch (System.IO.IOException e) {
                    File.AppendAllText("log_SAve.txt", DateTime.Now.ToShortDateString() + " " + DateTime.Now.ToShortTimeString() + ": " + name + Environment.NewLine);
                    break; 
                }

            zos.closeEntry();
        }

        private void saveMeta(java.io.FileOutputStream fos, java.util.zip.ZipOutputStream zos)
        {
            System.Net.WebClient wc = new System.Net.WebClient();
            wc.Headers.Add("user-agent", "Mozilla/4.0 (compatible; MSIE 6.0; Windows NT 5.2; .NET CLR 1.0.3705;)");
            System.IO.Stream data;

            // dublin core meta data from library of congress
            try
            {
                data = wc.OpenRead("http://z3950.loc.gov:7090/voyager?version=1.1&operation=searchRetrieve&query=" + isbn + "&maximumRecords=1&recordSchema=dc");
                saveStreamToZip("meta" + System.IO.Path.DirectorySeparatorChar + "dublin.dc", data, zos);
                data.Close();
            }
            catch (Exception e)
            {
                //MessageBox.Show("Ne mogu da nadjem dublin core podatke na library of congress (internet pristup?)");
            }

            try
            {
                // MarcXML meta data from library of congress
                data = wc.OpenRead("http://z3950.loc.gov:7090/voyager?version=1.1&operation=searchRetrieve&query=" + isbn + "&maximumRecords=1&recordSchema=marcxml");
                saveStreamToZip("meta" + System.IO.Path.DirectorySeparatorChar + "marc.xml", data, zos);
                data.Close();
            }
            catch (Exception e)
            {
                //MessageBox.Show("Ne mogu da nadjem MARCXML podatke na library of congress (internet pristup?)");
            }

            // XML from amazon
            try
            {
                data = wc.OpenRead("http://webservices.amazon.com/onca/xml?Service=AWSECommerceService&SubscriptionId=0GXDV2YTQ8ZD4JSG0DG2&Operation=ItemSearch&SearchIndex=Books&Keywords=" + isbn + "&ResponseGroup=ItemAttributes,EditorialReview,Images");
                saveStreamToZip("custom" + System.IO.Path.DirectorySeparatorChar + "amazon.xml", data, zos);
                data.Close();
            }
            catch (Exception e)
            {
                // MessageBox.Show("Problem sa preuzimanjem Meta podataka sa Amazona (internet konekcija?)\n");
            }

            // Add Cover image
            slika.Save("cover.jpg", System.Drawing.Imaging.ImageFormat.Jpeg);
            AddToZip(fos, zos, "cover.jpg", "meta" + System.IO.Path.DirectorySeparatorChar + "cover.jpg");
            // data.Close();
            File.Delete("cover.jpg");

            // save as plain
            string plainMeta = 
                   "<book>"+
                      "<title>" + naslov + 
                      "</title> <subtitle>" 
                      + podnaslov + 
                      "</subtitle> <publisher>"
                      + izdavac +
                      "</publisher> <author>"
                      + authors + 
                      "</author> <edition>"
                      + izdanje +
                      "</edition> <numberOfPages>"
                      + stranica +
                      "</numberOfPages>" +
                    "</book>";
             System.IO.StreamWriter sw = new System.IO.StreamWriter("plain.xml");
             sw.Write(plainMeta);
             sw.Close();
             AddToZip(fos, zos, "plain.xml", "custom" + System.IO.Path.DirectorySeparatorChar + "plain.xml"); 
        }

        private bool AddToZip(java.io.FileOutputStream fos, java.util.zip.ZipOutputStream zos, string sourceFile, string destName)
        {
            try
            {
  
                Thread.Sleep(6000);
                java.io.FileInputStream fis = new java.io.FileInputStream(sourceFile);
                java.util.zip.ZipEntry ze = new java.util.zip.ZipEntry(destName);
                zos.putNextEntry(ze);

                byte[] buffer = new byte[1024];
                int len;
                while ((len = fis.read(buffer)) >= 0)
                {
                    zos.write(buffer, 0, len);
                }
                zos.closeEntry();
                fis.close();
            }
            catch (Exception)
            {
                File.AppendAllText("log_save.txt", DateTime.Now.ToShortDateString() + " " + DateTime.Now.ToShortTimeString() + ": " + sourceFile + Environment.NewLine);
                AddToZip( fos,  zos,  sourceFile,  destName);
            }

            return true;
        }
    }
}
