using Newtonsoft.Json;
using photoniced.device.interfaces.repos;
using photoniced.device.services;
using photoniced.essentials;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace photoniced.device.repos
{
    public class DeviceReaderRepository : IDeviceReaderRepository
    {
        public List<DeviceUserEntry> read_entries(string path)
        {
            string filePath = DeviceNoteService.get_file_path(path, false);
            if (filePath == null)
            {
                return null;
            }

            String data;
            try
            {
                data = File.ReadAllText(filePath);
            }
            catch (Exception e)
            {
                if(e.GetType().IsAssignableFrom(typeof(System.IO.FileNotFoundException)))
                {
                    Console.WriteLine("No Entries found.");
                }
                else
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
