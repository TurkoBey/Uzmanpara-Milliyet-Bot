using HtmlAgilityPack;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Uzmanpara.Bot.VeriCek
{
    public static class GundemCek
    {
        public static void UzmanParaGundemCek()
        {
            try
            {
                var site = "https://uzmanpara.milliyet.com.tr/haber/gundem/";

                List<Gundem> GundemListesi = new List<Gundem>();

                HtmlWeb web = new HtmlWeb();
                HtmlDocument document = web.Load(site);

                var GundemXpath = "//div[@class='box box7']";
                var GundemX = document.DocumentNode.SelectNodes(GundemXpath);

                foreach (var Gundem in GundemX)
                {
                    for (int i = 1; i <= 25; i++)
                    {
                        string HaberBaslik = KarakterDuzelt.Duzelt(Gundem.SelectSingleNode("/html/body/div[9]/div[7]/div[2]/div[3]/ul/li[" + i + "]/a/text()").InnerText);
                        string HaberTarih = KarakterDuzelt.Duzelt(Gundem.SelectSingleNode("/html/body/div[9]/div[7]/div[2]/div[3]/ul/li[" + i + "]/span").InnerText);
                        string HaberLink = Gundem.SelectSingleNode(".//li[" + i + "]/a").Attributes["href"].Value;

                        GundemListesi.Add(new Gundem()
                        {
                            HaberBaslik = HaberBaslik,
                            HaberTarih = HaberTarih,
                            HaberLink = HaberLink,
                        });
                    }
                }
                Console.WriteLine("======================");
                foreach (var Gundem in GundemListesi)
                {
                    Console.WriteLine($"Başlık :: {Gundem.HaberBaslik}");
                    Console.WriteLine($"Tarih  :: {Gundem.HaberTarih}");
                    Console.WriteLine($"Link   :: {Gundem.HaberLink}");
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
