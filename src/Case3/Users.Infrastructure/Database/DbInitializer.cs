using Dapper;
using Users.Infrastructure.Database.Interfaces;

namespace Users.Infrastructure.Database;

public class DbInitializer(IDbConnectionFactory dbConnectionFactory)
{
    public async Task InitializeAsync()
    {
        using var connection = await dbConnectionFactory.CreateConnectionAsync();
        
        await connection.ExecuteAsync("""
                                      create table if not exists systemusers (
                                      id INTEGER primary key, 
                                      firstname TEXT not null,
                                      lastname TEXT not null, 
                                      email TEXT not null);

                                      INSERT INTO systemusers (id, firstname, lastname, email) 
                                      VALUES
                                          (1, 'Ana', 'Silva', 'ana.silva@example.com'),
                                          (2, 'Bruno', 'Costa', 'bruno.costa@example.com'),
                                          (3, 'Carla', 'Oliveira', 'carla.oliveira@example.com'),
                                          (4, 'Daniel', 'Santos', 'daniel.santos@example.com'),
                                          (5, 'Eduarda', 'Lima', 'eduarda.lima@example.com'),
                                          (6, 'Felipe', 'Almeida', 'felipe.almeida@example.com'),
                                          (7, 'Gabriela', 'Mendes', 'gabriela.mendes@example.com'),
                                          (8, 'Henrique', 'Rocha', 'henrique.rocha@example.com'),
                                          (9, 'Isabela', 'Fernandez', 'isabela.fernandes@example.com'),
                                          (10, 'João', 'Martins', 'joao.martins@example.com')
                                      ON CONFLICT (id)
                                      DO NOTHING;
                                      """);        
    }    
}