using photoniced.common;
using photoniced.device.interfaces;
using photoniced.essentials.commandline_parser.interfaces;

using System;
using System.IO;
using photoniced.essentials;

namespace photoniced.device
{
    public class DeviceChanger : IDeviceChanger
    {
        private ICommandLineParser _parser;
        
        public DeviceChanger()
        {

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
                Console.Write("Paste your new path: ");
                path = Console.ReadLine();
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