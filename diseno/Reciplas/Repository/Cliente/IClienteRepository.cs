using Reciplas.Models;

namespace Reciplas.Repository
{
    public interface IClienteRepository
    { 
        Task<Turno> AddTurno(Turno turno);

        Task<IEnumerable<Turno>> GetTurnos();

        Task<Turno> GetTurno(int turnoId);

        Task<Turno> UpdateTurno(Turno turno);
        Task<Cliente> GetClientePorDNIYFechaTurno(string DNI, DateTime fechaTurno);
        Task<Turno> GetFechaTurno(DateTime fechaTurno);
        Task EliminarTurno(int turnoId);
    }
}