using HtmlAgilityPack;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Uzmanpara.Bot.VeriCek
{
   public static class AltinCek
    {
        public static void UzmanParaAltinCek()
        {
            try
            {
                var site = "https://uzmanpara.milliyet.com.tr/altin-fiyatlari/";

                List<Doviz> DovizListesi = new List<Doviz>();

                HtmlWeb web = new HtmlWeb();
                HtmlDocument document = web.Load(site);

                var DovizXpath = "//div[@class='borsaTop']";
                var DovizX = document.DocumentNode.SelectNodes(DovizXpath);

                foreach (var Doviz in DovizX)
                {
                    for (int i = 2; i <= 4; i++)
                    {
                        string DovizCinsi = KarakterDuzelt.Duzelt(Doviz.SelectSingleNode("./div[" + i + "]/span[1]/text()").InnerText);
                        string DovizAlis = Doviz.SelectSingleNode("./div[" + i + "]/div[2]/div[1]/text()").InnerText;
                        string DovizSatis = Doviz.SelectSingleNode("./div[" + i + "]/div[2]/div[2]/text()").InnerText;

                        DovizListesi.Add(new Doviz()
                        {
                            DovizAD = DovizCinsi,
                            DovizAlis = DovizAlis,
                            DovizSatis = DovizSatis
                        });
                    }
                }
                Console.WriteLine("======================");
                foreach (var Doviz in DovizListesi)
                {
                    Console.WriteLine($"Döviz Cinsi :: {Doviz.DovizAD}");
                    Console.WriteLine($"Döviz Alış  :: {Doviz.DovizAlis}" + " TL");
                    Console.WriteLine($"Döviz Satış :: {Doviz.DovizSatis}" + " TL");
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
