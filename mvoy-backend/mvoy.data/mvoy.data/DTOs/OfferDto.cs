using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace mvoy.data.DTOs
{
    public class OfferDto
    {
        public Guid ClientId { get; set; }

        public Guid motorcycleUserId { get; set; }
        public double price { get; set; }
    }
}
