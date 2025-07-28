namespace Users.Infrastructure.Users.Scripts;

public static class UserScript
{
    public const string GetById = """
                                  SELECT id, firstname, lastname, email 
                                    FROM systemusers 
                                   WHERE id = @Id
                                  """;
}