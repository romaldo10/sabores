using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Sabores.Models;

namespace Sabores.Models
{
    public class SaboresCTX:DbContext
    {
        public SaboresCTX(DbContextOptions<SaboresCTX> options): base(options)
        {

        }

       protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<UsuarioRol>().HasKey(x => new { x.IdUsuario, x.IdRol });
        }
        public DbSet<Usuarios> Usuarios { get; set; }
        public DbSet<Roles> Roles { get; set; }
        public DbSet<UsuarioRol> UsuarioRol { get; set; }
        public DbSet<Sabores.Models.Menus> Menus { get; set; }
        public DbSet<Sabores.Models.Restaurantes> Restaurantes { get; set; }
        public DbSet<Sabores.Models.Cursos> Cursos { get; set; }
        public DbSet<Sabores.Models.Reservas> Reservas { get; set; }
     
    
    }
}
