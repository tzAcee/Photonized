using photoniced.essentials;
using System;
using System.Collections.Generic;
using System.Text;

namespace photoniced.device.interfaces.repos
{
    public interface IDeviceReaderRepository
    {
        public List<DeviceUserEntry> read_entries(string path);
    }
}
