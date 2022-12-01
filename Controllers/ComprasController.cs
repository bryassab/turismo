using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TurismoReactnetCore.Context;
using TurismoReactnetCore.Models;
using AppContext = TurismoReactnetCore.Context.AppContext;


// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace TurismoReactnetCore.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ComprasController : ControllerBase
    {
        private readonly AppContext _context;

        public ComprasController(AppContext context)
        {
            _context = context;
        }
        // GET: api/<ComprasController>
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var listaTotal = await _context.Compras.OrderBy(x => x.Producto).ToListAsync();
            
            return Ok(listaTotal);
        }

        // GET api/<ComprasController>/5
        [HttpGet("{id:int}")]
        public async Task<IActionResult> GetById(int id)
        {
            var userId = await _context.Compras.FirstOrDefaultAsync(c => c.IdCompra == id);
            if (userId == null)
            {
                return NotFound();
            }

            return Ok(userId);
        }

        // POST api/<ComprasController>
        [HttpPost]
        public async Task<IActionResult> CreateCompra([FromBody] Compras compras)
        {
            if(compras == null)
            {
                return BadRequest(ModelState);
            }
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            await _context.AddAsync(compras);
            await _context.SaveChangesAsync();

            return Ok(compras);
        }

        // PUT api/<ComprasController>/5
        [HttpPut("{id:int}")]
        public async Task<IActionResult> EditCompra(int id, [FromBody] Compras compras)
        {
            if(id != compras.IdCompra)
            {
                return BadRequest(ModelState);
            }
            var nuevaCompra = await _context.Compras.FindAsync(id);
            if(nuevaCompra == null)
            {
                return NotFound();
            }
            nuevaCompra.Producto = compras.Producto;
            nuevaCompra.Cantidad = compras.Cantidad;
            nuevaCompra.FK_Turismo = compras.FK_Turismo;

            try
            {
                await _context.SaveChangesAsync();
            }catch(DbUpdateConcurrencyException) when (!CompraExist(id))
            {
                NotFound();
            }
            return NoContent(nuevaCompra);
        }

        // DELETE api/<ComprasController>/5
        [HttpDelete("{id:int}")]
        public async Task<IActionResult> DeleteCompra(int id)
        {
            var nuevaCompra = await _context.Compras.FindAsync(id);
            if(nuevaCompra == null)
            {
                return NotFound();
            }
            _context.Compras.Remove(nuevaCompra);
            await _context.SaveChangesAsync();
            return NoContent();

        }
            private bool CompraExist(long id)
            {
                return _context.Compras.Any(e => e.IdCompra == id);
            }


        }
}
