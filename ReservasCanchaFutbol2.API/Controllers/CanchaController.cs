using Microsoft.AspNetCore.Mvc;
using ReservasCanchaFutbol2.API.Interfaces;
using ReservasCanchaFutbol2.API.Models;

namespace ReservasCanchaFutbol2.API.Controllers;
[ApiController]
[Route("api/[controller]")]
public class CanchaController : ControllerBase
{
    private readonly ICanchaService _service;

    public CanchaController(ICanchaService service)
    {
        _service = service;
    }

    [HttpGet]
    public IActionResult Get() => Ok(_service.ObtenerTodas());

    [HttpPost]
    public IActionResult Post([FromBody] Cancha cancha)
    {
        var creada = _service.Crear(cancha);
        return CreatedAtAction(nameof(Get), new { id = creada.Id }, creada);
    }
    [HttpGet("{id}")]
    public ActionResult<Cancha> ObtenerPorId(int id)
    {
        var cancha = _service.ObtenerPorId(id);
        return cancha is null ? NotFound() : Ok(cancha);
    }

    [HttpPut("{id}")]
    public IActionResult Actualizar(int id, [FromBody] Cancha cancha)
    {
        var existente = _service.ObtenerPorId(id);
        if (existente is null)
            return NotFound();

        cancha.Id = id; // aseguramos que se mantenga el ID
        _service.Actualizar(cancha);
        return NoContent();
    }

    [HttpDelete("{id}")]
    public IActionResult Eliminar(int id)
    {
        var cancha = _service.ObtenerPorId(id);
        if (cancha is null)
            return NotFound();

        _service.Eliminar(id);
        return NoContent();
    }

}

