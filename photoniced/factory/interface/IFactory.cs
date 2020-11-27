using photoniced.device;
using photoniced.ui;
using System;
using photoniced.essentials;

namespace photoniced.factory
{
    public interface IFactory
    {
            static Device create_device() => throw new NotImplementedException();
            static Menu create_menu() => throw new NotImplementedException();
            static CommandLineParser create_cmd_parser() => throw new NotImplementedException();
    }
}
