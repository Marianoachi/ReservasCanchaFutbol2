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
}