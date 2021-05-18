using System;
using System.Collections.Generic;

#nullable disable

namespace DBRepository
{
    public partial class Log
    {
        public int Id { get; set; }
        public string Dt { get; set; }
        public string Log1 { get; set; }
        public string Thread { get; set; }
    }
}
