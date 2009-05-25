using System;
using System.Collections.Generic;
using System.Text;
using RelatedObjects.Storage;
using System.Text.RegularExpressions;
using System.IO;

namespace ISBNextractor
{
    class CHMParser
    {
        public CHMParser()
        {

        }

        public ResultISBN ExtractISBN(string path)
        {
            try
            {
                int i = 0;
                ITStorageWrapper iw = new ITStorageWrapper(path);

                foreach (IBaseStorageWrapper.FileObjects.FileObject fileObject in iw.foCollection)
                {
                    if (fileObject.CanRead)
                    {
                        if (fileObject.FileName.EndsWith(".hhc"))
                        {
                            Regex exp = new Regex(@"[0-9]{9}[0-9xX]", RegexOptions.IgnoreCase);
                            string filtriran = fileObject.FileName.Replace(":", "").Replace(" ", "").Replace("-", "").Trim();
                            Match m = exp.Match(filtriran);
                            if (m.Success) return (new ResultISBN(m.Value,null));
                        }
                        if (fileObject.FileName.EndsWith(".html") || fileObject.FileName.EndsWith(".htm") || fileObject.FileName.StartsWith("#"))
                        {
                            string rezult = fileObject.ReadFromFile();
                            string isbn = (new ISBN()).getISBNFromContent(rezult);
                            switch (isbn)
                            {
                                case null:
                                    break;
                                case "nomatch":
                                    return (new ResultISBN("nomatch", rezult));
                                default:
                                    return (new ResultISBN(isbn, rezult));
                            }
                            if (i < 11) i++; else return (new ResultISBN(isbn, rezult));
                        }
                    }
                }
            }
            catch (Exception e)
            {
                File.AppendAllText("log_chm.txt", DateTime.Now.ToShortDateString() + " " + DateTime.Now.ToShortTimeString() + ": " + path +" ::: " +e.Message + Environment.NewLine);
            }
            return (new ResultISBN(null,null));
        }
    }
}
