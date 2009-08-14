using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;
using System.IO;

namespace ISBNextractor
{
    class ISBN
    {

      public bool isValidISBNNumber(String ISBNnumber) {
   /*     // check whether this is a valid ISBN number: see http://www.isbn-international.org/en/userman/chapter4.html

        // remove all non-valid ISBN characters (0-9xX and - seem valid) and the -
        String number = ISBNnumber.replaceAll("[^0-9xX]", "");
        if (number.Length != 10) {
        //    log.debug("invalid ISBN: " + number);
            return false;
        }
        char checkDigit = number[9];
        int checkInt;
        if (checkDigit == 'X') {
            checkInt = 10;
        } else {
            checkInt = checkDigit;
        }
        String ISBNnumberPrefix = number.Substring(0, 9);

        // elf proof
        int total = checkInt;
        for (int i = 0; i < 9; i++) {
            int k = Integer.parseInt("" + ISBNnumberPrefix[i]);
            total += (10 - i) * k;
        }
        if ((total % 11) != 0) {
        //    log.debug("invalid ISBN, not ELF proof: " + number);
            return false;
        }
        //log.debug("valid ISBN: " + number);
          */
        return true; 
    }


      public String getISBNFromContent(String fileString)
      {
          if (fileString == null)
              return null;

        int pos, pos1;
        Regex exp = new Regex(@"[0-9]{9}[0-9xX]", RegexOptions.IgnoreCase);
        string filtriran;
        Match m;

        if (fileString.Contains("ISBN-10") || fileString.Contains("ISBN 10"))
        {
           pos = fileString.IndexOf("ISBN-10");
           if (pos == -1) pos = fileString.IndexOf("ISBN 10");
           filtriran = fileString.Substring(pos + 7, 30).Replace(":", "").Replace(" ", "").Replace("-", "").Trim();
           m = exp.Match(filtriran);

           return (m.Success) ? m.Value : "nomatch";
        }

        if (fileString.Contains("ISBN"))
        {
            pos = fileString.IndexOf("ISBN");
            filtriran = fileString.Substring(pos + 4, 30).Replace(":", "").Replace(" ", "").Replace("-", "").Trim();
            m = exp.Match(filtriran);
            String valu = m.Value;
            if (valu.StartsWith("97"))
                valu = filtriran.Substring(0, 13);

            return (m.Success) ? valu : "nomatch";
        }

   /* Very rare better to do it manually    
    * if (fileString.Contains("International Standard Book Number"))
         {
            pos = fileString.IndexOf("International Standard Book Number");
            filtriran = fileString.Substring(pos + 32, 30).Replace(":", "").Replace(" ", "").Replace("-", "").Trim();
            m = exp.Match(filtriran);
            return (m.Success) ? m.Value : "nomatch";
         } */

         return null;

        }
    }
}
