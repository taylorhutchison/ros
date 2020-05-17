using System;
using System.CommandLine;
using System.CommandLine.Invocation;
using System.Threading.Tasks;
using Markdig;

namespace Ros.App
{
    class Program
    {
        static async Task Main(string[] args)
        {
            var rootCommand = new RootCommand();

            rootCommand.Handler = CommandHandler.Create(() => { });

            rootCommand.Add(InitCommand.Command);

            // Parse the incoming args and invoke the handler
            await rootCommand.InvokeAsync(args);

        }
    }
}
