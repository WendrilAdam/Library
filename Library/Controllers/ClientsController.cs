using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Library.DatabaseContext;
using Library.Models;

namespace Library.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ClientsController : ControllerBase
    {
        private readonly LibraryContext _context;

        public ClientsController(LibraryContext context)
        {
            _context = context;
        }

        /// <summary>
        /// Listar clientes
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Clients>>> GetClients()
        {
            return await _context.Clients.ToListAsync();
        }

        /// <summary>
        /// Buscar cliente por Id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet("{id}")]
        public async Task<ActionResult<Clients>> GetClients(int id)
        {
            var clients = await _context.Clients.FindAsync(id);

            if (clients == null)
            {
                return NotFound();
            }

            return clients;
        }

        /// <summary>
        /// Alterar Cliente
        /// </summary>
        /// <param name="id"></param>
        /// <param name="clients"></param>
        /// <returns></returns>
        [HttpPut("{id}")]
        public async Task<IActionResult> PutClients(int id, Clients clients)
        {
            if (id != clients.Id)
            {
                return BadRequest();
            }

            _context.Entry(clients).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ClientsExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        /// <summary>
        /// Adicionar Cliente
        /// </summary>
        /// <param name="clients"></param>
        /// <returns></returns>
        [HttpPost]
        public async Task<ActionResult<Clients>> PostClients(Clients clients)
        {
            _context.Clients.Add(clients);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetClients", new { id = clients.Id }, clients);
        }

        /// <summary>
        /// Deletar Cliente
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpDelete("{id}")]
        public async Task<ActionResult<Clients>> DeleteClients(int id)
        {
            var clients = await _context.Clients.FindAsync(id);
            if (clients == null)
            {
                return NotFound();
            }

            _context.Clients.Remove(clients);
            await _context.SaveChangesAsync();

            return clients;
        }

        private bool ClientsExists(int id)
        {
            return _context.Clients.Any(e => e.Id == id);
        }
    }
}
