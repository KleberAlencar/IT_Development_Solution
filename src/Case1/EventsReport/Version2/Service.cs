
namespace EventsReport.Version2;

public class Service(IRuleEngine engine)
{
    public void Run()
    {
        while (true)
        {
            try
            {
                engine.Execute();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"[Erro] {DateTime.Now}: {ex.Message}");
            }

            Thread.Sleep(TimeSpan.FromMinutes(5));
        }
    }
}
