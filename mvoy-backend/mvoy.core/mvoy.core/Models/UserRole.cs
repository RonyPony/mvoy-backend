using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace mvoy.core.Models
{
    public class UserRole
    {
        [Key]
        public Guid Id { get; set; }
        [Required]
        public string roleName { get; set; }
        [Required]
        public bool deleted { get; set; }
    }
}
