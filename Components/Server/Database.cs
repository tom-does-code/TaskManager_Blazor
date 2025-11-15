namespace BlazorWeb_New.Components.Server;

public class Database
{
    private readonly string? _connectionString;
    
    public Database(IConfiguration configuration)
    {
        _connectionString = configuration.GetConnectionString("BlazorString");
        Console.WriteLine(_connectionString);
    }
}