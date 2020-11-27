using photoniced.device;
using photoniced.ui;
using System;
using photoniced.essentials.commandline_parser.repos;
using photoniced.essentials;

namespace photoniced.factory
{
    public class Factory : IFactory
    {
        public static Device create_device(CommandLineParser cmdparser) => new Device(cmdparser);
        public static Menu create_menu(Device dev) => new Menu(dev);

        public static CommandLineParser create_cmd_parser(string[] args) => new CommandLineParser(args);
    }
}
