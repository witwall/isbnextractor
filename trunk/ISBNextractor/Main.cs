using System;
using System.Drawing;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Windows.Forms;
using System.Threading;
using System.IO;

using System.Xml;
using System.Net;
using org.pdfbox.pdmodel;
using org.pdfbox.util;
using System.Diagnostics;
using System.Data.Odbc;
using System.Runtime.InteropServices;
using System.Collections;


namespace ISBNextractor
{
    public partial class Main : Form
    {

        [DllImport("kernel32")]
        private static extern int GetPrivateProfileString(string section, string key, string def, StringBuilder retVal, int size, string filePath);

        private CheckedListBox TagList;
        private OdbcCommand upit;
        private OdbcDataReader citac;
        public static OdbcConnection ConObj;


        public Main()
        {
            InitializeComponent();
        }

        private void AddBookToList_Click(object sender, EventArgs e)
        {
            System.Windows.Forms.OpenFileDialog ofd = new System.Windows.Forms.OpenFileDialog();
            ofd.Multiselect = true;

            ofd.Filter = "eBooks (*.pdf, *.chm)|*.pdf*;*.chm|All Files|*.*";

            if (ofd.ShowDialog() == DialogResult.OK)
            {                
                string[] filePath = ofd.FileNames;
                string[] safeFilePath = ofd.SafeFileNames;
                for (int i = 0; i < filePath.Length; i++)
                    booklist.Items.Add(new Book(filePath[i],safeFilePath[i]));
            }
            done = true;
            procId = 0;
        }

        private void Add_Click(object sender, EventArgs e)
        {
            booklist.SelectedItems[0].Remove();
        }

        private void toolStripButton3_Click(object sender, EventArgs e)
        {
            MessageBox.Show("@2009 Teo Eterovic");
        }

        static bool done = true;
        private int procId;

        private void StartProcessing_Click(object sender, EventArgs e)
        {
            foreach (Book item in booklist.Items)
                item.ImageIndex = 1;

            procId = 0;
            isDone.Start();

       //     for (int i = 0; i < booklist.Items.Count; i++)
		//	{
         //     booklist.Items[i].ImageIndex = 2;

        //      ProcessBook(booklist.Items[i]);


          //  } 
        }

        public void ChangeStatus(int indeks, int broj)
        {
            this.Invoke((MethodInvoker)delegate
            {

            this.booklist.Items[indeks].ImageIndex = broj;
            });

        }

        public static void Log(string Message)
        {
            File.AppendAllText("log.txt", DateTime.Now.ToShortDateString() + " " + DateTime.Now.ToShortTimeString() + ": " + Message + Environment.NewLine);
        }


        private void ProcessBook(object state)
        {
            object[] s = (object[])state;
            
            Book currbook = s[0] as Book;
           
         //   Book currbook = (Book)state;
         //   int br = currbook.Index;
            int br = (int)s[1];
           ResultISBN isbn = GetDocumentISBN(currbook.Path);

            if (isbn.Isbn == "nomatch")
                {
                    ChangeStatus(br, 6); 
                    isbn.Isbn = AssistenceIsNeeded(isbn.Result);
                    done = true;
                    return;
                }
            if (isbn.Isbn == null)
            { ChangeStatus(br, 5); done = true; return; }

            currbook.Isbn = isbn.Isbn;
            currbook.Jezik = "English";

            currbook.GetDataFromAmazon();

            ChangeStatus(br, 3);
            done = true;
        }



        private ResultISBN parseISBNwithPDFBox(string filename)
        {
            try
            {
                PDDocument doc = PDDocument.load(filename);
                PDFTextStripper stripper = new PDFTextStripper();

                // Split the search into parts (no need to search 10 pages
                // if the result is on the thrid

                stripper.setStartPage(0);
                stripper.setEndPage(3);
                string rezultat = stripper.getText(doc);
                string isbn = (new ISBN()).getISBNFromContent(rezultat);
                if (isbn != null) return (new ResultISBN(isbn, rezultat));


                stripper = new PDFTextStripper();
                stripper.setStartPage(3);
                stripper.setEndPage(7);
                rezultat = stripper.getText(doc);
                isbn = (new ISBN()).getISBNFromContent(rezultat);
                if (isbn != null) return (new ResultISBN(isbn, rezultat));


                stripper = new PDFTextStripper();
                stripper.setStartPage(7);
                stripper.setEndPage(10);
                rezultat = stripper.getText(doc);
                isbn = (new ISBN()).getISBNFromContent(rezultat);

                if (isbn != null) return (new ResultISBN(isbn, rezultat));

                return (new ResultISBN(null, null));
            }
            catch (Exception e) 
            {
              //  MessageBox.Show(e.Message);
                File.AppendAllText("log_Parser.txt", DateTime.Now.ToShortDateString() + " " + DateTime.Now.ToShortTimeString() + ": " + e.Message+" "+filename + Environment.NewLine);
                return (new ResultISBN(null, null));
            }
        }

