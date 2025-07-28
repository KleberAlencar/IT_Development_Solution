/* VERSION 1
var svc = new Service();
// 1. Utilização desnecessária de Task.Run e WaitAll, adicionando complexidade, pode levar a problemas de desempenho
var task = Task.Run(() => svc.Run());
Task.WaitAll(new Task[] { task });
*/

// VERSION 2
using Microsoft.Extensions.Configuration;

var config = new ConfigurationBuilder()
    .SetBasePath(AppContext.BaseDirectory)
    .AddJsonFile("appsettings.json")
    .Build();

var engine = new EventsReport.Version2.RuleEngine(config.GetConnectionString("DefaultConnection")!);
var service = new EventsReport.Version2.Service(engine);
service.Run();