using System.Threading.Tasks;
using CliFx;
using CliFx.Attributes;
using CliFx.Infrastructure;

namespace Qarrot.Base
{
    [Command("publish amqp", Description = "Publish via AMQP")]
    public class AmqpPublish : ICommand
    {
        public ValueTask ExecuteAsync(IConsole console)
        {
            console.Output.WriteLine("Executing from AmqpPublish..");
            return default;
        }
    }
}