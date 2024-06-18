using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using mvoy.core.Enums;

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
        public DateTime createDate { get; set; }
        public string leavingTime { get; set; }
       public StatusTrip statusTrip { get; set; }
        public Guid? driverId { get; set; }
        public Guid clientId { get; set; }
        public string? price { get; set; }
        public Guid? selectedOfferPrice { get; set; }
        public string arrivingTime { get; set; }
        public bool isDeleted { get; set; }
    }
}