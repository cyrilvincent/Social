using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Social.RepositoriesLibrary
{
    public static class Extensions
    {
        public static string RemoveDiacritics(this string stIn)
        {
            string stFormD = stIn.Normalize(NormalizationForm.FormD);
            StringBuilder sb = new StringBuilder();
            for (int ich = 0; ich < stFormD.Length; ich++)
            {
                UnicodeCategory uc = CharUnicodeInfo.GetUnicodeCategory(stFormD[ich]);
                if (uc != UnicodeCategory.NonSpacingMark)
                {
                    sb.Append(stFormD[ich]);
                }
            }
            return (sb.ToString().Normalize(NormalizationForm.FormC));
        }

        public static string NormalizeForFile(this string s)
        {
            string res = null;
            if(s!=null) 
                res = s.Trim().Replace(" ", "_").Replace("\"", "").Replace("/", "_").Replace("\\", "_").Replace("\t", "_").Replace("\n", "_").Replace("+", "").Replace("&amp;","et");
            return res;
            //s = " toto s/b\\x\tx\nx\f toto b`g\"p+ ";
            // ca marche mais pas tester à grande echelle
            //s = Regex.Replace(s.Trim(), @"[ /\\\t\n\f]", "_");
            //s = Regex.Replace(s, "[\"+`]", "");
            //return s;
        }

        public static string RepareUTF8(this string s)
        {
            return s.Replace("�", "é");
        }


    }
}
