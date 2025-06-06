
using ReservasCanchaFutbol2.API.Models;

namespace ReservasCanchaFutbol2.API.Interfaces;
public interface ICanchaService
{
    IEnumerable<Cancha> ObtenerTodas();
    Cancha Crear(Cancha cancha);
    Cancha? ObtenerPorId(int id);
    void Actualizar(Cancha cancha);
    void Eliminar(int id);

}