using HtmlAgilityPack;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Uzmanpara.Bot
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.Title = "uzmanpara.milliyet.com.tr Botu";

            Console.WriteLine(
                "\n==========================================================\n"
                "uzmanpara.milliyet.com.tr'den Döviz & Altın Kuru Çeken Bot" + 
                "\n==========================================================\n");

            Console.WriteLine(
                "[ 1 ] ==> Döviz ( Dolar & Euro & Sterlin )" + "\n" +
                "[ 2 ] ==> Altin ( Gram - Çeyrek - ONS )" + "\n" +
                "[ 3 ] ==> Merkez Bankası Kurları" + "\n" +
                "[ 4 ] ==> Serbest Piyasa Kurları" + "\n" +
                "[ 5 ] ==> Kripto" + "\n" +
                "[ 6 ] ==> Gündem Haber" + 
                "\n\n==========================================================\n");

            Console.Write("Seçim yapınız : ");

            try
            {
                Class1.NewMethod();
            }
            catch (Exception mesaj)
            {
                Console.Write("Sadece sayı değeri giriniz..");
            }
            finally
            {
                Console.Write("\n\nSeçim yapınız : ");
                Class1.NewMethod();
            }

            Console.ReadLine();
        }


    }
}
