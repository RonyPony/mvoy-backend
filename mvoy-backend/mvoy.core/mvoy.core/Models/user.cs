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
        [Table("users")]
        public class User
        {        
            [Key]
            public Guid Id { get; set; }
            public int contactInfoId { get; set; }
            public bool isDriver { get; set; }
            [Required]
            [Column("cedula",TypeName ="varchar(80)")]
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
            public string lastname{ get; set; }
            [Required]
            [Column("lastname2")]
            public string lastname2 { get; set; }
            [Required]
            [Column("birthDate", TypeName = "varchar(80)")]
            public String birthDate { get; set; }
            [Required]
            [Column("gender", TypeName = "char")]
            public Char gender { get; set; }
            [Required]
            [Column("creationDate", TypeName = "varchar(80)")]        
            public DateTime CreationDate { get; set; }        
            public bool IsDeleted { get; set; }
            [Required]
            [Column("userType", TypeName = "varchar(80)")]
            public UserType UserKind { get; set; }
    }
    
}
