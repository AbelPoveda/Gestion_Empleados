using Gestion_Empleados.Services;

namespace Gestión_Empleados.Tests
{
    public class BonoServiceTests
    {
        [Fact]
        public void CalcularBono_CuandoEsJefe_DiezPorCiento()
        {
            var service = new BonoService();
            var salario = 1000m;
            var puesto = "Jefe";

            var resultado = service.CalcularBono(salario, puesto);

            Assert.Equal(100, resultado);
        }

        [Fact]
        public void CalcularBono_CuandoNoEsJefe_Cero()
        {
            var service = new BonoService();
            var salario = 1000m;
            var puesto = "Programador";

            var resultado = service.CalcularBono(salario, puesto);

            Assert.Equal(0, resultado);
        }
    }
}
