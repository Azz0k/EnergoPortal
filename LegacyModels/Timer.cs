using System;
using System.Collections.Generic;

#nullable disable

namespace DBRepository
{
    public partial class Timer
    {
        public int Id { get; set; }
        public int? Hh { get; set; }
        public int? Mm { get; set; }
        public string Run { get; set; }
    }
}
