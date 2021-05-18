using System;
using System.Collections.Generic;

#nullable disable

namespace DBRepository
{
    public partial class InGet
    {
        public long Id { get; set; }
        public string Ip { get; set; }
        public string Mac { get; set; }
        public string DisplayLocal { get; set; }
        public string Local { get; set; }
        public string CallId { get; set; }
        public string DisplayRemote { get; set; }
        public string Remote { get; set; }
        public string Datatime { get; set; }
    }
}
