using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using sz.Models;

namespace sz.Controllers
{
    public class AcessorioController : Controller
    {
        private readonly Context1 _context;

        public AcessorioController(Context1 context)
        {
            _context = context;
        }

        // GET: Acessorio
        public async Task<IActionResult> Index()
        {
            return View(await _context.Acessorio.ToListAsync());
        }

        // GET: Acessorio/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var acessorio = await _context.Acessorio
                .FirstOrDefaultAsync(m => m.Id == id);
            if (acessorio == null)
            {
                return NotFound();
            }

            return View(acessorio);
        }

        // GET: Acessorio/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Acessorio/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Nome,Descricao,Preco")] Acessorio acessorio)
        {
            if (ModelState.IsValid)
            {
                _context.Add(acessorio);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(acessorio);
        }

        // GET: Acessorio/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var acessorio = await _context.Acessorio.FindAsync(id);
            if (acessorio == null)
            {
                return NotFound();
            }
            return View(acessorio);
        }

        // POST: Acessorio/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Nome,Descricao,Preco")] Acessorio acessorio)
        {
            if (id != acessorio.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(acessorio);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!AcessorioExists(acessorio.Id))
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
            return View(acessorio);
        }

        // GET: Acessorio/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var acessorio = await _context.Acessorio
                .FirstOrDefaultAsync(m => m.Id == id);
            if (acessorio == null)
            {
                return NotFound();
            }

            return View(acessorio);
        }

        // POST: Acessorio/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var acessorio = await _context.Acessorio.FindAsync(id);
            _context.Acessorio.Remove(acessorio);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool AcessorioExists(int id)
        {
            return _context.Acessorio.Any(e => e.Id == id);
        }
    }
}
