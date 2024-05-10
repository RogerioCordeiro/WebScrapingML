using EasyAutomationFramework;
using EasyAutomationFramework.Model;
using WebScraping.Driver;

var web = new WebScraper();
var computeres = web.GetData("https://lista.mercadolivre.com.br/cartao-de-memoria");

var paramss = new ParamsDataTable("Dados", @"D:\Projetos_\Excel", new List<DataTables>()
{
    new DataTables("computeres", computeres),

});

Base.GenerateExcel(paramss);

web.CloseBrowser();