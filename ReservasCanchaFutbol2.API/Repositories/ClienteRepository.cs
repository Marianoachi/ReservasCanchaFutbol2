using ReservasCanchaFutbol2.API.Interfaces;
using ReservasCanchaFutbol2.API.Models;

namespace ReservasCanchaFutbol.API.Repositories;
public class ClienteRepository : IClienteRepository
{
    private readonly List<Cliente> _clientes = new(); //lsimulo sql, despues la elimino e inyecto el appdbContext

    public IEnumerable<Cliente> ObtenerTodos() => _clientes; // devuelvo los clientes guardados en la lista

    public Cliente? ObtenerPorId(int id) => _clientes.FirstOrDefault(c => c.Id == id); //busco cliente por su id, null si no encuentra

    public void Crear(Cliente cliente)
    {
        cliente.Id = _clientes.Count > 0 ? _clientes.Max(c => c.Id) + 1 : 1; //asigno el nuevo ID automatico, al maximo le sumo 1, si no hay le asigna id = 1
        _clientes.Add(cliente);
    }
}