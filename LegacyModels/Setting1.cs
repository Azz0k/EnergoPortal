using System;
using System.Collections.Generic;

#nullable disable

namespace DBRepository
{
    public partial class Setting1
    {
        public int Id { get; set; }
        public long? WorkOk { get; set; }
        public long? WorkError { get; set; }
        public string Dt { get; set; }
    }
}
