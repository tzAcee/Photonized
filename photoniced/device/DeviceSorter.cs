
using System;
using System.IO;
using System.Linq;
using photoniced.essentials.commandline_parser.interfaces;
using photoniced.common;
using photoniced.device.services;
using photoniced.essentials;
using photoniced.essentials.path_tree;
using photoniced.interfaces;
using photoniced.essentials.ConsoleUnitWrapper;

namespace photoniced.device
{
    public class DeviceSorter : IDeviceSorter
    {
        private ICommandLineParser _parser;

        private IConsole _Console;

        public DeviceSorter(IConsole console)
        {
            _Console = Required.NotNull(console, nameof(console));
        }
        
        public void set_parser(ICommandLineParser parser)
        {
            _parser = Required.NotNull(parser, nameof(parser));
        }


        public void sort()
        {
            DeviceUserEntry entry = UserInputService.get_user_entry(_Console);
            if(entry.Equals(default(DeviceUserEntry)))
            {
                return;
            }

            //TODO check for parser for all modules
            var files = Directory.EnumerateFiles(_parser.DirPath, "*.*") // Remove/Add SearchOption if dont need to resort
                .Where(s => s.EndsWith(".png") || s.EndsWith(".jpg") || s.EndsWith(".tif"));

            if (files.Count() == 0)
                return;
            var sortPath = Directory.CreateDirectory(Path.Combine(_parser.DirPath, entry.SortWord));
            
            int index = 0;
            
            foreach(var file in files)
            {
                FileInfo curFile = DevicePathService.get_file(file);
                if (!(entry.SortTime.Year == curFile.CreationTime.Year && 
                      entry.SortTime.Day == curFile.CreationTime.Day && 
                      entry.SortTime.Month == curFile.CreationTime.Month))
                    continue;
                try
                {
                    System.IO.File.Move(curFile.FullName, Path.Combine(sortPath.FullName ,curFile.Name));
                    index++;
                }
                catch (Exception e)
                {
                    Console.WriteLine(e);
                    throw;
                }
            }

            if (index == 0)
            {
                Directory.Delete(sortPath.FullName);
                _Console.WriteLine("No entries with this creation date found.");
                _Console.ReadLine();
            }
            else
            {
                DeviceNoteService.add_entry(_parser.DirPath, entry);
                var tree = new Node(_parser.DirPath);
                
                _Console.Clear();
                _Console.WriteLine("Your new Structure! Press Any Key to proceed.");
                _Console.WriteLine("");
                NodePrinter.print_tree(tree, "", true);
                _Console.ReadLine();
            }
        }
    }
}