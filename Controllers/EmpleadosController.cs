using EmpleadosAPI.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace EmpleadosAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmpleadosController : ControllerBase
    {
        private readonly BDEmpleadosContext _BD;
        public EmpleadosController(BDEmpleadosContext BD)
        {
            _BD = BD;
        }

        [HttpGet]
        public async Task<IActionResult> Lista()
        {
            var listaEmpleados = await _BD.Empleados.ToListAsync();
            return Ok(listaEmpleados);
        }

        [HttpPost]
        [Route("Agregar")]
        public async Task<IActionResult> Agregar([FromBody] Empleados request)
        {
            await _BD.Empleados.AddAsync(request);
            await _BD.SaveChangesAsync();
            return Ok(request);
        }

        [HttpPut]
        [Route("Modificar/{id:int}")]
        public async Task<IActionResult> Modificar(int id, [FromBody] Empleados request)
        {
            var empleadoActual = await _BD.Empleados.FindAsync(id);
            if (empleadoActual == null)
            {
                return NotFound("Empleado no encontrado");
            }

            empleadoActual.nombre = request.nombre;

            try
            {
                await _BD.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                return BadRequest("Error al actualizar el empleado");
            }
            return Ok();
        }

        [HttpDelete]
        [Route("Eliminar/{id:int}")]
        public async Task<IActionResult> Eliminar(int id)
        {
            var empleadoActual = await _BD.Empleados.FindAsync(id);
            if(empleadoActual == null)
            {
                return BadRequest("No se pudo eliminar esta tarea porque no se encontró");
            }

            _BD.Empleados.Remove(empleadoActual);
            await _BD.SaveChangesAsync();
            return Ok();
        }
    }
}
