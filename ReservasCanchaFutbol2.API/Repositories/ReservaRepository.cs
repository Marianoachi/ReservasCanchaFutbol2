using ReservasCanchaFutbol2.API.Models;
using ReservasCanchaFutbol2.API.Interfaces;

namespace ReservasCanchaFutbol.API.Repositories;
public class ReservaRepository : IReservaRepository
{
    private readonly List<Reserva> _reservas = new(); //simulo sql despues la borro

    public IEnumerable<Reserva> ObtenerTodas() => _reservas; //lista de las reservas

    public Reserva? ObtenerPorId(int id) => _reservas.FirstOrDefault(r => r.Id == id);// buso la reserva por su id, null si no encuentra

    public void Crear(Reserva reserva)
    {
        reserva.Id = _reservas.Count > 0 ? _reservas.Max(r => r.Id) + 1 : 1;// le asigno id unico, toma el mas alto y +1, si no hay id = 1. La agrega a la lista 
        _reservas.Add(reserva);
    }


    public void Actualizar(Reserva reserva)
    {
        var existente = _reservas.FirstOrDefault(r => r.Id == reserva.Id);
        if (existente != null)
        {
            existente.CanchaId = reserva.CanchaId;
            existente.ClienteId = reserva.ClienteId;
            existente.FechaHora = reserva.FechaHora;
            existente.DuracionHoras = reserva.DuracionHoras;
        }
    }

    public void Eliminar(int id)
    {
        var reserva = _reservas.FirstOrDefault(r => r.Id == id);
        if (reserva != null)
        {
            _reservas.Remove(reserva);
        }
    }

}