using Gestion_Empleados.DTOs;
using Gestion_Empleados.Interfaces;
using Gestion_Empleados.Models;
using Gestion_Empleados.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Gestion_Empleados.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class EmpleadosController : ControllerBase
    {
        private readonly IEmpleadoRepository _repository;

        // Inyectamos la Interfaz
        public EmpleadosController(IEmpleadoRepository repository)
        {
            _repository = repository;
        }

        // GET: api/empleados
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Empleado>>> Get()
        {
            var empleados = await _repository.GetAllAsync();
            return Ok(empleados);
        }

        // GET: api/empleados/id
        [HttpGet("{id}")]
        public async Task<ActionResult<EmpleadoResponseDto>> GetById(int id, [FromServices] NetoService _servicioSueldo)
        {
            var empleado = await _repository.GetByIdAsync(id);
            if (empleado == null) return NotFound();

            var respuesta = new EmpleadoResponseDto
            {
                Id = empleado.Id,
                Nombre = empleado.Nombre,
                Puesto = empleado.Puesto,
                SalarioBruto = empleado.Salario,
                SalarioNetoMensual = _servicioSueldo.CalcularSueldoNetoMensual(empleado.Salario)
            };

            return Ok(respuesta);

            if (empleado == null) return NotFound();

            return Ok(empleado);
        }

        // POST: api/empleados
        [HttpPost]
        public async Task<ActionResult<Empleado>> Post([FromBody] EmpleadoCreateDto empleadoDto)
        {
            // Mapeo
            var nuevoEmpleado = new Empleado
            {
                Nombre = empleadoDto.Nombre,
                Puesto = empleadoDto.Puesto,
                Salario = empleadoDto.Salario,
                FechaContratacion = empleadoDto.FechaContratacion
            };

            await _repository.AddAsync(nuevoEmpleado);

            return CreatedAtAction(nameof(GetById), new { id = nuevoEmpleado.Id }, nuevoEmpleado);
        }

        // PUT: api/empleados/id
        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, [FromBody] EmpleadoCreateDto empleadoDto)
        {
            var empleadoExistente = await _repository.GetByIdAsync(id);
            if (empleadoExistente == null) return NotFound();

            // Mapeo
            empleadoExistente.Nombre = empleadoDto.Nombre;
            empleadoExistente.Puesto = empleadoDto.Puesto;
            empleadoExistente.Salario = empleadoDto.Salario;
            empleadoExistente.FechaContratacion = empleadoDto.FechaContratacion;

            await _repository.UpdateAsync(empleadoExistente);

            return NoContent();
        }

        // DELETE: api/empleados/id
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var empleado = await _repository.GetByIdAsync(id);
            if (empleado == null) return NotFound();

            await _repository.DeleteAsync(id);
            return NoContent();
        }
    }
}
