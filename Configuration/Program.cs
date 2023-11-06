// See https://aka.ms/new-console-template for more information

using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Configuration.Json;
using Microsoft.Extensions.Configuration.Memory;
using Microsoft.Extensions.Configuration.Ini;


var builder = new ConfigurationBuilder();

// DO NOT COMMIT CONFIG FILES!
builder
    .AddJsonFile("config.json")
    .AddIniFile("config.ini")
    .AddInMemoryCollection(new List<KeyValuePair<string, string?>>
    {
        new KeyValuePair<string, string?>("ProductsFileName", "products.json"),
    });


var configuration = builder.Build();

Console.WriteLine(configuration["ApiKey"]);
Console.WriteLine(configuration["ProductsFileName"]);
Console.WriteLine(configuration["Settings:HotKey1"]);
