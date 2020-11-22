using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Sabores.Models
{
    [Table("Roles")]
    public class Roles
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.None),Column("IdRol")]
        public int IdRol { get; set; }
        public string Descripcion { get; set; }
    }
}
