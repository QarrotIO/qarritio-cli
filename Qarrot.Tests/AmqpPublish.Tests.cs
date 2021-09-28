using System.Threading.Tasks;
using CliFx;
using CliFx.Infrastructure;
using NUnit.Framework;
using Qarrot.Base;

namespace Qarrot.Tests
{
    [TestFixture]
    public class AmqpPublishTests
    {
        [Test]
        public async Task AmqpPublish_Executes_Successfully()
        {
            // Arrange
            using var console = new FakeInMemoryConsole();

            var app = new CliApplicationBuilder()
                .AddCommand<AmqpPublish>()
                .UseConsole(console)
                .Build();

            var args = new[]
                {"publish", "amqp", "--host", "localhost", "--username", "admin", "--password", "admin"};
            
            // Act
            await app.RunAsync(args);

            var stdout = console.ReadOutputString();
            
            // Assert
            Assert.That(stdout, Is.EqualTo("Publishing via AMQP to: amqp:\\\\admin:admin@localhost:15672...\r\n"));
        }
    }
}