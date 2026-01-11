using System.ComponentModel.DataAnnotations.Schema;

namespace Gestion_Empleados.Models
{
    public class Empleado
    {
        public int Id { get; set; }
        public string Nombre { get; set; } = string.Empty;
        public string Puesto { get; set; } = string.Empty;

        [Column(TypeName = "decimal(18,2)")]
        public decimal Salario { get; set; }
        public DateTime FechaContratacion { get; set; }

    }
}
