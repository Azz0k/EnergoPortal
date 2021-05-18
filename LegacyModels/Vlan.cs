using System;
using System.Collections.Generic;

#nullable disable

namespace DBRepository
{
    public partial class Vlan
    {
        public string Vlan1 { get; set; }
        public string Name { get; set; }
        public string VlanName { get; set; }
        public string IpLan { get; set; }
        public bool? AccessDc { get; set; }
        public bool? AccessBc { get; set; }
    }
}
