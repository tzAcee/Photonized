using photoniced.common;
using photoniced.device.interfaces;
using photoniced.essentials;
using photoniced.essentials.commandline_parser.interfaces;

namespace photoniced.device
{
    public class DeviceReader : IDeviceReader
    {
        private ICommandLineParser _parser;
        public DeviceReader()
        {
            
        }

        public void set_parser(ICommandLineParser parser)
        {
            _parser = Required.NotNull(parser, nameof(parser));
        }
        
        public void read()
        {
            
        }
    }
}
