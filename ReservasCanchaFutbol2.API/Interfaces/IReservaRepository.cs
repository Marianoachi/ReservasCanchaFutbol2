using ReservasCanchaFutbol2.API.Models;

namespace ReservasCanchaFutbol2.API.Interfaces;
public interface IReservaRepository
{
    IEnumerable<Reserva> ObtenerTodas();//devuelvo la lista de las reservas registradas
    Reserva? ObtenerPorId(int id);//busco la reserva y devuelvo su id, null si no encuentra
    void Crear(Reserva reserva);//recibo el objeto Reserva y lo guardo
    void Actualizar(Reserva reserva);
    void Eliminar(int id);
    IEnumerable<Reserva> ObtenerPorUsuario(int UsuarioId);
}
