using System;
using System.Collections.Generic;

#nullable disable

namespace DBRepository
{
    public partial class Freedisk
    {
        public long Npp { get; set; }
        public string Server { get; set; }
        public string DriveLetter { get; set; }
        public string FileSystem { get; set; }
        public long? Capacity { get; set; }
        public long? FreeSpace { get; set; }
        public string Dt { get; set; }
    }
}
