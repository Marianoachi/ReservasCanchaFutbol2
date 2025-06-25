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
        public IEnumerable<Reserva> ObtenerPorUsuario(int usuarioId)
        {
            return _ctx.Reservas.Where(r => r.UsuarioId == usuarioId).ToList();
        }

        public IEnumerable<Reserva> ObtenerTodas(int UsuarioId)
        {
            return _ctx.Reservas.Where(r => r.UsuarioId == UsuarioId).ToList();
        }

        public Reserva? ObtenerPorId(int id)
        {
            return _ctx.Reservas.Find(id);
        }

        public void Crear(Reserva reserva)
        {
            // Verificar que exista la cancha
            bool canchaExiste = _ctx.Canchas.Any(c => c.Id == reserva.CanchaId);
            // Verificar que exista el usuario
            bool usuarioExiste = _ctx.Usuarios.Any(u => u.Id == reserva.UsuarioId);

            if (!canchaExiste)
            {
                throw new Exception("La cancha seleccionada no existe.");
            }
            if (!usuarioExiste)
            {
                throw new Exception("El usuario no existe.");
            }

            // Si todo está ok, guardar la reserva
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
