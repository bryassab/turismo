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
    public class TurismoController : ControllerBase
    {
        private readonly AppContext _context;
        public TurismoController(AppContext context)
        {
            _context = context;
        }
        // GET: api/<TurismoController>
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var lista = await _context.Turismo.OrderBy(x => x.Nombre).Include(c => c.Compras).ToListAsync();

            return Ok(lista);

        }



        // GET api/<TurismoController>/5
        [HttpGet("{id:int}")]
        public async Task<IActionResult> GetUser(int id)
        {
            var userId = await _context.Turismo.Include(x => x.Compras).FirstOrDefaultAsync(c => c.Id == id);
            if (userId == null)
            {
                return NotFound();
            }

            return Ok(userId);
        }

        [HttpGet("{name}")]
        public IActionResult GetByName([FromRoute] string name)
        {
            List<UserTurismo> usuarios = _context.Turismo.Where(x => x.Nombre.Contains(name)).ToList();

            return Ok(usuarios);
        }


        // POST api/<TurismoController>
        [HttpPost]
        public async Task<IActionResult> NewTurismo([FromBody] UserTurismo userTurismo)
        {
            if (userTurismo == null)
            {
                return BadRequest(ModelState);
            }
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            await _context.AddAsync(userTurismo);
            await _context.SaveChangesAsync();
            return Ok();

        }

        // PUT api/<TurismoController>/5
        [HttpPut("{id}")]
        public async Task<IActionResult> EditTurismo(int id, [FromBody] UserTurismo userTurismo)
        {
            if(id != userTurismo.Id)
            {
                return BadRequest();
            }
            var usuariosTurismo = await _context.Turismo.FindAsync(id);
            if (usuariosTurismo == null)
            {
                return NotFound();
            }
            usuariosTurismo.Nombre = userTurismo.Nombre;
            usuariosTurismo.Propietario = userTurismo.Propietario;
            usuariosTurismo.Lanzamiento = userTurismo.Lanzamiento;
            usuariosTurismo.Desarrollador = userTurismo.Desarrollador;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException) when (!userTurismoExist(id))
            {
                return NotFound();
            }
            return NoContent();
        }

        // DELETE api/<TurismoController>/5
        [HttpDelete("{id:int}")]
        public async Task<IActionResult> DeleteTurismo(int id)
        {
            var usuariosTurismo = await _context.Turismo.FindAsync(id);
            if (usuariosTurismo == null)
            {
                return NotFound();
            }
            _context.Turismo.Remove(usuariosTurismo);
            await _context.SaveChangesAsync();
            return NoContent();
        }

        private bool userTurismoExist(long id)
        {
            return _context.Turismo.Any(e => e.Id == id);
        }
    }
}
