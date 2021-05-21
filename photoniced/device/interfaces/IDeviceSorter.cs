using photoniced.essentials;
using photoniced.essentials.commandline_parser.interfaces;

namespace photoniced.interfaces
{
    public interface IDeviceSorter
    {
        public void set_parser(ICommandLineParser parser);
        public void sort();

     //   public DeviceUserEntry get_user_entry();
    }
}