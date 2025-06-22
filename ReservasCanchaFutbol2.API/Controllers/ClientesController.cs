using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ReservasCanchaFutbol2.API.Data;
using ReservasCanchaFutbol2.API.Data.Models;

namespace ReservasCanchaFutbol2.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ClientesController : ControllerBase
    {
        private readonly ReservasDbContext _db;

        public ClientesController(ReservasDbContext db)
        {
            _db = db;
        }

        // GET: api/clientes
        [HttpGet]
        public async Task<ActionResult<List<Cliente>>> GetAll()
        {
            var clientes = await _db.Clientes
                .AsNoTracking()
                .ToListAsync();
            return Ok(clientes);
        }

        // GET: api/clientes/5
        [HttpGet("{id:int}")]
        public async Task<ActionResult<Cliente>> GetById(int id)
        {
            var cliente = await _db.Clientes
                .AsNoTracking()
                .FirstOrDefaultAsync(c => c.Id == id);

            if (cliente == null)
                return NotFound();

            return Ok(cliente);
        }

        // POST: api/clientes
        [HttpPost]
        public async Task<ActionResult<Cliente>> Create(Cliente nuevo)
        {
            // Validación automática con DataAnnotations
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            _db.Clientes.Add(nuevo);
            await _db.SaveChangesAsync();

            // Devuelve 201 Created + cabecera Location
            return CreatedAtAction(
                nameof(GetById),
                new { id = nuevo.Id },
                nuevo);
        }

        // PUT: api/clientes/5
        [HttpPut("{id:int}")]
        public async Task<ActionResult> Update(int id, Cliente actualizado)
        {
            if (id != actualizado.Id)
                return BadRequest("El ID no coincide");

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            _db.Entry(actualizado).State = EntityState.Modified;

            try
            {
                await _db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!await _db.Clientes.AnyAsync(c => c.Id == id))
                    return NotFound();

                throw;
            }

            return NoContent(); // 204
        }

        // DELETE: api/clientes/5
        [HttpDelete("{id:int}")]
        public async Task<ActionResult> Delete(int id)
        {
            var cliente = await _db.Clientes.FindAsync(id);
            if (cliente == null)
                return NotFound();

            _db.Clientes.Remove(cliente);
            await _db.SaveChangesAsync();

            return NoContent(); // 204
        }
    }
}

