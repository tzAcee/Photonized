using System;
using System.Collections.Generic;
using System.Text;
using photoniced.essentials;
using photoniced.essentials.commandline_parser.interfaces;

namespace photoniced.device.interfaces
{
    public interface IDeviceReader
    {
        public void set_parser(ICommandLineParser parser);
        public void print_structure();
        public void print_read_info();

        public void delete();

        public void compare(List<DeviceUserEntry> entries);
        public void read();
    }
}
