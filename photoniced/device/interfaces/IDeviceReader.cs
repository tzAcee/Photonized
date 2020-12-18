using System;
using System.Collections.Generic;
using System.Text;
using photoniced.essentials.commandline_parser.interfaces;

namespace photoniced.device.interfaces
{
    public interface IDeviceReader
    {
        public void set_parser(ICommandLineParser parser);
        public void read();
    }
}
