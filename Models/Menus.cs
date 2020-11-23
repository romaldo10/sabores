using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Sabores.Models
{
    public class Menus
    {
        [Key]
        public int IdMenu { get; set; }
        [Required(ErrorMessage = "Escriba la descripcion")]
        [MinLength(5, ErrorMessage = "Escriba almenos 5 carateres")]
        public string Descripcion { get; set; }
        [Required(ErrorMessage = "Seleccione la categoria")]
        public string Categoria { get; set; }
        [Required(ErrorMessage = "Digite un precio")]
        public int Precio { get; set; }

    }
}
