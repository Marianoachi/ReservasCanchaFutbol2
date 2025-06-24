using System;
using System.Collections.Generic;
using System.Linq;
using ReservasCanchaFutbol2.API.Data;
using ReservasCanchaFutbol2.API.Interfaces;
using ReservasCanchaFutbol2.API.Models;

namespace ReservasCanchaFutbol2.API.Repositories
{
    public class ReservaRepository : IReservaRepository
    {
        private readonly ReservasDbContext _ctx;
        public ReservaRepository(ReservasDbContext ctx)
        {
            _ctx = ctx;
        }

        public IEnumerable<Reserva> ObtenerTodas()
        {
            return _ctx.Reservas.ToList();
        }

        public Reserva? ObtenerPorId(int id)
        {
            return _ctx.Reservas.Find(id);
        }

        public void Crear(Reserva reserva)
        {
            _ctx.Reservas.Add(reserva);
            _ctx.SaveChanges();
        }

        public void Actualizar(Reserva reserva)
        {
            var entidad = _ctx.Reservas.Find(reserva.Id);
            if (entidad != null)
            {
                entidad.CanchaId = reserva.CanchaId;
                entidad.FechaHora = reserva.FechaHora;
                entidad.DuracionHoras = reserva.DuracionHoras;
                entidad.UsuarioId = reserva.UsuarioId;
                _ctx.SaveChanges();
            }
        }


        public void Eliminar(int id)
        {
            var entidad = _ctx.Reservas.Find(id);
            if (entidad != null)
            {
                _ctx.Reservas.Remove(entidad);
                _ctx.SaveChanges();
            }
        }
    }
}
