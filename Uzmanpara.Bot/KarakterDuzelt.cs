using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Uzmanpara.Bot
{
    public static class KarakterDuzelt
    {
        public static string Duzelt(string str)
        {
            str = str.Replace("Ä±", "i");
            str = str.Replace("Ã\u0087", "C");
            str = str.Replace("%Â ", "% ");
            str = str.Replace("2021", "2021 / ");
            str = str.Replace("İ", "I");
            str = str.Replace("ı", "i");
            str = str.Replace("Ğ", "G");
            str = str.Replace("ğ", "g");
            str = str.Replace("Ö", "O");
            str = str.Replace("ö", "o");
            str = str.Replace("Ü", "U");
            str = str.Replace("ü", "u");
            str = str.Replace("Ã§", "c");
            str = str.Replace("Ã¼", "u");
            str = str.Replace("Ã¶", "o");
            str = str.Replace("Å?", "s");
            str = str.Replace("Å§", "c");
            str = str.Replace("Å?", "s");
            str = str.Replace("Ä°", "I");
            str = str.Replace("Ä±", "i");

            return str;
        }
    }
}
