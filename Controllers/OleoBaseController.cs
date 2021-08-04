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
    public class OleoBaseController : Controller
    {
        private readonly Context1 _context;

        public OleoBaseController(Context1 context)
        {
            _context = context;
        }

        // GET: OleoBase
        public async Task<IActionResult> Index()
        {
            return View(await _context.OleoBase.ToListAsync());
        }

        // GET: OleoBase/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var oleoBase = await _context.OleoBase
                .FirstOrDefaultAsync(m => m.Id == id);
            if (oleoBase == null)
            {
                return NotFound();
            }

            return View(oleoBase);
        }

        // GET: OleoBase/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: OleoBase/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Nome,Ml,Valor_Compra,Preco_ml,Validade")] OleoBase oleoBase)
        {
            if (ModelState.IsValid)
            {
                oleoBase.Preco_ml= (oleoBase.Ml/oleoBase.Valor_Compra);
                _context.Add(oleoBase);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(oleoBase);
        }

        // GET: OleoBase/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var oleoBase = await _context.OleoBase.FindAsync(id);
            if (oleoBase == null)
            {
                return NotFound();
            }
            return View(oleoBase);
        }

        // POST: OleoBase/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Nome,Ml,Valor_Compra,Preco_ml,Validade")] OleoBase oleoBase)
        {
            if (id != oleoBase.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(oleoBase);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!OleoBaseExists(oleoBase.Id))
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
            return View(oleoBase);
        }

        // GET: OleoBase/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var oleoBase = await _context.OleoBase
                .FirstOrDefaultAsync(m => m.Id == id);
            if (oleoBase == null)
            {
                return NotFound();
            }

            return View(oleoBase);
        }

        // POST: OleoBase/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var oleoBase = await _context.OleoBase.FindAsync(id);
            _context.OleoBase.Remove(oleoBase);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool OleoBaseExists(int id)
        {
            return _context.OleoBase.Any(e => e.Id == id);
        }
    }
}
