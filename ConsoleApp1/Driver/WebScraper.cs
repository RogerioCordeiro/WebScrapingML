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
using WebScraping.Model;

namespace WebScraping.Driver
{
    public class WebScraper : Web
    {
        public DataTable GetData(string link)
        {
            if(driver == null)
                StartBrowser();

            var itens  = new List<Item>();

            Navigate(link);

            var elements = GetValue(TypeElement.Xpath, "//*[@id=\"root-app\"]/div/div[3]/section/ol").element.FindElements(By.ClassName("shops__layout-item"));
 

            foreach (var element in elements) 
            {
                var item = new Item();
                item.Title = element.FindElement(By.ClassName("ui-search-item__title")).Text;

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
                item.Price = preco;

                item.Description = element.FindElement(By.ClassName("ui-search-link")).Text;
                item.Link = element.FindElement(By.ClassName("ui-search-link")).GetAttribute("href");

                itens.Add(item);

            }

            return Base.ConvertTo(itens);
        }
    }
}
