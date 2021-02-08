using photoniced.device;
using photoniced.ui;
using System;
using photoniced.essentials;
using photoniced.essentials.commandline_parser.interfaces;

namespace photoniced.factory
{
    public interface IFactory
    {
            public Menu Menu {get; set;}
            public ICommandLineParser CmdParser { get; set; }
            public Device Device { get; set; } 
    }
}
