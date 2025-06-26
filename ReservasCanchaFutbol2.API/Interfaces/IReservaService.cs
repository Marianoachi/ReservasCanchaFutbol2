using ReservasCanchaFutbol2.API.Models;

namespace ReservasCanchaFutbol2.API.Interfaces;
public interface IReservaService
{
    IEnumerable<Reserva> ObtenerTodas();
    IEnumerable<Reserva> ObtenerPorUsuario(int usuarioId);

    Reserva? ObtenerPorId(int id);
    Reserva Crear(int canchaId, DateTime fechaHora, int duracionHoras, int UsuarioId);
    void Actualizar(Reserva reserva);
    void Eliminar(int id);
}


