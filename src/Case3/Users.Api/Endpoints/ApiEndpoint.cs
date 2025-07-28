namespace Users.Api.Endpoints;

public abstract class ApiEndpoint
{
    private const string ApiBase = "api";
    
    public static class Users
    {
        private const string Base = $"{ApiBase}/users";
        public const string Get = $"{Base}/{{id}}";
    }
}