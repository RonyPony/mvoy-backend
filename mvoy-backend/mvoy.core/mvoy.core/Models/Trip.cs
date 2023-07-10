using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace mvoy.core.Models
{
    public class Trip
    {
        [Key]
        public Guid Id { get; set; }
        [Column("OriginName", TypeName = "varchar(80)")]
        public string OriginName { get; set; }
        [Column("DestinyName", TypeName = "varchar(80)")]
        public string DestinyName { get; set; }
        public double duration{ get; set; }
        public double distance { get; set; }
        [Column("leavingTime", TypeName = "varchar(80)")]
        public string leavingTime { get; set; }
        [Column("driverId", TypeName = "varchar(80)")]
        public Guid driverId{ get; set; }
        public string price { get; set; }
        public string arrivingTime { get; set; }
        public bool isDeleted { get; set; }
    }
}