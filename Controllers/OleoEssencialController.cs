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
    public class OleoEssencialController : Controller
    {
        private readonly Context1 _context;

        public OleoEssencialController(Context1 context)
        {
            _context = context;
        }

        // GET: OleoEssencial
        public async Task<IActionResult> Index()
        {
            return View(await _context.OleoEssencial.ToListAsync());
        }

        // GET: OleoEssencial/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var oleoEssencial = await _context.OleoEssencial
                .FirstOrDefaultAsync(m => m.Id == id);
            if (oleoEssencial == null)
            {
                return NotFound();
            }

            return View(oleoEssencial);
        }

        // GET: OleoEssencial/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: OleoEssencial/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Nome,Ml,Valor_Compra,Preco_Gota,Validade")] OleoEssencial oleoEssencial)
        {
            if (ModelState.IsValid)
            {
                _context.Add(oleoEssencial);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(oleoEssencial);
        }

        // GET: OleoEssencial/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var oleoEssencial = await _context.OleoEssencial.FindAsync(id);
            if (oleoEssencial == null)
            {
                return NotFound();
            }
            return View(oleoEssencial);
        }

        // POST: OleoEssencial/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Nome,Ml,Valor_Compra,Preco_Gota,Validade")] OleoEssencial oleoEssencial)
        {
            if (id != oleoEssencial.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(oleoEssencial);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!OleoEssencialExists(oleoEssencial.Id))
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
            return View(oleoEssencial);
        }

        // GET: OleoEssencial/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var oleoEssencial = await _context.OleoEssencial
                .FirstOrDefaultAsync(m => m.Id == id);
            if (oleoEssencial == null)
            {
                return NotFound();
            }

            return View(oleoEssencial);
        }

        // POST: OleoEssencial/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var oleoEssencial = await _context.OleoEssencial.FindAsync(id);
            _context.OleoEssencial.Remove(oleoEssencial);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool OleoEssencialExists(int id)
        {
            return _context.OleoEssencial.Any(e => e.Id == id);
        }
    }
}
