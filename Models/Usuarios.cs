using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Sabores.Models
{
   [Table("Usuarios")]
    public partial class Usuarios
    {
        [Key]
        public int IdUsuario { get; set; }
        [Required(ErrorMessage ="Escriba el nombre de usuario")]
        [MinLength(5,ErrorMessage ="Escriba almenos 5 carateres")]
        [MaxLength(50, ErrorMessage = "Escriba menos de 60 carateres")]
        public string Nombre { get; set; }
        public string Sal { get; set; }
        [Required(ErrorMessage = "Escriba la contraseña de usuario")]
        [MinLength(5, ErrorMessage = "Escriba almenos 5 carateres")]
        [MaxLength(50, ErrorMessage = "Escriba menos de 50 carateres")]
        public string Clave { get; set; }
        [ForeignKey("IdUsuario")]
        public virtual List<UsuarioRol> Roles { get; set; }
    }
}
