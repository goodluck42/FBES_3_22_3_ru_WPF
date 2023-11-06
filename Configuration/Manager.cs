using Microsoft.Extensions.Configuration;

namespace Configuration;

public class Manager
{
    private readonly IConfiguration _configuration;

    public Manager(IConfiguration configuration)
    {
        _configuration = configuration;
    }

    public void TestMethod()
    {
        Console.WriteLine(_configuration["ApiKey"]);
    }
}