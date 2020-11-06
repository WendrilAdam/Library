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
    public class BooksController : ControllerBase
    {
        private readonly LibraryContext _context;

        public BooksController(LibraryContext context)
        {
            _context = context;
        }

        /// <summary>
        /// Listar livros
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Books>>> GetBooks()
        {
            return await _context.Books.ToListAsync();
        }

        /// <summary>
        /// Número de Livros Registrados
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [Route("Count")]
        public int GetBooksNumber()
        {
            List<Books> lista = _context.Books.ToList();
            return lista.Count();
        }

        /// <summary>
        /// Lista de Livros Ordenada por Título
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [Route("order-by-title")]
        public IOrderedEnumerable<Books> GetOrderByTitle()
        {
            List<Books> lista = _context.Books.ToList();
            return lista.OrderBy(livro => livro.Título);
        }

        /// <summary>
        /// Buscar Livro por Id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet("{id}")]
        public async Task<ActionResult<Books>> GetBooksId(int id)
        {
            var books = await _context.Books.FindAsync(id);

            if (books == null)
            {
                return NotFound();
            }

            return books;
        }

        /// <summary>
        /// Alterar Livros
        /// </summary>
        /// <param name="id"></param>
        /// <param name="books"></param>
        /// <returns></returns>
        [HttpPut("{id}")]
        public async Task<IActionResult> PutBooks(int id, Books books)
        {
            if (id != books.Id)
            {
                return BadRequest();
            }

            _context.Entry(books).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!BooksExists(id))
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
        /// Alterar Título de um Livro
        /// </summary>
        /// <param name="id"></param>
        /// <param name="titulo"></param>
        /// <returns></returns>
        [HttpPatch]
        [Route("Título")]
        public async Task<IActionResult> PatchTitle(int id, string titulo)
        {
            Books lista = await _context.Books.FindAsync(id);
            if (id != lista.Id)
            {
                return BadRequest();
            }
            
            lista.Título = titulo;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!BooksExists(id))
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
        /// Alterar Autor de um Livro
        /// </summary>
        /// <param name="id"></param>
        /// <param name="autor"></param>
        /// <returns></returns>
        [HttpPatch]
        [Route("Autor")]

        public async Task<IActionResult> PatchAutor(int id, string autor)
        {
            Books lista = await _context.Books.FindAsync(id);
            if (id != lista.Id)
            {
                return BadRequest();
            }

            lista.Autor = autor;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!BooksExists(id))
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
        /// Alterar Editora de um Livro
        /// </summary>
        /// <param name="id"></param>
        /// <param name="editora"></param>
        /// <returns></returns>
        [HttpPatch]
        [Route("Editora")]
        public async Task<IActionResult> PatchEditor(int id, string editora)
        {
            Books lista = await _context.Books.FindAsync(id);
            if (id != lista.Id)
            {
                return BadRequest();
            }

            lista.Editora = editora;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!BooksExists(id))
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
        /// Alterar Valor de um Livro
        /// </summary>
        /// <param name="id"></param>
        /// <param name="valor"></param>
        /// <returns></returns>
        [HttpPatch]
        [Route("Valor")]
        public async Task<IActionResult> PatchVal(int id, Double valor)
        {
            Books lista = await _context.Books.FindAsync(id);
            if (id != lista.Id)
            {
                return BadRequest();
            }

            lista.Valor = valor;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!BooksExists(id))
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
        /// Adicionar Livro
        /// </summary>
        /// <param name="books"></param>
        /// <returns></returns>
        [HttpPost]
        public async Task<ActionResult<Books>> PostBooks(Books books)
        {
            _context.Books.Add(books);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetBooks", new { id = books.Id }, books);
        }

       /// <summary>
       /// Deletar Livro
       /// </summary>
       /// <param name="id"></param>
       /// <returns></returns>
        [HttpDelete("{id}")]
        public async Task<ActionResult<Books>> DeleteBooks(int id)
        {
            var books = await _context.Books.FindAsync(id);
            if (books == null)
            {
                return NotFound();
            }

            _context.Books.Remove(books);
            await _context.SaveChangesAsync();

            return books;
        }

        private bool BooksExists(int id)
        {
            return _context.Books.Any(e => e.Id == id);
        }
    }
}
