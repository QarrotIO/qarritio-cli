using System;
using System.Threading.Tasks;
using CliFx;
using CliFx.Attributes;
using CliFx.Infrastructure;

namespace Qarrot.Core
{
    [Command("publish", Description = "Execute a Publish action")]
    public class Publish : ICommand
    {
        public virtual void LoadData()
        {
            // Load data to be published
        }
        
        public virtual void HandleData()
        {
            // Handle data to be published
        }
        
        public virtual void Execute()
        {
            Console.WriteLine("Executing Generic Publish...");
        }

        public virtual ValueTask ExecuteAsync(IConsole console)
        {
            console.Output.WriteLine("Executing from Publish..");
            return default;
        }
    }
}