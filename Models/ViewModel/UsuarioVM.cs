using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Sabores.Models.ViewModel
{
    public class UsuarioVM
    {
        [Required(ErrorMessage = "Escriba su nombre de usuario")]
        public string Nombre { get; set; }
        [Required(ErrorMessage = "Escriba su contraseña de usuario")]
        public string Clave { get; set; }
    }
}
