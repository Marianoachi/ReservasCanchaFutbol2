using ReservasCanchaFutbol2.API.Models;

namespace ReservasCanchaFutbol2.API.Interfaces;
public interface IClienteRepository
{
    IEnumerable<Cliente> ObtenerTodos();//lista de todos los clientes registrados
    Cliente? ObtenerPorId(int id);//busco un cliente y devuelvo su id, retrona null si no encuentra ningun cliente
    void Crear(Cliente cliente);//recibo el objeto cliente y lo guardo
}