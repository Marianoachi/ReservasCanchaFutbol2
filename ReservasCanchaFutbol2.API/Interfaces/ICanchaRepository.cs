using ReservasCanchaFutbol2.API.Models;

namespace ReservasCanchaFutbol2.API.Interfaces;
//aca solo guardo y traigo datos
public interface ICanchaRepository
{
    IEnumerable<Cancha> ObtenerTodas();
    Cancha? ObtenerPorId(int id);
    void Crear(Cancha cancha);
    void Actualizar(Cancha cancha);
    void Eliminar(int id);
}

