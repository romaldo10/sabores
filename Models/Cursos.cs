using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Sabores.Models
{
    public class Cursos
    {
        [Key]
        public int IdCurso { get; set; }
        [Required(ErrorMessage = "Escriba la descripcion del curso")]
        [MinLength(5, ErrorMessage = "Escriba almenos 5 carateres")]
        public string Descripcion { get; set; }
        [Required(ErrorMessage = "Dijite la categoria")]
        [MinLength(5, ErrorMessage = "Escriba almenos 5 carateres")]
        public string Categoria { get; set; }
        [Required(ErrorMessage = "Dijite horario")]
        [MinLength(5, ErrorMessage = "Escriba almenos 5 carateres")]
        public string Horario { get; set; }
        [Required(ErrorMessage = "Digite el precio")]
        public int Precio { get; set; }
    }
}
