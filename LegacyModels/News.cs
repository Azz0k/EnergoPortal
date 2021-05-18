using System;
using System.Collections.Generic;

#nullable disable

namespace DBRepository
{
    public partial class News
    {
        public int Id { get; set; }
        public DateTime? Data { get; set; }
        public string Title { get; set; }
        public string Content { get; set; }
    }
}
