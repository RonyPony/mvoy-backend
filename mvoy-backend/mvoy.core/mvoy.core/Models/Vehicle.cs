using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace mvoy.core.Models
{
    [Table("vehicles")]
    public class Vehicle
    {
        [Key]
        public Guid Id { get; set; }
        public Guid ownerId { get; set; }

        [Required]
        [Column("licencia", TypeName = "varchar(80)")]
        public string license { get; set; }
        [Required]
        [Column("seguro", TypeName = "varchar(80)")]
        public string seguro { get; set; }
        [Required]
        [Column("chasis", TypeName = "varchar(80)")]
        public string chasis { get; set; }
        [Required]
        [Column("placa", TypeName = "varchar(80)")]
        public string placa { get; set; }
        [Required]
        [Column("color", TypeName = "varchar(80)")]
        public string color { get; set; }
        [Required]
        [Column("marca", TypeName = "varchar(80)")]
        public string marca { get; set; }
        [Required]
        [Column("modelo", TypeName = "varchar(80)")]
        public string modelo { get; set; }
        [Required]
        [Column("hasinsurance", TypeName = "varchar(80)")]
        public bool tieneSeguro { get; set; }
        [Required]
        [Column("year", TypeName = "varchar(80)")]
        public string year { get; set; }
    }
}
