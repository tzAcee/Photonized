using photoniced.common;
using photoniced.device.interfaces;
using photoniced.essentials;
using photoniced.essentials.commandline_parser.interfaces;
using photoniced.interfaces;

namespace photoniced.device
{
    public class Device
    {
        public ICommandLineParser CmdParser { get; }

        private readonly IDeviceReader _reader;
        private readonly IDeviceSorter _sorter;
        private readonly IDeviceChanger _changer;

        public Device(ICommandLineParser parser, IDeviceReader deviceReader, IDeviceSorter deviceSorter, IDeviceChanger deviceChanger)
        {   
            //TODO OWN Factory pls
            CmdParser = Required.NotNull(parser, nameof(parser));
            _reader = Required.NotNull(deviceReader, nameof(deviceReader));
            _sorter = Required.NotNull(deviceSorter, nameof(deviceSorter));
            _changer = Required.NotNull(deviceChanger, nameof(deviceChanger));
            init_modules();
        }

        private void init_modules()
        {
            _reader.set_parser(CmdParser);
            _sorter.set_parser(CmdParser);
            _changer.set_parser(CmdParser);
        }

        public void read()
        {
            _reader.read();
        }

        public void sort()
        {
            _sorter.sort();
        }

        public void change_device_path()
        { 
            _changer.change();
        }

        public void delete()
        {
            _reader.delete();
        }
    }
}
