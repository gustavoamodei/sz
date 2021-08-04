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
    public class FrascoController : Controller
    {
        private readonly Context1 _context;

        public FrascoController(Context1 context)
        {
            _context = context;
        }

        // GET: Frasco
        public async Task<IActionResult> Index()
        {
            return View(await _context.Frasco.ToListAsync());
        }

        // GET: Frasco/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var frasco = await _context.Frasco
                .FirstOrDefaultAsync(m => m.Id == id);
            if (frasco == null)
            {
                return NotFound();
            }

            return View(frasco);
        }

        // GET: Frasco/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Frasco/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Nome,Descricao,Preco")] Frasco frasco)
        {
            if (ModelState.IsValid)
            {
                //string a= frasco.Preco.ToString().Replace("50", "40");
                //frasco.Preco = decimal.Parse(a);
                _context.Add(frasco);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(frasco);
        }

        // GET: Frasco/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var frasco = await _context.Frasco.FindAsync(id);
            if (frasco == null)
            {
                return NotFound();
            }
            return View(frasco);
        }

        // POST: Frasco/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Nome,Descricao,Preco")] Frasco frasco)
        {
            if (id != frasco.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(frasco);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!FrascoExists(frasco.Id))
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
            return View(frasco);
        }

        // GET: Frasco/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var frasco = await _context.Frasco
                .FirstOrDefaultAsync(m => m.Id == id);
            if (frasco == null)
            {
                return NotFound();
            }

            return View(frasco);
        }

        // POST: Frasco/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var frasco = await _context.Frasco.FindAsync(id);
            _context.Frasco.Remove(frasco);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool FrascoExists(int id)
        {
            return _context.Frasco.Any(e => e.Id == id);
        }
    }
}
