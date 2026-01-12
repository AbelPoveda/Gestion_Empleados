namespace Gestion_Empleados.Services
{
    public class BonoService
    {
        public decimal CalcularBono(decimal salario, string puesto)
        {
            if (puesto == "Jefe")
            {
                return salario * 0.10m;
            }
            return 0;
        }
    }
}
