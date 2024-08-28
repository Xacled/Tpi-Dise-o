
using Microsoft.EntityFrameworkCore;

namespace Reciplas.Models;
public class Cliente
{
    public int Id { get; set; }
    public string NombreyApellido {get; set;}
    public string DNI {get; set;}   
    public string Telefono {get; set;}    
    public DateTime FechadeNacimiento { get; set; }

    public Vehiculo vehiculo = new Vehiculo();
    public int VehiculoId { get; set; } // Clave foránea

    public ICollection<Turno> Turnos { get; set; } = new List<Turno>(); // Propiedad de navegación inversa

}

