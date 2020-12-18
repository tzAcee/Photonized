

namespace photoniced.essentials.commandline_parser.interfaces
{
    public interface ICommandLineParser
    {
        string DirPath { get; set; }
        void parse(string[] path);
    }
}
