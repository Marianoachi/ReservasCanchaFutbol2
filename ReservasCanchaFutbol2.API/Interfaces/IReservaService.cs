using ReservasCanchaFutbol2.API.Models;

namespace ReservasCanchaFutbol2.API.Interfaces;
public interface IReservaService
{
    IEnumerable<Reserva> ObtenerTodas();
    Reserva Crear(int canchaId, int clienteId, DateTime fechaHora, int duracionHoras);
}
