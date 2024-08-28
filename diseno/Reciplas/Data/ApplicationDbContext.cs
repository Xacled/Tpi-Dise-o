using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore; 
using Reciplas.Models;

namespace Reciplas.Clases
{
    public class ApplicationDbContext : DbContext{
         
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options){
        }

        public virtual DbSet<Cliente> Clientes {get; set;} = null!;
        public virtual DbSet<Turno> Turnos {get; set;} = null!; 
        public virtual DbSet<Vehiculo> Vehiculos {get; set;} = null!;

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // Configuraci�n de la relaci�n entre Turno y Cliente
            modelBuilder.Entity<Turno>()
                .HasOne(t => t.cliente)       // Un Turno tiene un Cliente
                .WithMany(c => c.Turnos)      // Un Cliente tiene muchos Turnos
                .HasForeignKey(t => t.ClienteId); // La clave for�nea en Turno es ClienteId
        }
    }
}