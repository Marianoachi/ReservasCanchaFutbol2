using ReservasCanchaFutbol2.API.Models;

namespace ReservasCanchaFutbol2.API.Interfaces;
public interface IReservaService
{
    IEnumerable<Reserva> ObtenerTodas();
    Reserva? ObtenerPorId(int id);
    Reserva Crear(int canchaId, string clienteNombre, DateTime fechaHora, int duracionHoras);
    void Actualizar(Reserva reserva);
    void Eliminar(int id);
}


