namespace Gestion_Empleados.Services
{
    public class NetoService
    {
        public decimal CalcularSueldoNetoMensual(decimal brutoAnual)
        {
            decimal retencion = brutoAnual < 20000 ? 0.15m : 0.19m;
            decimal netoAnual = brutoAnual * (1 - retencion);
            return netoAnual / 12;
        }
    }
}
