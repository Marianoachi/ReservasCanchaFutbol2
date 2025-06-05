using ReservasCanchaFutbol2.API.Models;

namespace ReservasCanchaFutbol2.API.Interfaces;
public interface IClienteService
{
    IEnumerable<Cliente> ObtenerTodos();
    Cliente Crear(Cliente cliente);
}
