using HtmlAgilityPack;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Uzmanpara.Bot.VeriCek
{
    public class MerkezBankasiCek
    {
        public static void UzmanParaMerkezBankasiDovizCek()
        {
            try
            {
                var site = "https://uzmanpara.milliyet.com.tr/doviz/merkez-bankasi-doviz-kurlari/";

                List<Doviz> DovizListesi = new List<Doviz>();

                HtmlWeb web = new HtmlWeb();
                HtmlDocument document = web.Load(site);

                var DovizXpath = "//div[@class='detL']";
                var DovizX = document.DocumentNode.SelectNodes(DovizXpath);

                foreach (var Doviz in DovizX)
                {
                    for (int i = 2; i <= 15; i++)
                    {
                        string DovizCinsi = Doviz.SelectSingleNode("/html/body/div[9]/div[7]/div[2]/div[1]/table/tbody/tr[" + i + "]/td[1]").InnerText;
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
                    Console.WriteLine($"Döviz Cinsi :: {Doviz.DovizAD}");
                    Console.WriteLine($"Döviz Alış  :: {Doviz.DovizAlis}");
                    Console.WriteLine($"Döviz Satış :: {Doviz.DovizSatis}");
                    Console.WriteLine($"Değişim     :: {Doviz.DovizDegisim}");
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
