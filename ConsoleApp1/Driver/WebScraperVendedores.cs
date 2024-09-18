using System;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EasyAutomationFramework;
using WebScraping.Entities.Vendedores;

namespace WebScraping.Driver
{
    public class WebScraperVendedores : Web
    {
        public DataTable GetData(string baseUrl) 
        {
            if (driver == null)
                StartBrowser();

            var vendedor = new List<Vendedor>();

            Navigate(baseUrl);

            Debugger.Break();

            return Base.ConvertTo(vendedor); 
        
        } 
    }
}
