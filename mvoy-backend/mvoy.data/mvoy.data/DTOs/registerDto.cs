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
    public class RegisterDto
    {
        [Required]
        [Column("cedula", TypeName = "varchar(80)")]
        public string cedula { get; set; }
        [Required]
        [Column("email", TypeName = "varchar(80)")]
        public string email { get; set; }
        [Required]
        [Column("name", TypeName = "varchar(80)")]
        public string Name { get; set; }
        [Column("midName", TypeName = "varchar(80)")]
        public string middleName { get; set; }
        [Required]
        [Column("lastname")]
        public string lastname { get; set; }
        [Required]
        [Column("birthDate", TypeName = "varchar(80)")]
        public DateTime birthDate { get; set; }
        [Required]
        [Column("gender", TypeName = "char")]
        public Char gender { get; set; }
        [Required]
        [Column("phoneNumber", TypeName = "varchar(80)")]
        public string phoneNumber { get; set; }
        [Required]
        [Column("address", TypeName = "varchar(80)")]
        public string address { get; set; }
        [Required]
        [Column("relativeName", TypeName = "varchar(80)")]
        public string relativeName { get; set; }
        [Required]
        [Column("relativePhoneNumber", TypeName = "varchar(80)")]
        public string relativePhoneNumber { get; set; }

    }
}
