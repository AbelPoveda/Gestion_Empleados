using System.ComponentModel.DataAnnotations;

namespace Gestion_Empleados.DTOs
{
    public class EmpleadoResponseDto
    {
        public int Id { get; set; }
        public string Nombre { get; set; } = string.Empty;
        public string Puesto { get; set; } = string.Empty;
        public decimal SalarioBruto { get; set; }
        public decimal SalarioNetoMensual { get; set; }
    }
}
