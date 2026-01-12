using Gestion_Empleados.Services;

namespace Gestión_Empleados.Tests
{
    public class NetoServiceTests
    {
        [Theory]
        [InlineData(18000, 1275)] // (18000 - 15%) / 12 = 1275
        [InlineData(30000, 2025)] // (30000 - 19%) / 12 = 2025
        public void CalcularSueldoNeto_DebeAplicarRetencionCorrecta(decimal bruto, decimal netoEsperado)
        {
            var service = new NetoService();

            var resultado = service.CalcularSueldoNetoMensual(bruto);

            Assert.Equal(netoEsperado, resultado);
        }
    }
}
