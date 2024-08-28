using Microsoft.EntityFrameworkCore;
using Reciplas.Clases;
using Reciplas.Models;

namespace Reciplas.Repository
{
    public class ClienteRepository : IClienteRepository
    {
        private readonly ApplicationDbContext _context;

        public ClienteRepository(ApplicationDbContext context)
        {
            _context = context;
        }
         
        public async Task<Turno> AddTurno(Turno turno)
        {
            var ultimoTurno = await _context.Turnos
                .OrderByDescending(t => t.NumeroTurno)
                .FirstOrDefaultAsync();

            // Asignar el siguiente NumeroTurno
            turno.NumeroTurno = (ultimoTurno?.NumeroTurno ?? 0) + 1; 

            _context.Turnos.Add(turno);
            _context.Clientes.Add(turno.cliente);
            await _context.SaveChangesAsync();

            return turno;
        }

        public async Task<Turno> GetTurno(int turnoId)
            => await _context.Turnos
                                .Include(t => t.cliente)
                                .FirstOrDefaultAsync(c => c.Id == turnoId);

        public async Task<IEnumerable<Turno>> GetTurnos()
            => await _context.Turnos
                                .Include(t => t.cliente)
                                .ToListAsync();

        public async Task<Turno> UpdateTurno(Turno turno)
        {
            _context.Turnos.Update(turno);
            await _context.SaveChangesAsync();
            return turno;
        }

        public async Task<Cliente> GetClientePorDNIYFechaTurno(string DNI, DateTime fechaTurno)
        {
            return await _context.Clientes
                .Include(c => c.Turnos)  // Incluye la relación con los turnos
                .FirstOrDefaultAsync(c => c.DNI == DNI && c.Turnos.Any(t => t.FechaTurno == fechaTurno));
        }

        public async Task<Turno> GetFechaTurno(DateTime fechaTurno)
        {
            return await _context.Turnos
                .FirstOrDefaultAsync(c=>c.FechaTurno.Date == fechaTurno.Date);
        }

        public async Task EliminarTurno(int turnoId)
        { 
            var turno = await _context.Turnos.FindAsync(turnoId);
             
            if (turno != null)
            { 
                _context.Turnos.Remove(turno);
                 
                await _context.SaveChangesAsync();
            }
            else
            { 
                throw new Exception("Turno no encontrado.");
            }
        }

         

    }
}
