using Microsoft.AspNetCore.Mvc;
using ReservasCanchaFutbol2.API.Interfaces;
using ReservasCanchaFutbol2.API.Models;

namespace ReservasCanchaFutbol2.API.Controllers;
[ApiController]
[Route("api/[controller]")]
public class ClienteController : ControllerBase
{
    private readonly IClienteService _service;

    public ClienteController(IClienteService service)
    {
        _service = service;
    }

    [HttpGet]
    public IActionResult Get() => Ok(_service.ObtenerTodos());

    [HttpPost]
    public IActionResult Post([FromBody] Cliente cliente)
    {
        var creado = _service.Crear(cliente);
        return CreatedAtAction(nameof(Get), new { id = creado.Id }, creado);
    }
}

