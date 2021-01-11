
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

        public DeviceUserEntry get_user_entry()
        {
            _Console.WriteLine("For which day you want to sort the pictures? (DD/MM/YYYY)");
            string date = _Console.ReadLine();
            var dateSplitted = date.Split('/');
            if (dateSplitted.Length != 3)
            {
                //return new DeviceUserEntry();
                throw new InvalidDataException();
            }
            
            _Console.WriteLine("What did you do @ this day?");
            string toSort = _Console.ReadLine();
            
            Console.WriteLine("Give a little description for this day.");
            string desc = _Console.ReadLine();

            DateTime parsedTime = new DateTime(Convert.ToInt32(dateSplitted[2]), Convert.ToInt32(dateSplitted[1]),
                Convert.ToInt32(dateSplitted[0]));
            return new DeviceUserEntry(toSort, desc, parsedTime);
        }

        public void sort()
        {
            DeviceUserEntry entry = get_user_entry();

            //TODO check for parser for all modules
            var files = Directory.EnumerateFiles(_parser.DirPath, "*.*") // Remove/Add SearchOption if dont need to resort
                .Where(s => s.EndsWith(".png") || s.EndsWith(".jpg") || s.EndsWith(".tif"));

            if (files.Count() == 0)
                return;
            var sortPath = Directory.CreateDirectory(_parser.DirPath+"/"+entry.SortWord);
            
            //TODO dont use index wtf
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
                    File.Move(curFile.FullName, sortPath+"/"+curFile.Name);
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