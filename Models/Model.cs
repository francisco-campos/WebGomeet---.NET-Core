using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;

namespace WebGomeet.Models
{
    public class GoMeetContext : DbContext
    {
        public DbSet<Usuario> Usuarios { get; set; }
        public DbSet<Institucion> Intituciones { get; set; }
        public DbSet<Plan> Planes { get; set; }
        
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            string connection = @"Server=10.211.55.4;Database=gomeet_test;User Id=gomeet;Password=1234567;";
            optionsBuilder.UseSqlServer(connection);

        }
        
    }
    
    public class Usuario
    {
        public int UsuarioId {get; set;}
        public string Nombre { get; set; }
        public string Email { get; set; }
        public string Clave { get; set; }

        public int InstitucionId { get; set; }
        public Institucion Institucion { get; set; }
    }

    public class Institucion
    {
        public int InstitucionId { get; set; }
        public string Nombre { get; set; }
        public string Email { get; set; }
        public string Logo { get; set; }
        public string FulllUrl { get; set; }

        public List<Usuario> Usuarios { get; set; }

        public int PlanId { get; set; }
        public Plan Plan { get; set; }
    }

    public class Plan
    {
        public int PlanId { get; set; }
        public string Nombre { get; set; }
    }
}