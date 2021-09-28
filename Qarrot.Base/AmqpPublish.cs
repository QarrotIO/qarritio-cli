using System.Threading.Tasks;
using CliFx;
using CliFx.Attributes;
using CliFx.Infrastructure;

namespace Qarrot.Base
{
    [Command("publish amqp", Description = "Publish via AMQP")]
    public class AmqpPublish : ICommand
    {
        [CommandOption("host", 'h', Description = "Hostname of the AMQP destination")]
        public string Hostname { get; set; }

        [CommandOption("username", 'u', Description = "Username of the AMQP destination")]
        public string Username { get; set; }

        [CommandOption("password", 'p', Description = "Password of the AMQP destination")]
        public string Password { get; set; }

        public ValueTask ExecuteAsync(IConsole console)
        {
            console.Output.WriteLine($"Publishing via AMQP to: amqp:\\\\{Username}:{Password}@{Hostname}:15672...");
            return default;
        }
    }
}