        private ResultISBN GetDocumentISBN(string path)
        {
            string pth = Path.GetExtension(path);
            switch (pth)
            {
                case ".PDF":
                case ".pdf":
                    return parseISBNwithPDFBox(path);
                case ".CHM":
                case ".chm":
                    return (new CHMParser()).ExtractISBN(path);
                default:
                    return (new ResultISBN(null,null));
            }

            
        }

        private string AssistenceIsNeeded(string input)
        {
          //  MessageBox.Show("Assistence");
            return "";
        }

  #region Amazon
        private void GetDataFromAmazon(string isbn)
        {
            propAuthors.Text = "";
            try
            {
                int x;
                x = 0;
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
                                propTitle.Text = a[0];
                                propTitle2.Text = a[1].Trim();
                                x = 0; break;
                            case 3:
                                propAuthors.Text += ((propAuthors.TextLength == 0) ? "" : ",") + citac.Value;
                                x = 0; break;
                            case 4:
                                x = 0; break;
                            case 5:
                                propPublisher.Text = citac.Value;
                                x = 0; break;
                            case 6:
                                Bitmap b = new Bitmap(WebRequest.Create(citac.Value).GetResponse().GetResponseStream());
                                slika.Image = (System.Drawing.Image)Smanji(b, 143, 169);
                                x = 0; break;
                            case 7:
                                propAbstract.Text += citac.Value + Environment.NewLine;
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
                                propPages.Text = citac.Value;
                                x = 0; break;
                            case 12:
                                propRelease.Text = citac.Value;
                                x = 0; break;
                        }
                }
            }
            catch (Exception exe) { Console.WriteLine(exe.Message); }
        }


        public static Bitmap Smanji(Bitmap b, int nWidth, int nHeight)
        {
            Bitmap result = new Bitmap(nWidth, nHeight);
            using (Graphics g = Graphics.FromImage((System.Drawing.Image)result))
                g.DrawImage(b, 0, 0, nWidth, nHeight);
            return result;
        }
