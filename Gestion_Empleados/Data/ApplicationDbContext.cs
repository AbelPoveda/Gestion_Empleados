using Gestion_Empleados.Models;
using Microsoft.EntityFrameworkCore;

namespace Gestion_Empleados.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
        }

        // Crea una tabla Empleados basada en Empleado
        public DbSet<Empleado> Empleados { get; set; }
    }
}
