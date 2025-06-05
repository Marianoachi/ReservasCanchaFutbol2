
using ReservasCanchaFutbol2.API.Models;

namespace ReservasCanchaFutbol2.API.Interfaces;
public interface ICanchaService
{
    IEnumerable<Cancha> ObtenerTodas();
    Cancha Crear(Cancha cancha);
}