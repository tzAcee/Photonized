using System.Collections.Generic;
using System.IO;
using Newtonsoft.Json;
using photoniced.device.interfaces.services;
using photoniced.essentials;

namespace photoniced.device.services
{
    public class DeviceNoteService : IDeviceNoteService
    {
        private const string InfoFileName = ".photon.json";

        private static string get_file_path(string path)
        {
            string fullPath = path + "/" + InfoFileName;
            File.Create(fullPath).Dispose();

            return DevicePathService.get_file(path + "/" + InfoFileName).FullName;
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
    }
}