using System;
using CommandLine;

namespace photoniced.essentials.commandline_parser
{
    public class CommandLineOptions
    {
        [Option('p', "path", Required = false, HelpText = "Set your path for image sorting.")]
        public string _Path { get; set; }
    }
}
