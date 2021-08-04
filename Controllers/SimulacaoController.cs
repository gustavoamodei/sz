using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using sz.Models;

namespace sz.Controllers
{
    public class SimulacaoController : Controller
    {
        private readonly Context1 _context;

        public SimulacaoController(Context1 context)
        {
            _context = context;
        }

        // GET: Simulacao
        public async Task<IActionResult> Index()
        {
            var context1 = _context.Simulacao.Include(s => s.Acessorio).Include(s => s.Cliente).Include(s => s.Frasco).AsNoTracking(); 
            return View(await context1.ToListAsync());
        }

        // GET: Simulacao/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var simulacao = await _context.Simulacao
                .Include(s => s.Acessorio)
                .Include(s => s.Cliente)
                .Include(s => s.Frasco)
                .Include(s => s.SimulOB)
                .ThenInclude(s=>s.OleoBase)
                .Include(s=>s.SimulOE)
                .ThenInclude(s=>s.OleoEssencial)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (simulacao == null)
            {
                return NotFound();
            }

            return View(simulacao);
        }

        // GET: Simulacao/Create
        public IActionResult Create()
        {
            ViewData["AcessorioId"] = new SelectList(_context.Acessorio, "Id", "Nome");
            ViewData["ClienteId"] = new SelectList(_context.Cliente, "Id", "Nome");
            ViewData["FrascoId"] = new SelectList(_context.Frasco, "Id", "Nome");
            return View();
        }

        // POST: Simulacao/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,FrascoId,AcessorioId,ClienteId,NomeSimulacao,Ml_por_cento,Ml_oleo_essencial,Lucro,Preco_Parcial,Margem_lucro,Total")] Simulacao simulacao)
        {
            if (ModelState.IsValid)
            {
                _context.Add(simulacao);
                await _context.SaveChangesAsync();
                SimulSession s = new SimulSession();
                s.Id = simulacao.Id;
                s.UserId = simulacao.ClienteId;
                HttpContext.Session.SetString ("simulacao_iniciada",JsonConvert.SerializeObject (s));
                return RedirectToAction("Create","SimulOb");
            }
            ViewData["AcessorioId"] = new SelectList(_context.Acessorio, "Id", "Nome", simulacao.AcessorioId);
            ViewData["ClienteId"] = new SelectList(_context.Cliente, "Id", "Nome", simulacao.ClienteId);
            ViewData["FrascoId"] = new SelectList(_context.Frasco, "Id", "Nome", simulacao.FrascoId);
            return View(simulacao);
        }

        // GET: Simulacao/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var simulacao = await _context.Simulacao.FindAsync(id);
            if (simulacao == null)
            {
                return NotFound();
            }
            ViewData["AcessorioId"] = new SelectList(_context.Acessorio, "Id", "Nome", simulacao.AcessorioId);
            ViewData["ClienteId"] = new SelectList(_context.Cliente, "Id", "Nome", simulacao.ClienteId);
            ViewData["FrascoId"] = new SelectList(_context.Frasco, "Id", "Nome", simulacao.FrascoId);
            return View(simulacao);
        }

        // POST: Simulacao/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,FrascoId,AcessorioId,ClienteId,NomeSimulacao,Ml_por_cento,Ml_oleo_essencial,Lucro,Preco_Parcial,Margem_lucro,Total")] Simulacao simulacao)
        {
            if (id != simulacao.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(simulacao);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!SimulacaoExists(simulacao.Id))
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
            ViewData["AcessorioId"] = new SelectList(_context.Acessorio, "Id", "Nome", simulacao.AcessorioId);
            ViewData["ClienteId"] = new SelectList(_context.Cliente, "Id", "Nome", simulacao.ClienteId);
            ViewData["FrascoId"] = new SelectList(_context.Frasco, "Id", "Nome", simulacao.FrascoId);
            return View(simulacao);
        }

        // GET: Simulacao/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var simulacao = await _context.Simulacao
                .Include(s => s.Acessorio)
                .Include(s => s.Cliente)
                .Include(s => s.Frasco)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (simulacao == null)
            {
                return NotFound();
            }

            return View(simulacao);
        }

        // POST: Simulacao/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var simulacao = await _context.Simulacao.FindAsync(id);
            _context.Simulacao.Remove(simulacao);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool SimulacaoExists(int id)
        {
            return _context.Simulacao.Any(e => e.Id == id);
        }
    }
}
