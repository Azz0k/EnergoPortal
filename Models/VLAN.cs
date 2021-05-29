using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Models
{
    [Table("VLAN")]
    public class VLAN
    {
        [Key, Column("Id")]
        public int VLANId { get; set; }
        [StringLength(255)]
        public string FriendlyName { get; set; }
        [StringLength(255)]
        public string VLANName { get; set; }
        [StringLength(15)]
        public string SubNet { get; set; }
        public int isAllowedToDC { get; set;}
        public int isAllowedToBC { get; set; }

    }
}
