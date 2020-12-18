using System.IO;

namespace photoniced.device.interfaces.services
{
    public interface IDevicePathService
    { 
        static bool path_valid(string path) => false;

        static FileInfo get_file(string path) => null;
    }
}