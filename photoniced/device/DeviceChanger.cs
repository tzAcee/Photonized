using photoniced.common;
using photoniced.device.interfaces;
using photoniced.essentials.commandline_parser.interfaces;

using System;
using System.IO;
using photoniced.essentials;
using photoniced.essentials.ConsoleUnitWrapper;

namespace photoniced.device
{
    public class DeviceChanger : IDeviceChanger
    {
        private ICommandLineParser _parser;
        private IConsole _Console;
        public DeviceChanger(IConsole console)
        {
            _Console = Required.NotNull(console, nameof(console));
        }

        public void set_parser(ICommandLineParser parser)
        {
            _parser = Required.NotNull(parser, nameof(parser));
        }

        public void change()
        {
            // TODO
            // Need Later work, works for now
            string path;
            try
            {
                _Console.Write("Paste your new path: ");
                path = _Console.ReadLine();
                Path.GetDirectoryName(path);
            }
            catch(Exception e)
            {
                path = "./";
            }

            _parser.DirPath = path;
            Console.Title = "Device mounted on " + Path.GetFullPath(path);
        }
    }
}