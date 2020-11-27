using System;
using System.Collections.Generic;
using System.Text;

namespace photoniced.essentials.commandline_parser.repos
{
    public interface ICommandLineParserRepository
    {
        string DirPath { get; set; }
        void parse(string[] path);
    }
}
