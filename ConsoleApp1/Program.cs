using System.Diagnostics;
using EasyAutomationFramework;
using EasyAutomationFramework.Model;
using WebScraping.Driver;

var web = new WebScraper();

var anuncios = web.GetData("https://lista.mercadolivre.com.br/ferramentas");

var paramss = new ParamsDataTable("Dados", @"D:\Projetos_\Excel", new List<DataTables>()
{
    new DataTables("anuncios", anuncios),

});

Base.GenerateExcel(paramss);

web.CloseBrowser();