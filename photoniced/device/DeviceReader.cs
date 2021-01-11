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

        public void delete()
        {
            var entries = DeviceNoteService.read_entries(_parser.DirPath);
            if (entries == null)
            {
                Console.WriteLine("No Entries found.");
                Console.ReadLine();
                return;
            }
            if (entries.Count == 0)
            {
                Console.Clear();
                Console.WriteLine("No Entries... (Any Key to continue)");
                Console.ReadLine();
                return;
            }
            compare(entries);
            Console.Write("What is the name of the entry you want to delete? ");
            var name = Console.ReadLine();
            var item = entries.Find(x => x.SortWord == name);
            if(item.SortWord == null)
            {
                Console.WriteLine("No entry found.");
                Console.ReadLine();
                return;
            }

            Console.Write("Entry " + item.SortWord + " found, wish to delete it? y/N: ");
            var inp = Console.ReadLine();
            if(inp.ToUpper() == "Y")
            {
                DeviceNoteService.delete_entry(_parser.DirPath, item);
                Console.WriteLine("Want also to exclude the sorted data & delete the created directory for the entry? Y/n: ");
                inp = Console.ReadLine();
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
            var entries = DeviceNoteService.read_entries(_parser.DirPath);
            if (entries == null)
            {
                Console.ReadLine();
                return;
            }
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
