using System;
using System.Collections.Generic;
using System.Text;
using photoniced.essentials.commandline_parser.repos;
using photoniced.essentials.commandline_parser;
using CommandLine;
using System.IO;

namespace photoniced.essentials
{
    public class CommandLineParser : ICommandLineParserRepository
    {
        public string DirPath { get; set; }
        public CommandLineParser(string[] args)
        {
            parse(args);
        }


        private string default_path() => "./";

        public void parse(string[] args)
        {
            Parser.Default.ParseArguments<CommandLineOptions>(args)
                   .WithParsed<CommandLineOptions>(o =>
                   {
                       if (o._Path != null)
                       {
                           try
                           {
                               Path.GetDirectoryName(o._Path);
                               this.DirPath = o._Path;
                           }
                           catch (Exception e)
                           {
                               this.DirPath = default_path();
                           }
                       }
                       else
                           this.DirPath = default_path();
                   });
        }
    }
}
