using System.Collections.Generic;
using System.Linq;
using ReservasCanchaFutbol2.API.Data;
using ReservasCanchaFutbol2.API.Interfaces;
using ReservasCanchaFutbol2.API.Models;

namespace ReservasCanchaFutbol2.API.Repositories
{
    public class CanchaRepository : ICanchaRepository
    {
        private readonly ReservasDbContext _context;

        public CanchaRepository(ReservasDbContext context)
        {
            _context = context;
        }

        // Devuelve todas las canchas de la tabla
        public IEnumerable<Cancha> ObtenerTodas()
        {
            return _context.Canchas.ToList();
        }

        // Busca una cancha por su Id o devuelve null
        public Cancha? ObtenerPorId(int id)
        {
            return _context.Canchas.Find(id);
        }

        // Inserta una nueva cancha y guarda cambios
        public void Crear(Cancha cancha)
        {
            _context.Canchas.Add(cancha);
            _context.SaveChanges();
        }

        // Actualiza una cancha existente y guarda cambios
        public void Actualizar(Cancha cancha)
        {
            _context.Canchas.Update(cancha);
            _context.SaveChanges();
        }

        // Elimina la cancha con el Id dado (si existe) y guarda cambios
        public void Eliminar(int id)
        {
            var entidad = _context.Canchas.Find(id);
            if (entidad != null)
            {
                _context.Canchas.Remove(entidad);
                _context.SaveChanges();
            }
        }
    }
}
