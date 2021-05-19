using System;
using System.Collections.Generic;
using System.IO;
using photoniced.common;
using photoniced.device.interfaces;
using photoniced.device.interfaces.repos;
using photoniced.device.repos;
using photoniced.device.services;
using photoniced.essentials;
using photoniced.essentials.commandline_parser.interfaces;
using photoniced.essentials.ConsoleUnitWrapper;
using photoniced.essentials.path_tree;

namespace photoniced.device
{
    public class DeviceReader : IDeviceReader
    {
        private ICommandLineParser _parser;
        private IDeviceReaderRepository _repo = new DeviceReaderRepository();
        private IConsole _Console;
        public DeviceReader(IConsole console)
        {
            _Console = Required.NotNull(console, nameof(console));
        }

        public void set_parser(ICommandLineParser parser)
        {
            _parser = Required.NotNull(parser, nameof(parser));
        }
        
        public void read()
        {
            print_structure();
            print_read_info();
        }

        public void print_structure()
        {
            var tree = new Node(_parser.DirPath);
            
            _Console.Clear();
            _Console.WriteLine("Device Structure: (Any Key to continue)");
            NodePrinter.print_tree(tree, "", true);
            _Console.ReadLine();
        }

        public void compare(List<DeviceUserEntry> entries)
        {
            string[] paths = Directory.GetDirectories(_parser.DirPath);
 
            foreach(var entry in entries)
            {
                bool found = false;
                foreach (var p in paths)
                {
                    var info = new DirectoryInfo(p).Name;
                    if (entry.SortWord == info)
                    {
                        found = true;
                    }
                }
                if(found == false)
                    DeviceNoteService.delete_entry(_parser.DirPath, entry);
            }
        }

        public void delete()
        {
            var entries = _repo.read_entries(_parser.DirPath);
            if (entries == null)
            {
                _Console.WriteLine("No Entries found.");
                _Console.ReadLine();
                return;
            }
            if (entries.Count == 0)
            {
                _Console.Clear();
                _Console.WriteLine("No Entries... (Any Key to continue)");
                _Console.ReadLine();
                return;
            }
            compare(entries);
            _Console.Write("What is the name of the entry you want to delete? ");
            var name = _Console.ReadLine();
            var item = entries.Find(x => x.SortWord == name);
            if(item.SortWord == null)
            {
                _Console.WriteLine("No entry found.");
                _Console.ReadLine();
                return;
            }

            _Console.Write("Entry " + item.SortWord + " found, wish to delete it? y/N: ");
            var inp = _Console.ReadLine();
            if(inp.ToUpper() == "Y")
            {
                DeviceNoteService.delete_entry(_parser.DirPath, item);
                _Console.WriteLine("Want also to exclude the sorted data & delete the created directory for the entry? Y/n: ");
                inp = _Console.ReadLine();
                if (inp.ToUpper() == "N")
                {
                    return;
                }
                else
                    DeviceNoteService.exclude_directory_delete(_parser.DirPath, item.SortWord);

            }
            else
            {
                return;
            }

        }

        public void print_read_info()
        {
            var entries = _repo.read_entries(_parser.DirPath);
            if (entries == null)
            {
                _Console.ReadLine();
                return;
            }
            if (entries.Count == 0)
            {
                _Console.Clear();
                _Console.WriteLine("No Entries... (Any Key to continue)");
                _Console.ReadLine();
                return;
            }
            compare(entries);
            _Console.Clear();
            _Console.WriteLine("Found Entries for this Structure: (Any Key to continue)");
            _Console.WriteLine("-*********************-");
            int index = 0;
            foreach (var entry in entries)
            {
                index++;
                _Console.WriteLine("- Sorted After: "+entry.SortWord+" | Sorted For: "+entry.SortTime.Date);
                _Console.WriteLine("- Description:");
                _Console.WriteLine("- "+entry.Description);
                if (index != entries.Count ) 
                    _Console.WriteLine("-----------------------");
            }
            _Console.WriteLine("-*********************-");
            
            _Console.ReadLine();
        }
    }
}
