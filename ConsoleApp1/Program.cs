using EasyAutomationFramework;
using EasyAutomationFramework.Model;
using WebScraping.Driver;

var web = new WebScraper();
var computeres = web.GetData("https://lista.mercadolivre.com.br/ferramentas_NoIndex_True");

for (int i = 51; i < 2000; i+=50)
{
    var url = $"https://lista.mercadolivre.com.br/ferramentas_Desde_{i}_NoIndex_True";
    computeres = web.GetData(url);
   
}

var paramss = new ParamsDataTable("Dados", @"D:\Projetos_\Excel", new List<DataTables>()
{
    new DataTables("computeres", computeres),

});

Base.GenerateExcel(paramss);

web.CloseBrowser();