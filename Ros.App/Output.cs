using System;

namespace Ros.App
{
    public static class Output
    {
        public static void WriteLine(string line, bool quiet = false)
        {
            if (!quiet)
            {
                Console.WriteLine(line);
            }
        }
    }
}