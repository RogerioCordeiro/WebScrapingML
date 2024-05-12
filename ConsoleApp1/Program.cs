using System.Data;
using System.Diagnostics;
using EasyAutomationFramework;
using EasyAutomationFramework.Model;
using WebScraping.Driver;

var web = new WebScraperCategorias();
var webVendedor = new WebScraperVendedores();

var anuncios = web.GetData("https://lista.mercadolivre.com.br/ferramentas");

foreach (DataRow anunc in anuncios.Rows)
{
    var baseUrl = anunc["Link"].ToString();
    //Debugger.Break();
    //var vendedores = webVendedor(baseUrl);
}

var paramss = new ParamsDataTable("Dados", @"D:\Projetos_\Excel", new List<DataTables>()
{
    new DataTables("anuncios", anuncios),

});

Base.GenerateExcel(paramss);

web.CloseBrowser();