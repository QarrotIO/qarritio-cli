using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;
using Microsoft.Extensions.Hosting;
using ConsoleAppFramework;

namespace qarrot
{
    class Program
    {
        static async Task Main(string[] args)
        {
            // target T as ConsoleAppBase.
            await Host.CreateDefaultBuilder().RunConsoleAppFrameworkAsync(args, new ConsoleAppOptions
            {
                StrictOption = true
            });
        }

        private void PrintLogo()
        {
            var asciiArt = new[]
            {
                @":.",
                @" :=-                 ____                            _   ",
                @"    .-=-:.          / __ \                          | |",
                @"    +*****=.       | |  | |  __ _  _ __  _ __  ___  | |_ ",
                @"    =*******-      | |  | | / _` || '__|| '__|/ _ \ | __|",
                @"     -+******=     | |__| || (_| || |   | |  | (_) || |_ ",
                @"       :=*****+.    \___\_\ \__,_||_|   |_|   \___/  \__|",
                @"          :=+**+  ",
                @"            .:-.s'"
            };
            foreach (var line in asciiArt)
                Console.WriteLine(line);
            Console.WriteLine("\r\n");
        }

        private IEnumerable<string> GetCommands()
        {
            var methods =
                typeof(Program).GetMethods(BindingFlags.Public | BindingFlags.Instance | BindingFlags.DeclaredOnly);
            var commandAttributes = methods.Select(m => m.GetCustomAttributes<CommandAttribute>());
            var attributes = commandAttributes.ToList();

            var names  = 
                attributes.Select(x => x.Select(o => o.CommandNames.First()));
            var descriptions = 
                attributes.Select(x => x.Select(o => o.Description));

            foreach (var (name, description) in names.Zip(descriptions))
            {
                string printable = null;
                try
                {
                    printable = string.Join(" ", name.First(), description.First());
                }
                catch (Exception e)
                {
                    Console.WriteLine("Error");
                }
                yield return printable;

            }
        }
        
        [Command("hi", "Prints the manual guide")]
        public void Help()
        {
            PrintLogo();
            Console.WriteLine("Usage: qarrot [commands] [options]");
            Console.WriteLine("\r\n");
            Console.WriteLine("Commands: \r\n");
            var commands = GetCommands();
            foreach (var command in commands)
            {
                Console.Write(command + "\r");
            }
        }
    }
}