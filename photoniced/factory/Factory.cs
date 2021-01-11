using photoniced.device;
using photoniced.ui;
using System;
using photoniced.device.interfaces;
using photoniced.essentials.commandline_parser.interfaces;
using photoniced.essentials;
using photoniced.interfaces;
using photoniced.essentials.ConsoleUnitWrapper;

namespace photoniced.factory
{
    public class Factory : IFactory
    {
        private static IConsole get_wrapper() => new ConsoleUnitWrapper();
        public static IDeviceChanger create_device_changer() => new DeviceChanger(get_wrapper());
        public static IDeviceSorter create_device_sorter() => new DeviceSorter(get_wrapper());
        public static IDeviceReader create_device_reader() => new DeviceReader(get_wrapper());
        public static Device create_device(ICommandLineParser parser,IDeviceReader reader, IDeviceSorter sorter, IDeviceChanger changer) 
            => new Device(parser, reader, sorter, changer);
        public static Menu create_menu(Device dev) => new Menu(dev);

        public static CommandLineParser create_cmd_parser(string[] args) => new CommandLineParser(args);
    }
}
