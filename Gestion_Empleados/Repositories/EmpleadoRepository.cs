using Gestion_Empleados.Data;
using Gestion_Empleados.Interfaces;
using Gestion_Empleados.Models;
using Microsoft.EntityFrameworkCore;

namespace GestionDeEmpleados.Repositories
{
    public class EmpleadoRepository : IEmpleadoRepository
    {
        private readonly ApplicationDbContext _context;

        public EmpleadoRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Empleado>> GetAllAsync() => await _context.Empleados.ToListAsync();

        public async Task<Empleado?> GetByIdAsync(int id) => await _context.Empleados.FindAsync(id);

        public async Task AddAsync(Empleado empleado)
        {
            await _context.Empleados.AddAsync(empleado);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(Empleado empleado)
        {
            _context.Empleados.Update(empleado);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var empleado = await GetByIdAsync(id);
            if (empleado != null)
            {
                _context.Empleados.Remove(empleado);
                await _context.SaveChangesAsync();
            }
        }
    }
}
