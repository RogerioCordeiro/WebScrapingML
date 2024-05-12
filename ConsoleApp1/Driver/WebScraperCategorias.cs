using System;
using System.Collections.Generic;
using System.Data;
using System.Globalization;
using System.Linq;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using EasyAutomationFramework;
using java.awt;
using OpenQA.Selenium;
using WebScraping.Entities.Anuncios;

namespace WebScraping.Driver
{
    public class WebScraperCategorias : Web
    {
        public DataTable GetData(string baseURL)
        {
            var anuncios = new List<Anuncio>();

            for (int paginas = 0;  paginas < 2000; paginas += 50) 
            {

                if (driver == null)
                    StartBrowser();

                baseURL = (paginas > 0)  ? baseURL + $"_Desde_{paginas + 1}_NoIndex_True" : baseURL;

                Navigate(baseURL);

                var elements = GetValue(TypeElement.Xpath, "//*[@id=\"root-app\"]/div/div[3]/section/ol").element.FindElements(By.ClassName("shops__layout-item"));

                    foreach (var element in elements)
                    {
                        var anuncio = new Anuncio();
                        anuncio.Title = element.FindElement(By.ClassName("ui-search-item__title")).Text;

                        var fractionElement = element.FindElement(By.ClassName("andes-money-amount__fraction"));
                        var real = fractionElement != null ? fractionElement.Text : "00";

                        string cent = "00";

                        try
                        {
                            var centsElement = element.FindElement(By.ClassName("andes-money-amount__cents"));
                            cent = centsElement.Text;
                        }
                        catch (NoSuchElementException)
                        {
                            cent = string.Empty;
                        }
                        
                        double.TryParse(real + "," + cent, out double preco);

                        anuncio.Price = preco;

                        anuncio.Description = element.FindElement(By.ClassName("ui-search-link")).Text;
                        anuncio.Link = element.FindElement(By.ClassName("ui-search-link")).GetAttribute("href");

                    anuncios.Add(anuncio);
                    }

            }
            return Base.ConvertTo(anuncios);
        }
    }
}
