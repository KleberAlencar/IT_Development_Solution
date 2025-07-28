using Microsoft.Data.SqlClient;

namespace EventsReport.Version2;

public class RuleEngine(string connectionString) : IRuleEngine
{
    private const string OutputPath = @"C:\temp";

    public void Execute()
    {
        var eventos = new List<string>();

        using var connection = new SqlConnection(connectionString);
        using var command = new SqlCommand("SELECT evento FROM eventos WHERE timestamp > @timestamp", connection);
        command.Parameters.AddWithValue("@timestamp", DateTime.Now.AddMinutes(-5));

        connection.Open();
        using var reader = command.ExecuteReader();
        while (reader.Read())
        {
            eventos.Add(reader[0].ToString() ?? string.Empty);
        }

        if (!Directory.Exists(OutputPath))
        {
            Directory.CreateDirectory(OutputPath);
        }

        var filename = Path.Combine(OutputPath, $"eventos_{Guid.NewGuid()}.txt");
        File.WriteAllLines(filename, eventos);
    }
}