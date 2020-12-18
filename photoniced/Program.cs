using photoniced.device;
using photoniced.factory;
using photoniced.ui;
using photoniced.essentials;

namespace photoniced
{
    class Program
    {
        static void Main(string[] args)
        {
            CommandLineParser commandLineParser = Factory.create_cmd_parser(args);
            Device mainDevice = Factory.create_device(commandLineParser, Factory.create_device_reader(),
                Factory.create_device_sorter(),
                Factory.create_device_changer());
            Menu mainMenu = Factory.create_menu(mainDevice);
        }
    }
}
