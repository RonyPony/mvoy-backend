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
    public class UserDto
    {
        [Column("cedula", TypeName = "varchar(80)")]
        public string cedula { get; set; }
        [Required]
        [Column("name", TypeName = "varchar(80)")]
        public string Name { get; set; }
        [Required]
        [Column("lastname")]
        public string lastname { get; set; }
    }
}
