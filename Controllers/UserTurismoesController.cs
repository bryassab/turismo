//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Threading.Tasks;
//using Microsoft.AspNetCore.Mvc;
//using Microsoft.AspNetCore.Mvc.Rendering;
//using Microsoft.EntityFrameworkCore;
//using TurismoReactnetCore.Context;
//using TurismoReactnetCore.Models;

//namespace TurismoReactnetCore.Controllers
//{
//    public class UserTurismoesController : Controller
//    {
//        private readonly AppContext _context;

//        public UserTurismoesController(AppContext context)
//        {
//            _context = context;
//        }

//        // GET: UserTurismoes
//        public async Task<IActionResult> Index()
//        {
//            var appContext = _context.Turismo.Include(u => u.Compras);
//            return View(await appContext.ToListAsync());
//        }

//        // GET: UserTurismoes/Details/5
//        public async Task<IActionResult> Details(int? id)
//        {
//            if (id == null)
//            {
//                return NotFound();
//            }

//            var userTurismo = await _context.Turismo
//                .Include(u => u.Compras)
//                .FirstOrDefaultAsync(m => m.Id == id);
//            if (userTurismo == null)
//            {
//                return NotFound();
//            }

//            return View(userTurismo);
//        }

//        // GET: UserTurismoes/Create
//        public IActionResult Create()
//        {
//            ViewData["FK_Compra"] = new SelectList(_context.compras, "idCompra", "Precio");
//            return View();
//        }

//        // POST: UserTurismoes/Create
//        // To protect from overposting attacks, enable the specific properties you want to bind to.
//        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
//        [HttpPost]
//        [ValidateAntiForgeryToken]
//        public async Task<IActionResult> Create([Bind("Id,Nombre,Lanzamiento,Propietario,Desarrollador,FK_Compra")] UserTurismo userTurismo)
//        {
//            if (ModelState.IsValid)
//            {
//                _context.Add(userTurismo);
//                await _context.SaveChangesAsync();
//                return RedirectToAction(nameof(Index));
//            }
//            ViewData["FK_Compra"] = new SelectList(_context.compras, "idCompra", "Precio", userTurismo.FK_Compra);
//            return View(userTurismo);
//        }

//        // GET: UserTurismoes/Edit/5
//        public async Task<IActionResult> Edit(int? id)
//        {
//            if (id == null)
//            {
//                return NotFound();
//            }

//            var userTurismo = await _context.Turismo.FindAsync(id);
//            if (userTurismo == null)
//            {
//                return NotFound();
//            }
//            ViewData["FK_Compra"] = new SelectList(_context.compras, "idCompra", "Precio", userTurismo.FK_Compra);
//            return View(userTurismo);
//        }

//        // POST: UserTurismoes/Edit/5
//        // To protect from overposting attacks, enable the specific properties you want to bind to.
//        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
//        [HttpPost]
//        [ValidateAntiForgeryToken]
//        public async Task<IActionResult> Edit(int id, [Bind("Id,Nombre,Lanzamiento,Propietario,Desarrollador,FK_Compra")] UserTurismo userTurismo)
//        {
//            if (id != userTurismo.Id)
//            {
//                return NotFound();
//            }

//            if (ModelState.IsValid)
//            {
//                try
//                {
//                    _context.Update(userTurismo);
//                    await _context.SaveChangesAsync();
//                }
//                catch (DbUpdateConcurrencyException)
//                {
//                    if (!UserTurismoExists(userTurismo.Id))
//                    {
//                        return NotFound();
//                    }
//                    else
//                    {
//                        throw;
//                    }
//                }
//                return RedirectToAction(nameof(Index));
//            }
//            ViewData["FK_Compra"] = new SelectList(_context.compras, "idCompra", "Precio", userTurismo.FK_Compra);
//            return View(userTurismo);
//        }

//        // GET: UserTurismoes/Delete/5
//        public async Task<IActionResult> Delete(int? id)
//        {
//            if (id == null)
//            {
//                return NotFound();
//            }

//            var userTurismo = await _context.Turismo
//                .Include(u => u.Compras)
//                .FirstOrDefaultAsync(m => m.Id == id);
//            if (userTurismo == null)
//            {
//                return NotFound();
//            }

//            return View(userTurismo);
//        }

//        // POST: UserTurismoes/Delete/5
//        [HttpPost, ActionName("Delete")]
//        [ValidateAntiForgeryToken]
//        public async Task<IActionResult> DeleteConfirmed(int id)
//        {
//            var userTurismo = await _context.Turismo.FindAsync(id);
//            _context.Turismo.Remove(userTurismo);
//            await _context.SaveChangesAsync();
//            return RedirectToAction(nameof(Index));
//        }

//        private bool UserTurismoExists(int id)
//        {
//            return _context.Turismo.Any(e => e.Id == id);
//        }
//    }
//}
