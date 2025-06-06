
using ReservasCanchaFutbol2.API.Interfaces;
using ReservasCanchaFutbol2.API.Models;

namespace ReservasCanchaFutbol2.API.Services
{
    public class ReservaService : IReservaService
    {
        private readonly IReservaRepository _repo;

        public ReservaService(IReservaRepository repo)
        {
            _repo = repo;
        }

        public IEnumerable<Reserva> ObtenerTodas() => _repo.ObtenerTodas();

        public Reserva Crear(int canchaId, int clienteId, DateTime fechaHora, int duracionHoras)
        {
            var nueva = new Reserva
            {
                CanchaId = canchaId,
                ClienteId = clienteId,
                FechaHora = fechaHora,
                DuracionHoras = duracionHoras
            };

            _repo.Crear(nueva);
            return nueva;
        }

        public Reserva? ObtenerPorId(int id) => _repo.ObtenerPorId(id);

        public void Actualizar(Reserva reserva) => _repo.Actualizar(reserva);

        public void Eliminar(int id) => _repo.Eliminar(id);
    }
}


