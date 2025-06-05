using ReservasCanchaFutbol2.API.Interfaces;
using ReservasCanchaFutbol2.API.Models;

namespace ReservasCanchaFutbol.API.Repositories;
public class CanchaRepository : ICanchaRepository
{
    private readonly List<Cancha> _canchas = new(); //para simular la bd e ir probando en swagger

    public IEnumerable<Cancha> ObtenerTodas() => _canchas;//las canchas almacenadas en la lista

    public Cancha? ObtenerPorId(int id) => _canchas.FirstOrDefault(c => c.Id == id); //busco la primera cancha q tenga el ID que le paso, retorna null si no encuentra

    public void Crear(Cancha cancha)
    {
        cancha.Id = _canchas.Count > 0 ? _canchas.Max(c => c.Id) + 1 : 1;// nuevo id a la cancha que sea el siguiente numero, el maximo actual + 1 si no hay todavia, id=1
        _canchas.Add(cancha);
    }
}
