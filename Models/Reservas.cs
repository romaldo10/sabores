using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Sabores.Models
{
    public class Reservas
    {
        [Key]
        public int IdReservacion { get; set; }
        [Required(ErrorMessage = "Seleccione el restaurante")]
        public string Restaurante { get; set; }
        [Required(ErrorMessage = "Seleccione el tipo de actividad")]
        public string Actividad { get; set; }
        [Required(ErrorMessage = "Seleccione el tipo de mesa")]
        public string TipoMesa { get; set; }
        public bool Disponibilidad { get; set; }
        [Required(ErrorMessage = "Dato del cliente no deben estar vacio")]
        public string Cliente { get; set; }
        [Required(ErrorMessage = "Digite la cantidad de personas")]
        public int Personas { get; set; }
        public string Fecha { get; set; }
    }
}