#endregion

        private void Form1_Load(object sender, EventArgs e)
        {
            TagList = new CheckedListBox();

            CreateConnection();

            LoadTags();

            LoadPublishers();
            LoadLanguages();
            
        }

        private void CreateConnection()
        {
            String path = Application.StartupPath + "\\settings.ini";
            StringBuilder temp = new StringBuilder(255);

            int i = GetPrivateProfileString("Opcije", "Server", "", temp, 1024, path);
            string server = temp.ToString();
            i = GetPrivateProfileString("Opcije", "DBN", "", temp, 1024, path);
            string dbn = temp.ToString();
            i = GetPrivateProfileString("Opcije", "Username", "", temp, 1024, path);
            string userN = temp.ToString();
            i = GetPrivateProfileString("Opcije", "Password", "", temp, 1024, path);
            string passW = temp.ToString();

            string cStr = "DRIVER={MySQL ODBC 5.1 Driver};" +
            "SERVER=" + server + ";" +
            "DATABASE=" + dbn + ";" +
            "UID=" + userN + ";" +
            "PWD=" + passW + ";" +
            "OPTION=3";
            ConObj = new OdbcConnection(cStr);

            try
            {
                ConObj.Open();
                statusInfo.Text = "Connected to database";
            }
            catch (Exception ex) { MessageBox.Show(ex.Message); statusInfo.Text = "Couldn't connect to database"; }
        }

        private void LoadPublishers()
        {
            upit = new OdbcCommand("select naziv from izdavaci", ConObj);
            try
            {
                citac = upit.ExecuteReader();
                while (citac.Read())
                    propPublisher.Items.Add(citac[0].ToString());
            }
            catch (Exception ex) { MessageBox.Show("greska: " + ex); }
        }

        private void LoadLanguages()
        {
            upit = new OdbcCommand("select naziv from jezik", ConObj);
            try
            {
                citac = upit.ExecuteReader();
                while (citac.Read())
                    propLanguage.Items.Add(citac[0].ToString());
                propLanguage.SelectedIndex = 1;
            }
            catch (Exception ex) { MessageBox.Show("greska: " + ex); }
        }

        private void LoadTags()
        {
            upit = new OdbcCommand("select naziv from zanrovi", ConObj);
            try
            {
                citac = upit.ExecuteReader();
                while (citac.Read())
                {
                    TagList.Items.Add(citac[0].ToString());
                    zarn.Items.Add(citac[0].ToString());
                }
            }
            catch (Exception ex) { MessageBox.Show("Error: " + ex.Message); }
        }


        private void Tag_TextChanged(object sender, EventArgs e)
        {
            zarn.Items.Clear();
            for (int i = 0; i < TagList.Items.Count; i++)
            {
                if (TagList.Items[i].ToString().ToLower().Contains(dodZarn.Text.ToLower()))
                    zarn.Items.Add(TagList.Items[i], TagList.GetItemCheckState(i));

            } 
        }

        private void InsertTag_Click(object sender, EventArgs e)
        {
            upit = new OdbcCommand("insert into zanrovi (naziv) values ('" + dodZarn.Text.Replace('\'', '`') + "')", ConObj);
            upit.ExecuteNonQuery();
           // zarn.Items.Add(dodZarn.Text);
            TagList.Items.Add(dodZarn.Text.Replace('\'', '`'), true);
            dodZarn.Text = ""; 
        }

        private void booklist_ItemActivate(object sender, EventArgs e)
        {
            Book currbook = (Book)((ListView)sender).SelectedItems[0];
            selectedBook = currbook;
   
            rightPanel.SelectTab("Book");

            propISBN.Text = currbook.Isbn;
            propLanguage.Text = currbook.Jezik;
            propPages.Text = currbook.Stranica;
            propPublisher.Text = currbook.Izdavac;
            propRelease.Text = currbook.Izdanje;
            propTitle.Text = currbook.Naslov;
            propTitle2.Text = currbook.Podnaslov;
            propAbstract.Text = currbook.Abstrakt;
            slika.Image = currbook.Slika;
            propAuthors.Text = "";
            foreach (string author in currbook.Autori)
                    propAuthors.Text += ((propAuthors.TextLength == 0) ? "" : ",") + author;

            foreach (string tag in currbook.Tags)
            {
                zarn.SetItemCheckState(zarn.Items.IndexOf(tag), CheckState.Checked);
                TagList.SetItemCheckState(zarn.Items.IndexOf(tag), CheckState.Checked);
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            GetDataFromAmazon(propISBN.Text);
            SaveBookChanges_Click(sender, e);
        }

        private void button5_Click(object sender, EventArgs e)
        {
            OpenFileDialog otvoriSliku = new OpenFileDialog();
            if (otvoriSliku.ShowDialog() == DialogResult.OK)
            {
                slika.Image = (Image)Smanji((new Bitmap(otvoriSliku.FileName)), 143, 169);
            }
        }

        private void fromClipboard_Click(object sender, EventArgs e)
        {
            if (Clipboard.ContainsImage())
                slika.Image = (Image)Smanji((Bitmap)Clipboard.GetImage(), 143, 169);
            else
                MessageBox.Show("Clipboard ne sadrzi sliku!"); 
        }

        private void OpenBook_Click(object sender, EventArgs e)
        {
            try
            {
                Process.Start(((Book)booklist.SelectedItems[0]).Path);
            }
            catch (Exception ea)
            {
                MessageBox.Show(ea.Message);
            }
            
        }

        private void zarn_ItemCheck(object sender, ItemCheckEventArgs e)
        {
            for (int i = 0; i < TagList.Items.Count; i++)
                if (TagList.Items[i].ToString() == zarn.Items[e.Index].ToString())
                    TagList.SetItemCheckState(i, e.NewValue);
        }

        private void addPublisher_Click(object sender, EventArgs e)
        {
            upit = new OdbcCommand("insert into izdavaci (naziv) values ('" + propPublisher.Text.Replace('\'', '`') + "')", ConObj);
            upit.ExecuteNonQuery();
            propPublisher.Items.Add(propPublisher.Text);
        }

        private void addLanguage_Click(object sender, EventArgs e)
        {
            upit = new OdbcCommand("insert into jezik (naziv) values ('" + propLanguage.Text.Replace('\'', '`') + "')", ConObj);
            upit.ExecuteNonQuery();
            propLanguage.Items.Add(propLanguage.Text);
        }

        private Book selectedBook;

        private void SaveBookChanges_Click(object sender, EventArgs e)
        {
            Book currbook = selectedBook;

            if (currbook == null) currbook = new Book("","");

            currbook.Isbn = propISBN.Text;
            currbook.Jezik = propLanguage.Text;
            currbook.Stranica = propPages.Text;
            currbook.Izdavac = propPublisher.Text;
            currbook.Izdanje = propRelease.Text;
            currbook.Naslov = propTitle.Text;
            currbook.Podnaslov = propTitle2.Text;
            currbook.Abstrakt = propAbstract.Text;
            currbook.Slika = slika.Image;

            foreach (string author in propAuthors.Text.Split(','))
            {
                if (!currbook.Autori.Contains(author))
                    currbook.Autori.Add(author);
            }

            for (int i = 0; i < zarn.CheckedItems.Count; i++)
                currbook.Tags.Add(zarn.CheckedItems[i].ToString());
            currbook.ImageIndex = 3;
            MessageBox.Show("Information updated");
        }

        private void isDone_Tick(object sender, EventArgs e)
        {
            if (done == true)
            {
                done = false;
                if (procId < booklist.Items.Count)
                {
                    Log("Poceo: " + ((Book)booklist.Items[procId]).Path );
                    booklist.Items[procId].ImageIndex = 2;
                    Thread grabData = new Thread(new ParameterizedThreadStart(ProcessBook));
                    grabData.Start(new object[] { (Book)booklist.Items[procId], procId });

                    Log("Zavrsio: " + ((Book)booklist.Items[procId]).Path);
                    procId++;
                }  else { isDone.Stop(); return;  }
            }
        }




        private void saveBooks_Click(object sender, EventArgs e)
        {
            foreach (Book item in booklist.Items)
                item.ImageIndex = 1;
            done = true;

            procId = 0;
            saveTimer.Start();
            /*  foreach (Book book in booklist.Items)
             {


                 if (book.Save()) booklist.Items[book.Index].ImageIndex = 7; 
             }*/
        }

        private void booklist_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void searchOnAmazon_Click(object sender, EventArgs e)
        {
            try
            {
                Process.Start("http://www.amazon.com/s/ref=nb_ss_gw?url=search-alias%3Dstripbooks&field-keywords=" + propTitle.Text);
            }
            catch { }
        }


        private void saveBook(object state)
        {
            object[] s = (object[])state;

            Book currbook = s[0] as Book;
            int br = (int)s[1];

            if (currbook.Save()) ChangeStatus(br,7);
            done = true;
        }

        private void saveTimer_Tick(object sender, EventArgs e)
        {
            if (done == true)
            {
                done = false;
                if (procId < booklist.Items.Count)
                {
                    booklist.Items[procId].ImageIndex = 2;
                    Thread saveData = new Thread(new ParameterizedThreadStart(saveBook));
                    saveData.Start(new object[] { (Book)booklist.Items[procId], procId });
                    procId++;
                }
                else { saveTimer.Stop(); return; }
            }
        }


        private void saveButt_Click(object sender, EventArgs e)
        {
            Stream stream = File.Open("c:\\session.dat", FileMode.Create);
            BinaryFormatter bformatter = new BinaryFormatter();

            ArrayList simpleBookList = new ArrayList();
            foreach (Book o in booklist.Items)
                simpleBookList.Add(new SimpleBook(o));

            bformatter.Serialize(stream, simpleBookList);
            stream.Close();

        }

        private void openButt_Click(object sender, EventArgs e)
        {
            booklist.Clear();
            booklist.Items.Clear();
            ArrayList mp = null;
            Stream stream = File.Open("c:\\session.dat", FileMode.Open);
            BinaryFormatter bformatter = new BinaryFormatter();
            mp = (ArrayList)bformatter.Deserialize(stream);

            foreach (SimpleBook book in mp)
                booklist.Items.Add(book.LoadData());

            stream.Close();
        }
    }
}
