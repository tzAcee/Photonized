using System;
using System.Collections.Generic;
using photoniced.essentials;

namespace photoniced.device.interfaces.services
{
    public interface IDeviceNoteService
    {
        public static string get_file_path(string path, bool create = true) => null;
        public static void add_entry(string path, DeviceUserEntry entry) => throw new NotImplementedException();
        public static void delete_entry(string path, DeviceUserEntry entry) => throw new NotImplementedException();
        public static List<DeviceUserEntry> read_entries(string path) => null;
    }
}