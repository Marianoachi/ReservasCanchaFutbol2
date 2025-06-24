using System;
using System.Collections.Generic;
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

        public IEnumerable<Reserva> ObtenerTodas()
        {
            return _repo.ObtenerTodas();
        }

        public Reserva? ObtenerPorId(int id)
        {
            return _repo.ObtenerPorId(id);
        }

        public Reserva Crear(int canchaId, DateTime fechaHora, int duracionHoras, int usuarioId)
        {
            var nueva = new Reserva
            {
                CanchaId = canchaId,
                FechaHora = fechaHora,
                DuracionHoras = duracionHoras,
                UsuarioId = usuarioId
            };

            _repo.Crear(nueva);
            return nueva;
        }

        public void Actualizar(Reserva reserva)
        {
            _repo.Actualizar(reserva);
        }

        public void Eliminar(int id)
        {
            _repo.Eliminar(id);
        }
    }
}
