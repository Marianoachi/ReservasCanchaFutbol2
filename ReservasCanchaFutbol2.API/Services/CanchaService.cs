using ReservasCanchaFutbol2.API.Interfaces;
using ReservasCanchaFutbol2.API.Models;

namespace ReservasCanchaFutbol.API.Services;
public class CanchaService : ICanchaService
{
    private readonly ICanchaRepository _repo;//accedo a los datos

    public CanchaService(ICanchaRepository repo)// constructor q inyecta el IcanchaRepository (DIP)
    {
        _repo = repo;
    }

    public IEnumerable<Cancha> ObtenerTodas() => _repo.ObtenerTodas(); //llamo al metodo de lrepositorio que devuelve la canchas, lo puedo usar desde un controlador para listar todas las canchas

    public Cancha Crear(Cancha cancha)//llamo al metodo crear desde el repositorio para guardar una nueva cancha
    {
        _repo.Crear(cancha);
        return cancha;
    }
    public Cancha? ObtenerPorId(int id) => _repo.ObtenerPorId(id);

    public void Actualizar(Cancha cancha) => _repo.Actualizar(cancha);

    public void Eliminar(int id) => _repo.Eliminar(id);

}