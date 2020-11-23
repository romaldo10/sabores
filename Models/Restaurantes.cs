using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Sabores.Models
{
    public class Restaurantes
    {
        [Key]
        public int IdRestaurante { get; set; }
        [Required(ErrorMessage = "Escriba el nombre del restaurante")]
        [MinLength(5, ErrorMessage = "Escriba almenos 5 carateres")]
        public string Nombre { get; set; }
        [Required(ErrorMessage = "Dijite la ubicacion")]
        [MinLength(5, ErrorMessage = "Escriba almenos 5 carateres")]
        public string Ubicacion { get; set; }
        [Required(ErrorMessage = "Digite la cantidad de mesas")]
        public int Mesas { get; set; }
    }
}
