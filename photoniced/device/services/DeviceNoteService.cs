using System;
using System.Collections.Generic;
using System.IO;
using System.Threading;
using Newtonsoft.Json;
using photoniced.device.interfaces.services;
using photoniced.essentials;

namespace photoniced.device.services
{
    public class DeviceNoteService : IDeviceNoteService
    {
        private const string InfoFileName = ".photon.json";

        public static string get_file_path(string path, bool create = true)
        {
            string fullPath = path + "/" + InfoFileName;
            if (path == null) fullPath = null;  
            if (create == true)
            {
                if(!File.Exists(fullPath))
                    File.Create(fullPath).Dispose();
            }

            try
            {
                return DevicePathService.get_file(fullPath).FullName;
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                return null;
            }

        }

        public static void exclude_directory_delete(string path, string sort_word)
        {
            string dir_path = path + "/" + sort_word + "/";
            if (!Directory.Exists(dir_path))
                return;

            string[] entries = Directory.GetFileSystemEntries(dir_path, "*");
            foreach(var entry in entries)
            {
                try
                {
                    File.Move(entry, path + "/" + new FileInfo(entry).Name);
                }
                catch(Exception e)
                {
                    File.Delete(entry); // either auth exception or double file exception -> so delete (which follows another exception, when auth)
                    continue;
                }
            }
            Directory.Delete(dir_path);

        }

        public static void delete_entry(string path, DeviceUserEntry entry)
        {
            string filePath = get_file_path(path, false);
            var data = File.ReadAllText(filePath);
            var jsonListFile = JsonConvert.DeserializeObject<List<DeviceUserEntry>>(data);
            if (jsonListFile == null)
                jsonListFile = new List<DeviceUserEntry>();
            jsonListFile.Remove(entry);
            var convertedData = JsonConvert.SerializeObject(jsonListFile, Formatting.Indented);

            File.WriteAllText(filePath, convertedData);
        }
        
        public static void add_entry(string path, DeviceUserEntry entry)
        {
            string filePath = get_file_path(path);
            var data = File.ReadAllText(filePath);
            var jsonListFile = JsonConvert.DeserializeObject<List<DeviceUserEntry>>(data);
            if (jsonListFile == null)
                jsonListFile = new List<DeviceUserEntry>();
            jsonListFile.Add(entry);
            var convertedData = JsonConvert.SerializeObject(jsonListFile, Formatting.Indented);

            File.WriteAllText(filePath, convertedData);
            
        }

        public static List<DeviceUserEntry> read_entries(string path)
        {
            string filePath = get_file_path(path, false);
            if (filePath == null)
            {
                return null;
            }

            String data;
            try
            {
                data = File.ReadAllText(filePath);
            }
            catch(Exception e)
            {
                Console.WriteLine(e.ToString());
                return null;
            }
            
            var jsonListFile = JsonConvert.DeserializeObject<List<DeviceUserEntry>>(data);
            if (jsonListFile == null)
                jsonListFile = new List<DeviceUserEntry>();
            
            return jsonListFile;
        }
    }
}