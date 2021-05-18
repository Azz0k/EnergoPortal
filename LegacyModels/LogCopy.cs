using System;
using System.Collections.Generic;

#nullable disable

namespace DBRepository
{
    public partial class LogCopy
    {
        public int Id { get; set; }
        public string Dt { get; set; }
        public string Log { get; set; }
        public string Thread { get; set; }
    }
}
