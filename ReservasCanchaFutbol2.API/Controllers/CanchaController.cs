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

    // POST api/cancha
    [HttpPost]
    public IActionResult Post([FromBody] Cancha cancha)
    {
        var creada = _service.Crear(cancha);
        // Apunta a GetById para que CreatedAtAction funcione
        return CreatedAtAction(
            nameof(GetById),
            new { id = creada.Id },
            creada
        );
    }

    // GET api/cancha
    [HttpGet]
    public IActionResult GetAll()
    {
        var lista = _service.ObtenerTodas();
        return Ok(lista);
    }

    // GET api/cancha/5
    [HttpGet("{id}")]
    public IActionResult GetById(int id)
    {
        var cancha = _service.ObtenerPorId(id);
        if (cancha is null)
            return NotFound();
        return Ok(cancha);
    }

    // PUT api/cancha/5
    [HttpPut("{id}")]
    public IActionResult Actualizar(int id, [FromBody] Cancha cancha)
    {
        var existente = _service.ObtenerPorId(id);
        if (existente is null)
            return NotFound();

        cancha.Id = id;  // aseguramos que no cambie el ID
        _service.Actualizar(cancha);
        return NoContent();
    }

    // DELETE api/cancha/5
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
