using System;
using System.Linq;
using System.Reflection;
using DbUp;

namespace CarFinance247DBUpScripts
{
    class Program
    {
        // Helper for creating and seeding database using dbUp, mainly based of the example code they provided
        // When ran will create a db in local sqlexpress or where a given connection string is provided.
        // Will create and populate Customer table 
        static int Main(string[] args)
        {
            var connectionString =
         args.FirstOrDefault()
         ?? "Server=(local)\\SqlExpress; Database=CarFinance247TechTestRobStone; Trusted_connection=true";
            //Makes sure database exists
            EnsureDatabase.For.SqlDatabase(connectionString);
            var upgrader =
                DeployChanges.To
                    .SqlDatabase(connectionString)
                    .WithScriptsEmbeddedInAssembly(Assembly.GetExecutingAssembly())
                    .LogToConsole()
                    .Build();

            var result = upgrader.PerformUpgrade();

            if (!result.Successful)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine(result.Error);
                Console.ResetColor();
            #if DEBUG
                Console.ReadLine();
            #endif
                return -1;
            }

            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("Success!");
            Console.ResetColor();
            return 0;
        }
    }
}
