using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using PW3Parcial2ObraDeArte.Data.Entidades;
using PW3Parcial2ObraDeArte.Servicio;

namespace PW3Parcial2ObraDeArte.web.Controllers
{
    public class ObraDeArteController : Controller
    {
        private readonly ModeloEFContext _context;
        private IObraDeArteServicio _iobraDeArteServicio;
        public ObraDeArteController(IObraDeArteServicio iobraDeArteServicio, ModeloEFContext context)
        {
            _iobraDeArteServicio = iobraDeArteServicio;
            _context = context;
        }
        
        // GET: ObraDeArtes
        public IActionResult Index()
        {
            return View(_iobraDeArteServicio.ObtenerSigloVeinte()); 
        }
        public IActionResult GetAll()
        {
            return View(_iobraDeArteServicio.ObtenerTodos());
        }
        // GET: ObraDeArtes/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.ObraDeArtes == null)
            {
                return NotFound();
            }

            var obraDeArte = await _context.ObraDeArtes
                .FirstOrDefaultAsync(m => m.Id == id);
            if (obraDeArte == null)
            {
                return NotFound();
            }

            return View(obraDeArte);
        }

        // GET: ObraDeArtes/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: ObraDeArtes/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Nombre,AnioCreacion")] ObraDeArte obraDeArte)
        {
            if (ModelState.IsValid)
            {
                _context.Add(obraDeArte);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(obraDeArte);
        }

        // GET: ObraDeArtes/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.ObraDeArtes == null)
            {
                return NotFound();
            }

            var obraDeArte = await _context.ObraDeArtes.FindAsync(id);
            if (obraDeArte == null)
            {
                return NotFound();
            }
            return View(obraDeArte);
        }

        // POST: ObraDeArtes/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Nombre,AnioCreacion")] ObraDeArte obraDeArte)
        {
            if (id != obraDeArte.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(obraDeArte);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ObraDeArteExists(obraDeArte.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(obraDeArte);
        }

        // GET: ObraDeArtes/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.ObraDeArtes == null)
            {
                return NotFound();
            }

            var obraDeArte = await _context.ObraDeArtes
                .FirstOrDefaultAsync(m => m.Id == id);
            if (obraDeArte == null)
            {
                return NotFound();
            }

            return View(obraDeArte);
        }

        // POST: ObraDeArtes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.ObraDeArtes == null)
            {
                return Problem("Entity set 'ModeloEFContext.ObraDeArtes'  is null.");
            }
            var obraDeArte = await _context.ObraDeArtes.FindAsync(id);
            if (obraDeArte != null)
            {
                _context.ObraDeArtes.Remove(obraDeArte);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ObraDeArteExists(int id)
        {
          return (_context.ObraDeArtes?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
