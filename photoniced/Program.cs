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
            CommandLineParser CommandLineParser = Factory.create_cmd_parser(args);
            Device MainDevice = Factory.create_device(CommandLineParser);
            Menu MainMenu = Factory.create_menu(MainDevice);
        }
    }
}
