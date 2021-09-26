using System;
using ConsoleAppFramework;
using Qarrot.Core;

namespace Qarrot.Base
{
    public class AmqpPublish : Publish
    {
        [Command("amqp", "Publish via AMQP")]
        public override void Execute()
        {
            Console.WriteLine("Publishing via AMQP");
        }
    }
}