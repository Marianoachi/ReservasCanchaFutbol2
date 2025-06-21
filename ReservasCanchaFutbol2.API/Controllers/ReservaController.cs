using Microsoft.AspNetCore.Mvc;
using ReservasCanchaFutbol2.API.Interfaces;
using ReservasCanchaFutbol2.API.Models;

namespace ReservasCanchaFutbol2.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ReservaController : ControllerBase
    {
        private readonly IReservaService _service;

        public ReservaController(IReservaService service)
        {
            _service = service;
        }

        // GET api/reserva
        [HttpGet]
        public IActionResult GetAll()
        {
            var lista = _service.ObtenerTodas();
            return Ok(lista);
        }

        // GET api/reserva/5
        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            var reserva = _service.ObtenerPorId(id);
            if (reserva is null) return NotFound();
            return Ok(reserva);
        }

        // POST api/reserva
        [HttpPost]
        public IActionResult Post([FromBody] Reserva reserva)
        {
            if (reserva is null) return BadRequest();

            var creada = _service.Crear(
                reserva.CanchaId,
                reserva.ClienteNombre,
                reserva.FechaHora,
                reserva.DuracionHoras
            );

            return CreatedAtAction(
                nameof(GetById),
                new { id = creada.Id },
                creada
            );
        }

        // PUT api/reserva/5
        [HttpPut("{id}")]
        public IActionResult Actualizar(int id, [FromBody] Reserva reserva)
        {
            if (reserva is null || id != reserva.Id)
                return BadRequest();

            var existente = _service.ObtenerPorId(id);
            if (existente is null) return NotFound();

            _service.Actualizar(reserva);
            return NoContent();
        }

        // DELETE api/reserva/5
        [HttpDelete("{id}")]
        public IActionResult Eliminar(int id)
        {
            var existente = _service.ObtenerPorId(id);
            if (existente is null) return NotFound();

            _service.Eliminar(id);
            return NoContent();
        }
    }
}
