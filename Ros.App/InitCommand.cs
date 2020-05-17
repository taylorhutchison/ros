using System.CommandLine;
using System.CommandLine.Invocation;
using System.IO;

namespace Ros.App
{
    public static class InitCommand
    {

        private static string initFileContents =
        @"{
    'siteTitle': 'Default Title'
}";

        public static Symbol Command
        {
            get
            {
                var initCommand = new Command("init", "The initialization command for a new project.") {
                    new Option<FileInfo>("--output", "Directory to create Ros site."),
                    new Option<bool>("--quiet", "No stdout messages.")
                };
                initCommand.Handler = CommandHandler.Create<FileInfo, bool>(Handler);
                return initCommand;
            }
        }

        private static void Handler(FileInfo output, bool quiet)
        {
            if (output != null)
            {

                if (File.Exists(Path.Combine(output.FullName, "ros.json")))
                {
                    Output.WriteLine("Ros configuration file ros.json already exists at path " + output.FullName, quiet);
                    return;
                }
            }
            else
            {
                output = new FileInfo(Directory.GetCurrentDirectory());
            }
            Output.WriteLine("Creating file at " + Path.Combine(output.FullName, "ros.json"), quiet);
            File.WriteAllText(Path.Combine(output.FullName, "ros.json"), initFileContents);
        }

    }
}