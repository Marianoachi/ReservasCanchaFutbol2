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
}

