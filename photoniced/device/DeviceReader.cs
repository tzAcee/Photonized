using System;
using System.Collections.Generic;
using System.IO;
using photoniced.common;
using photoniced.device.interfaces;
using photoniced.device.services;
using photoniced.essentials;
using photoniced.essentials.commandline_parser.interfaces;
using photoniced.essentials.path_tree;

namespace photoniced.device
{
    public class DeviceReader : IDeviceReader
    {
        private ICommandLineParser _parser;
        public DeviceReader()
        {
            
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
            
            Console.Clear();
            Console.WriteLine("Device Structure: (Any Key to continue)");
            NodePrinter.print_tree(tree, "", true);
            Console.ReadLine();
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

        public void print_read_info()
        {
            var entries = DeviceNoteService.read_entries(_parser.DirPath);
            if (entries.Count == 0)
            {
                Console.Clear();
                Console.WriteLine("No Entries... (Any Key to continue)");
                Console.ReadLine();
                return;
            }
            compare(entries);
            Console.Clear();
            Console.WriteLine("Found Entries for this Structure: (Any Key to continue)");
            Console.WriteLine("-*********************-");
            int index = 0;
            foreach (var entry in entries)
            {
                index++;
                Console.WriteLine("- Sorted After: "+entry.SortWord+" | Sorted For: "+entry.SortTime.Date);
                Console.WriteLine("- Description:");
                Console.WriteLine("- "+entry.Description);
                if (index != entries.Count ) 
                    Console.WriteLine("-----------------------");
            }
            Console.WriteLine("-*********************-");
            
            Console.ReadLine();
        }
    }
}
