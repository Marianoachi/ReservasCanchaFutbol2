using ReservasCanchaFutbol2.API.Interfaces;
using ReservasCanchaFutbol2.API.Models;

namespace ReservasCanchaFutbol.API.Services;
public class ClienteService : IClienteService
{
    private readonly IClienteRepository _repo; //guardo la referencia al repositorio q maneja el acceso a los clientes

    public ClienteService(IClienteRepository repo) //inyecto el repositorio, el servicio recibe una implementacion de IClienteRepository para poder usarla
    {
        _repo = repo;
    }

    public IEnumerable<Cliente> ObtenerTodos() => _repo.ObtenerTodos(); //llamo al repositorio ara traer todos los clientes y los devuelvo, sin logica, solo pasa los datos

    public Cliente Crear(Cliente cliente)//llama al repo para guardar un nuevo cliente y luego lo devuelve a ese cliente creaodo
    {
        _repo.Crear(cliente);
        return cliente;
    }
}
