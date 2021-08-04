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
    public class SimulOEController : Controller
    {
        private readonly Context1 _context;

        public SimulOEController(Context1 context)
        {
            _context = context;
        }

        // GET: SimulOE
        public async Task<IActionResult> Index()
        {
            var context1 = _context.SimulOE.Include(s => s.OleoEssencial);
            return View(await context1.ToListAsync());
        }

        // GET: SimulOE/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var simulOE = await _context.SimulOE
                .Include(s => s.OleoEssencial)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (simulOE == null)
            {
                return NotFound();
            }

            return View(simulOE);
        }

        // GET: SimulOE/Create
        public IActionResult Create()
        {
            try
            {
                var simul_info = JsonConvert.DeserializeObject<SimulSession>(HttpContext.Session.GetString("simulacao_iniciada"));
                if (simul_info.Id == 0)
                {
                    return RedirectToAction("Index", "Simulacao");
                }
            }
            catch (Exception)
            {
                return RedirectToAction("Index", "Simulacao");
            }
            ViewData["OleoEssencialId"] = new SelectList(_context.OleoEssencial, "Id", "Nome");
            return View();
        }

        // POST: SimulOE/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,SimulacaoId,OleoEssencialId,GotasOE")] SimulOE simulOE)
        {
            if (ModelState.IsValid)
            {
                var simul_info = JsonConvert.DeserializeObject<SimulSession>(HttpContext.Session.GetString("simulacao_iniciada"));
                simulOE.SimulacaoId = simul_info.Id;
                _context.Add(simulOE);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["OleoEssencialId"] = new SelectList(_context.OleoEssencial, "Id", "Nome", simulOE.OleoEssencialId);
            return View(simulOE);
        }

        // GET: SimulOE/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var simulOE = await _context.SimulOE.FindAsync(id);
            if (simulOE == null)
            {
                return NotFound();
            }
            ViewData["OleoEssencialId"] = new SelectList(_context.OleoEssencial, "Id", "Nome", simulOE.OleoEssencialId);
            return View(simulOE);
        }

        // POST: SimulOE/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,SimulacaoId,OleoEssencialId,GotasOE")] SimulOE simulOE)
        {
            if (id != simulOE.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(simulOE);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!SimulOEExists(simulOE.Id))
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
            ViewData["OleoEssencialId"] = new SelectList(_context.OleoEssencial, "Id", "Nome", simulOE.OleoEssencialId);
            return View(simulOE);
        }

        // GET: SimulOE/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var simulOE = await _context.SimulOE
                .Include(s => s.OleoEssencial)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (simulOE == null)
            {
                return NotFound();
            }

            return View(simulOE);
        }

        // POST: SimulOE/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var simulOE = await _context.SimulOE.FindAsync(id);
            _context.SimulOE.Remove(simulOE);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool SimulOEExists(int id)
        {
            return _context.SimulOE.Any(e => e.Id == id);
        }

        public async Task<IActionResult> VerificaAddOe()
        {
            var simul_info = JsonConvert.DeserializeObject<SimulSession>(HttpContext.Session.GetString("simulacao_iniciada"));

            var jaAddOE = await _context.SimulOE.FirstOrDefaultAsync(m => m.SimulacaoId == simul_info.Id); ;
            if (jaAddOE != null)
            {
                SimulSession s = new SimulSession();
                s.Id = 0;
                s.UserId = 0;
                HttpContext.Session.SetString("simulacao_iniciada", JsonConvert.SerializeObject(s));
                return RedirectToAction("Simulacao");

            }
            else
            {
                ViewBag.erro = "Atenção é Obrigatorio minimo 1 oleo Essencial ";
                ViewData["OleoEssencialId"] = new SelectList(_context.OleoEssencial, "Id", "Nome");
                return View("Create");
            }

        }
    }
}
