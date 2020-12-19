using System;
using System.IO;
using photoniced.essentials;

namespace photoniced.device.interfaces.services
{
    public interface IDeviceNoteService
    {
        public static string get_file_path(string path) => null;
        public static void add_entry(string path, DeviceUserEntry entry) => throw new NotImplementedException();
    }
}