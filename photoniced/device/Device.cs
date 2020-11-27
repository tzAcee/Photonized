using System;
using System.IO;
using photoniced.common;
using photoniced.essentials;
using photoniced.essentials.commandline_parser.repos;

namespace photoniced.device
{
    public class Device
    {
        public ICommandLineParserRepository CmdParser { get; }
        public Device(ICommandLineParserRepository cmdLineParser)
        {
            this.CmdParser = Requerd.NotNull(cmdLineParser, nameof(cmdLineParser));
        }

        public void read()
        {
            Console.WriteLine("OMEGA");
        }

        public void sort()
        {
            var a = Console.ReadLine();
        }

        public void change_device_path()
        { // Need Later work, works for now
            string path;
            try
            {
                Console.Write("Paste your new path: ");
                path = Console.ReadLine();
                Path.GetDirectoryName(path);
            }
            catch(Exception e)
            {
                path = "./";
            }

            CmdParser.DirPath = path;
            Console.Title = "Device mounted on " + Path.GetFullPath(path);
        }
    }
}
