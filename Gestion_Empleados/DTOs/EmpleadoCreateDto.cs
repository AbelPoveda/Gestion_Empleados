using System.ComponentModel.DataAnnotations;

namespace Gestion_Empleados.DTOs
{
    public class EmpleadoCreateDto
    {
        [Required(ErrorMessage = "El nombre es obligatorio")]
        [StringLength(100, MinimumLength = 3, ErrorMessage = "El nombre debe tener entre 3 y 100 caracteres")]
        public string Nombre { get; set; } = string.Empty;

        [Required]
        public string Puesto { get; set; } = string.Empty;

        [Range(1000, 200000, ErrorMessage = "El salario debe estar entre 1,000 y 200,000")]
        public decimal Salario { get; set; }

        [Required]
        public DateTime FechaContratacion { get; set; }
    }
}
