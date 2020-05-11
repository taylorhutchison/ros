using System;
using System.CommandLine;
using System.CommandLine.Invocation;
using System.IO;

namespace Ros.App
{
    public static class InitCommand
    {

        public static Symbol Command
        {
            get
            {
                var initCommand = new Command("init", "The initialization command for a new project.") {
                    new Option<FileInfo>("--output", "Directory to create Ros site.")
                };
                initCommand.Handler = CommandHandler.Create<FileInfo>(Handler);
                return initCommand;
            }
        }

        private static void Handler(FileInfo output)
        {
            Console.WriteLine($"Do you want to init a new project?");
            Console.WriteLine(output.FullName);
        }

    }
}