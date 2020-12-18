using photoniced.essentials.commandline_parser.interfaces;

namespace photoniced.device.interfaces
{
    public interface IDeviceChanger
    {
        public void set_parser(ICommandLineParser parser);
        public void change();
    }
}