using HtmlAgilityPack;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Uzmanpara.Bot.VeriCek
{
   public static class KriptoCek
    {
        public static void UzmanParaKriptoCek()
        {
            try
            {
                var site = "https://uzmanpara.milliyet.com.tr/kripto-paralar/";

                List<Doviz> DovizListesi = new List<Doviz>();

                HtmlWeb web = new HtmlWeb();
                HtmlDocument document = web.Load(site);

                var DovizXpath = "//div[@class='box box7 box11']";
                var DovizX = document.DocumentNode.SelectNodes(DovizXpath);

                foreach (var Doviz in DovizX)
                {
                    for (int i = 2; i <= 4; i++)
                    {
                        string DovizCinsi = Doviz.SelectSingleNode("/html/body/div[9]/div[7]/div[2]/div[1]/table/tbody/tr[" + i + "]/td[1]/a").InnerText;
                        string DovizAlis = Doviz.SelectSingleNode("/html/body/div[9]/div[7]/div[2]/div[1]/table/tbody/tr[" + i + "]/td[2]").InnerText;
                        string DovizSatis = Doviz.SelectSingleNode("/html/body/div[9]/div[7]/div[2]/div[1]/table/tbody/tr[" + i + "]/td[3]").InnerText;
                        string DovizDegisim = KarakterDuzelt.Duzelt(Doviz.SelectSingleNode("/html/body/div[9]/div[7]/div[2]/div[1]/table/tbody/tr[" + i + "]/td[4]").InnerText);

                        DovizListesi.Add(new Doviz()
                        {
                            DovizAD = DovizCinsi,
                            DovizAlis = DovizAlis,
                            DovizSatis = DovizSatis,
                            DovizDegisim = DovizDegisim
                        });
                    }
                }
                Console.WriteLine("======================");
                foreach (var Doviz in DovizListesi)
                {
                    Console.WriteLine($"Döviz Cinsi   :: {Doviz.DovizAD}");
                    var sonuc = Doviz.DovizAD.IndexOf("USD", 0);
                    if (sonuc == 6)
                    {
                        Console.WriteLine($"Döviz Alış    :: {Doviz.DovizAlis}" + " USD");
                        Console.WriteLine($"Döviz Satış   :: {Doviz.DovizSatis}" + " USD");
                    }
                    else
                    {
                        Console.WriteLine($"Döviz Alış    :: {Doviz.DovizAlis}" + " TL");
                        Console.WriteLine($"Döviz Satış   :: {Doviz.DovizSatis}" + " TL");
                    }
                    Console.WriteLine($"Döviz Değişim :: {Doviz.DovizDegisim}");
                    Console.WriteLine("======================");

                }
            }
            catch (Exception mesaj)
            {
                Console.WriteLine(">>" + mesaj.Message);
            }
        }
    }
}
