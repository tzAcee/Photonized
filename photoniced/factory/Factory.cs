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
        public Menu Menu { get; set; }
        public Device Device { get; set; }
        public ICommandLineParser CmdParser { get; set; }
    
        public Factory(string[] args)
        {
            var wrapper = create_wrapper();
            CmdParser = create_cmd_parser(args);
            Device = create_device(CmdParser, create_device_reader(wrapper), create_device_sorter(wrapper), create_device_changer(wrapper));
            Menu = create_menu(Device);
        }

        private  IConsole create_wrapper() => new ConsoleUnitWrapper();
        private  IDeviceChanger create_device_changer(IConsole wrapper) => new DeviceChanger(wrapper);
        private  IDeviceSorter create_device_sorter(IConsole wrapper) => new DeviceSorter(wrapper);
        private  IDeviceReader create_device_reader(IConsole wrapper) => new DeviceReader(wrapper);
        private Device create_device(ICommandLineParser parser,IDeviceReader reader, IDeviceSorter sorter, IDeviceChanger changer) 
            => new Device(parser, reader, sorter, changer);
        private Menu create_menu(Device dev) => new Menu(dev);
        private CommandLineParser create_cmd_parser(string[] args) => new CommandLineParser(args);
    }
}
