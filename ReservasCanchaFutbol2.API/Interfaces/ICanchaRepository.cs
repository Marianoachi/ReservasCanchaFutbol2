using ReservasCanchaFutbol2.API.Models;

namespace ReservasCanchaFutbol2.API.Interfaces;
//aca solo guardo y traigo datos
public interface ICanchaRepository
{
    IEnumerable<Cancha> ObtenerTodas(); //devuelvo una lista de todas las canchas
    Cancha? ObtenerPorId(int id); //busco y devuelvo el id de la cancha
    void Crear(Cancha cancha); //recibo el objeto cancha y lo guardo
}
