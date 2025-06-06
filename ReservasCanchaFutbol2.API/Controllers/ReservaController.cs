using Microsoft.AspNetCore.Mvc;
using ReservasCanchaFutbol2.API.Interfaces;

namespace ReservasCanchaFutbol2.API.Controllers;
[ApiController]
[Route("api/[controller]")]
public class ReservaController : ControllerBase
{
    private readonly IReservaService _service;

    public ReservaController(IReservaService service)
    {
        _service = service;
    }

    [HttpGet]
    public IActionResult Get() => Ok(_service.ObtenerTodas());

    [HttpPost]
    public IActionResult Post(int canchaId, int clienteId, DateTime fechaHora, int duracionHoras)
    {
        var reserva = _service.Crear(canchaId, clienteId, fechaHora, duracionHoras);
        return Ok(reserva);
    }
    [HttpGet("{id}")]
    public ActionResult<Reserva> ObtenerPorId(int id)
    {
        var reserva = _service.ObtenerPorId(id);
        return reserva is null ? NotFound() : Ok(reserva);
    }

    [HttpPut("{id}")]
    public IActionResult Actualizar(int id, [FromBody] Reserva reserva)
    {
        var existente = _service.ObtenerPorId(id);
        if (existente is null)
            return NotFound();

        reserva.Id = id;
        _service.Actualizar(reserva);
        return NoContent();
    }

    [HttpDelete("{id}")]
    public IActionResult Eliminar(int id)
    {
        var existente = _service.ObtenerPorId(id);
        if (existente is null)
            return NotFound();

        _service.Eliminar(id);
        return NoContent();
    }

}