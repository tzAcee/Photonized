using System;
using System.IO;

namespace photoniced.essentials
{
    public struct DeviceUserEntry
    {
        public DeviceUserEntry(string name, string desc, DateTime time)
        {
            if (name == "" || desc == "" || time == new DateTime())
            {
                throw new InvalidDataException();
            }
            SortWord = name;
            Description = desc;
            SortTime = time;
        }
        
        public string SortWord { get; }
        public string Description { get; }
        public DateTime SortTime { get; }
    }
}