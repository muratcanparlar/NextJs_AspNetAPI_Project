using DbUp;
using Microsoft.Extensions.Configuration;
using System.Reflection;

namespace SchoolHive.Modules.Users.Db;
internal class Program
{
    static void Main(string[] args)
    {
        var builder = new ConfigurationBuilder()
            .SetBasePath(Directory.GetCurrentDirectory())
            .AddJsonFile("appsettings.json")
            .AddJsonFile($"appsettings{Environment.GetEnvironmentVariable("ASPNETCORE.ENVIRONMENT")}.json", true)
            .AddEnvironmentVariables();

        var configuration = builder.Build();

        var connectionString = configuration["SchoolHiveDB"];

        var upgrader =
            DeployChanges.To
            .PostgresqlDatabase(connectionString)
            .WithScriptsEmbeddedInAssembly(Assembly.GetExecutingAssembly())
            .LogToConsole()
            .WithExecutionTimeout(TimeSpan.FromSeconds(300))
            .Build();

        var result = upgrader.PerformUpgrade();

        if (!result.Successful)
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine(result.Error);
            Console.ResetColor();
            Console.ReadLine();
        }

        Console.ForegroundColor = ConsoleColor.Green;
        Console.WriteLine("Success!");
        Console.ResetColor();
    }
}

