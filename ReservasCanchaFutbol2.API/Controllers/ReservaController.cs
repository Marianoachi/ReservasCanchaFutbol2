using System.Net.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ReservasCanchaFutbol2.API.Data;
using ReservasCanchaFutbol2.API.Interfaces;
using ReservasCanchaFutbol2.API.Models;
using ReservasCanchaFutbol2.API.Services;

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
        [HttpGet]
        public IActionResult GetReservas([FromQuery] int? usuarioId)
        {
            var reservas = _service.ObtenerTodas();

            if (usuarioId.HasValue)
                reservas = reservas.Where(r => r.UsuarioId == usuarioId.Value);

            return Ok(reservas.ToList());
        }



        [HttpGet("usuario/{usuarioId}")]
        public IActionResult ObtenerPorUsuario(int UsuarioId)
        {
            var reservas = _service.ObtenerPorUsuario(UsuarioId);
            return Ok(reservas);
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
        public IActionResult Post([FromBody] CrearReservaRequest reserva)
        {
            try
            {
                var creada = _service.Crear(
                    reserva.CanchaId,
                    reserva.FechaHora,
                    reserva.DuracionHoras,
                    reserva.UsuarioId
                );
                return CreatedAtAction(nameof(GetById), new { id = creada.Id }, creada);
            }
            catch (InvalidOperationException ex)
            {
                return BadRequest(new { mensaje = ex.Message });
            }
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
