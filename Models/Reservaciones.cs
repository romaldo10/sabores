using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Sabores.Models
{
    public class Reservaciones
    {
        [Key]
        public int IdReservacion { get; set; }
        [Required(ErrorMessage = "Escriba el detalle de la reservacion")]
        [MinLength(10, ErrorMessage = "Escriba almenos 10 carateres")]
        public string Reserva { get; set; }
        [Required(ErrorMessage = "Dijite la categoria")]
        [MinLength(5, ErrorMessage = "Escriba almenos 5 carateres")]
        public string Categoria { get; set; }
        [Required(ErrorMessage = "Dijite el restaurante")]
        [MinLength(5, ErrorMessage = "Escriba almenos 5 carateres")]
        public string Restaurante { get; set; }
        [Required(ErrorMessage = "Digite la cantidad de mesas a reservar")]
        public int Mesas { get; set; }
        [Required(ErrorMessage = "Digite el monto")]
        public int Monto { get; set; }
    }
}
