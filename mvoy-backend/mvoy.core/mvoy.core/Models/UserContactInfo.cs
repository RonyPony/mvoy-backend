using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace mvoy.core.Models
{
    public class UserContactInfo
    {
        [Key]
        public int Id { get; set; }
        public string phoneNumber { get; set; }
        public string address { get; set; }
        public string relativeName { get; set; }
        public string relativePhoneNumber { get; set; }
        public bool isDeleted { get; set; }
        public DateTime Created { get; set; } = DateTime.Now;
    }
}
