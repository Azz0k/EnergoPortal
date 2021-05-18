using System;
using System.Collections.Generic;

#nullable disable

namespace DBRepository
{
    public partial class Control
    {
        public int N { get; set; }
        public int Id { get; set; }
        public int? Scheme { get; set; }
        public string Controls { get; set; }
        public int? X { get; set; }
        public int? Y { get; set; }
        public string Name { get; set; }
        public bool? Enable { get; set; }
        public string Color { get; set; }
        public bool? Inuse { get; set; }
    }
}
