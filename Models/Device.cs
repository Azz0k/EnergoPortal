using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Models
{
    [Table("Device")]
    public class Device
    {
        [Key, Column("Id"), DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int DeviceId { get; set; }
        [Column("LevelNumber")]
        public int LevelId { get; set; }
        public int PosX { get; set; }
        public int PosY { get; set; }
        public int IsEnabled { get; set; }
        public int IsInUse { get; set; }
        [StringLength(15)]
        public string Color { get; set; }
        [StringLength(255)]
        public string SocketNumber { get; set; }
        [StringLength(255)]
        public string SwitchName { get; set; }
        [StringLength(255)]
        public string SwitchPort { get; set; }
        [StringLength(15)]
        public string IpAddress { get; set; }
        [StringLength(17)]
        public string MacAddress { get; set; }
        [StringLength(255)]
        public string DeviceName { get; set; }
        [StringLength(255)]
        public string PhoneSocketNumber { get; set; }
        [StringLength(25)]
        public string PBXPortNumber { get; set; }
        [StringLength(25)]
        public string PhoneNumber { get; set; }
        [StringLength(255)]
        public string PhoneId { get; set; }
        [StringLength(255)]
        public string FirstName { get; set; }
        [StringLength(255)]
        public string LastName { get; set; }

        [StringLength(255)]
        public string MiddleName { get; set; }
        [StringLength(255)]
        public string LoginName { get; set; }
        [StringLength(255)]
        public string MailAddress { get; set; }
        [StringLength(255)]
        public string Type { get; set; }
        [StringLength(255)]
        public string Location { get; set; }
        [Column(TypeName ="text")]
        public string Memo { get; set; }

    }
}
