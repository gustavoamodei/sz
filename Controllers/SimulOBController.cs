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
    public class SimulOBController : Controller
    {
        private readonly Context1 _context;


        public SimulOBController(Context1 context)
        {
            _context = context;
        }

        // GET: SimulOB
        public async Task<IActionResult> Index()
        {
            var context1 = _context.SimulOB.Include(s => s.OleoBase);
            return View(await context1.ToListAsync());
        }

        // GET: SimulOB/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var simulOB = await _context.SimulOB
                .Include(s => s.OleoBase)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (simulOB == null)
            {
                return NotFound();
            }

            return View(simulOB);
        }

        // GET: SimulOB/Create
        public IActionResult Create()
        {
            try
            {
                var simul_info = JsonConvert.DeserializeObject<SimulSession>(HttpContext.Session.GetString("simulacao_iniciada"));
                if(simul_info.Id == 0)
                {
                    return RedirectToAction("Index", "Simulacao");
                }
            }
            catch (Exception )
            {
                return RedirectToAction("Index", "Simulacao");
            }
            
    
            
            ViewData["OleoBaseId"] = new SelectList(_context.OleoBase, "Id", "Nome");
            return View();
        }

        // POST: SimulOB/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,SimulacaoId,OleoBaseId,Ml")] SimulOB simulOB)
        {
            if (ModelState.IsValid)
            {

                var simul_info = JsonConvert.DeserializeObject<SimulSession>(HttpContext.Session.GetString("simulacao_iniciada"));
                simulOB.SimulacaoId = simul_info.Id;
                _context.Add(simulOB);
                await _context.SaveChangesAsync();
                ViewBag.sucesso = "óleo base incluso com secesso!";
                ViewData["OleoBaseId"] = new SelectList(_context.OleoBase, "Id", "Nome");
                return View();
            }
            ViewData["OleoBaseId"] = new SelectList(_context.OleoBase, "Id", "Nome", simulOB.OleoBaseId);
            return View(simulOB);
        }

        // GET: SimulOB/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var simulOB = await _context.SimulOB.FindAsync(id);
            if (simulOB == null)
            {
                return NotFound();
            }
            ViewData["OleoBaseId"] = new SelectList(_context.OleoBase, "Id", "Nome", simulOB.OleoBaseId);
            return View(simulOB);
        }

        // POST: SimulOB/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,SimulacaoId,OleoBaseId,Ml")] SimulOB simulOB)
        {
            if (id != simulOB.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(simulOB);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!SimulOBExists(simulOB.Id))
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
            ViewData["OleoBaseId"] = new SelectList(_context.OleoBase, "Id", "Nome", simulOB.OleoBaseId);
            return View(simulOB);
        }

        // GET: SimulOB/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var simulOB = await _context.SimulOB
                .Include(s => s.OleoBase)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (simulOB == null)
            {
                return NotFound();
            }

            return View(simulOB);
        }

        // POST: SimulOB/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var simulOB = await _context.SimulOB.FindAsync(id);
            _context.SimulOB.Remove(simulOB);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool SimulOBExists(int id)
        {
            return _context.SimulOB.Any(e => e.Id == id);
        }

        public async Task<IActionResult> VerificaAddOb()
        {
            var simul_info = JsonConvert.DeserializeObject<SimulSession>(HttpContext.Session.GetString("simulacao_iniciada"));

            var jaAddOB = await _context.SimulOB.FirstOrDefaultAsync(m => m.SimulacaoId == simul_info.Id); 
            if (jaAddOB !=  null)
            {
                return RedirectToAction("Create", "SimulOE");
            }
            else
            {
                ViewBag.erro = "Atenção é Obrigatorio minimo 1 oleo base ";
                ViewData["OleoBaseId"] = new SelectList(_context.OleoBase, "Id", "Nome");
                return View("Create");
            }
            
        }
    }
}
