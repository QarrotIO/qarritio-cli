using System;
using ConsoleAppFramework;

namespace Qarrot.Core
{
    [Command("publish", "Execute a Publish action")]
    public abstract class Publish : ConsoleAppBase, IAction
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
    }
}