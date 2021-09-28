using System.Threading.Tasks;
using CliFx;
using Qarrot.Base;
using Qarrot.Core;

namespace qarrot
{
    class Program
    {
        public static async Task<int> Main()
        {
            var assemblies = new[]
            {
                typeof(AmqpPublish).Assembly,
                typeof(Publish).Assembly
            };
            
            return await new CliApplicationBuilder()
                .SetDescription(GetLogo())
                .SetTitle("Qarrot CLI tool")
                .AddCommandsFrom(assemblies)
                .SetExecutableName("qarrot")
                .Build()
                .RunAsync();

        }
        private static string GetLogo()
        {
            var asciiArt =
                ":.\n" + 
                " :=-                 ____                            _   \n" +
                "    .-=-:.          / __ \\                          | |\n" +
                "    +*****=.       | |  | |  __ _  _ __  _ __  ___  | |_ \n" +
                "    =*******-      | |  | | / _` || '__|| '__|/ _ \\ | __|\n" +
                "     -+******=     | |__| || (_| || |   | |  | (_) || |_ \n" +
                "       :=*****+.    \\___\\_\\ \\__,_||_|   |_|   \\___/  \\__|\n" +
                "          :=+**+  \n" +
                "            .:-.s'\n";
            return asciiArt;
        }
    }
}