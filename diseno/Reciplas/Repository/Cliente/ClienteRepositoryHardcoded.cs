using Reciplas.Models;
using System.Collections.Generic;
using System.Linq;
using Reciplas.Models;
using System.Collections.Generic;

public interface IClienteRepository
{
    List<Cliente> GetAllClientes();
    Cliente GetClienteById(int id);
}
public class ClienteRepositoryHardcoded : IClienteRepository
{
    private static List<Cliente> clientes = new List<Cliente>
    {
        new Cliente { Id = 1, NombreyApellido = "Juan Perez", DNI = "12345678", Telefono = "111-222-3333" },
        new Cliente { Id = 2, NombreyApellido = "Ana Gomez", DNI = "87654321", Telefono = "444-555-6666" },
        new Cliente { Id = 3, NombreyApellido = "Juan Perez", DNI = "12345678", Telefono = "111-222-3333" },
        new Cliente { Id = 4, NombreyApellido = "Ana Gomez", DNI = "87654321", Telefono = "444-555-6666" },
        new Cliente { Id = 5, NombreyApellido = "Juan Perez", DNI = "12345678", Telefono = "111-222-3333" }
    };

    public List<Cliente> GetAllClientes()
    {
        return clientes;
    }

    public Cliente GetClienteById(int id)
    {
        return clientes.FirstOrDefault(c => c.Id == id);
    }
}
