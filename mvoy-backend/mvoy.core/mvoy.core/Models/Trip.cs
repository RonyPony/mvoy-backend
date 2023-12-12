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
       
        public string OriginName { get; set; }
        public string DestinyName { get; set; }
        public string duration{ get; set; }
        public string distance { get; set; }
       
        public string leavingTime { get; set; }
       
        public string? driverId { get; set; }
        public Guid clientId { get; set; }
        public string? price { get; set; }
        public string arrivingTime { get; set; }
        public bool isDeleted { get; set; }
    }
}