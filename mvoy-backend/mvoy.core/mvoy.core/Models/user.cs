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
        [Table("users")]
        public class User
        {        
            [Key]
            public Guid Id { get; set; }
            [Required]
            [Column("cedula",TypeName ="varchar(80)")]
            public string cedula { get; set; }
            [Required]
            [Column("name", TypeName = "varchar(80)")]
            public string Name { get; set; }
            [Required]
            [Column("lastname")]
            public string lastname{ get; set; }
        [Required]
            [Column("creationDate", TypeName = "varchar(80)")]        
        public DateTime CreationDate;
        [Required]
            [Column("isDeleted", TypeName = "binary")]
            public bool IsDeleted;

    }
    
}
