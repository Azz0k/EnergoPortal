using System;
using System.Collections.Generic;

#nullable disable

namespace DBRepository
{
    public partial class CiscoVpn
    {
        public long Id { get; set; }
        public string User { get; set; }
        public string Ip { get; set; }
        public string DateIn { get; set; }
        public string DateOut { get; set; }
        public int? St { get; set; }
    }
}
