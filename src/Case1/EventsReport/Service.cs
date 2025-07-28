using Microsoft.Data.SqlClient;

namespace EventsReport;

public class Service
{
    public void Run()
    {
        // 2. Apesar da simplicidade da aplicação, instância criada diretamente, pode dificultar testes caso seja necessário
        var engine = new RuleEngine();
        // 3. Loop executado de forma infinita sem nenhum delay, pode consumir 100% da CPU
        while (true)
        {
            engine.Execute();
        }
    }
}

public class RuleEngine : IRuleEngine
{
    public void Execute()
    {
        // 4. Não utilização de try-catch, qualquer falha na execução derruba a aplicação 
        // 5. Conexão sem tratamento de exceção pode causar falhas inesperadas - ** senha do banco de dados exposta **
        var connString = "Data Source=mainDb;User ID=user;Password=pass;Connect Timeout=5";
        // 6. Consulta SQL sem parametrização, vulnerável a SQL Injection
        var query = $"SELECT evento FROM eventos WHERE timestamp > '{DateTime.Now.AddMinutes(-5):yyyy-MM-dd HH:mm:ss}'";
        // 7. Conexões e recursos não são fechados corretamente, conn e reader não são liberados automaticamente
        var conn = new SqlConnection(connString);
        var cmd = new SqlCommand(query, conn);
        conn.Open();
        var reader = cmd.ExecuteReader();
        var eventos = new List<string?>();
        while (reader.Read())
        {
            eventos.Add(reader[0].ToString());
        }
        // 8. Uso de ToArray() em uma lista que pode ser nula, pode causar NullReferenceException
        // 9. Escrita em arquivo sem verificar se o diretório existe, pode causar DirectoryNotFoundException
        // verificar se o diretório existe e criar se necessário
        File.WriteAllLines($@"C:\temp\eventos_{Guid.NewGuid()}.txt", eventos.ToArray()!);
        // 10. Falta de logging, não há registro de erros ou informações relevantes sobre falhas ou execução
    }
}

public interface IRuleEngine
{
    void Execute();
}

