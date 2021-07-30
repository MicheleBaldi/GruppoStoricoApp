using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using GruppoStoricoApp.Data;
using GruppoStoricoApp.Models;
using Microsoft.AspNetCore.Authorization;

namespace GruppoStoricoApp.Controllers
{
    [Authorize]
    public class StivaleController : Controller
    {
        private readonly ApplicationDbContext _context;

        public StivaleController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Stivale
        public async Task<IActionResult> Index(int? ruoloId)
        {
            var stivale = _context.Stivali
               .Include(c => c.Ruolo)
               .Where(c => c.RuoloID == ruoloId.Value)
               .AsNoTracking();

            switch (ruoloId.Value)
            {
                case 1:
                    ViewData["RuoliLista"] = "Sbandieratori";
                    break;
                case 2:
                    ViewData["RuoliLista"] = "Tamburi";
                    break;
                case 3:
                    ViewData["RuoliLista"] = "Chiarine";
                    break;
                default:
                    break;
            }
            ViewData["RuoloId"] = ruoloId.Value;
            ViewData["Ruolo"] = _context.Ruoli.Where(c => c.ID == ruoloId.Value).FirstOrDefaultAsync().Result.NomeRuolo;
            return View(await stivale.ToListAsync());
        }

        // GET: Stivale/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var stivale = await _context.Stivali
                .Include(c => c.Ruolo)
                .AsNoTracking()
                .FirstOrDefaultAsync(m => m.ID == id);
            if (stivale == null)
            {
                return NotFound();
            }

            return View(stivale);
        }

        // GET: Stivale/Create
        public IActionResult Create(int? ruoloId)
        {
            PopulateRuoloDropDownList(ruoloId.Value);
            ViewData["RuoloIdValue"] = ruoloId.Value;
            ViewData["Ruolo"] = _context.Ruoli.Where(c => c.ID == ruoloId.Value).FirstOrDefaultAsync().Result.NomeRuolo;
            return View();
        }

        // POST: Stivale/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ID,Numero,Taglia,RuoloID")] Stivale stivale)
        {
            if (ModelState.IsValid)
            {
                _context.Add(stivale);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index), new { ruoloId = stivale.RuoloID });
            }
            PopulateRuoloDropDownList(stivale.RuoloID);
            return View(stivale);
        }

        // GET: Stivale/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var stivale = await _context.Stivali.FindAsync(id);
            if (stivale == null)
            {
                return NotFound();
            }
            ViewData["RuoloID"] = new SelectList(_context.Ruoli, "ID", "ID", stivale.RuoloID);
            return View(stivale);
        }

        // POST: Stivale/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ID,Numero,Taglia,RuoloID")] Stivale stivale)
        {
            if (id != stivale.ID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(stivale);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!StivaleExists(stivale.ID))
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
            ViewData["RuoloID"] = new SelectList(_context.Ruoli, "ID", "ID", stivale.RuoloID);
            return View(stivale);
        }

        private void PopulateRuoloDropDownList(object selectedRuolo = null)
        {
            var ruoloQuery = from d in _context.Ruoli
                             orderby d.NomeRuolo
                             select d;
            ViewBag.RuoloID = new SelectList(ruoloQuery.AsNoTracking(), "ID", "NomeRuolo", selectedRuolo);
        }

        // GET: Stivale/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var stivale = await _context.Stivali
                .Include(s => s.Ruolo)
                .FirstOrDefaultAsync(m => m.ID == id);
            if (stivale == null)
            {
                return NotFound();
            }

            return View(stivale);
        }

        // POST: Stivale/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var stivale = await _context.Stivali.FindAsync(id);
            _context.Stivali.Remove(stivale);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool StivaleExists(int id)
        {
            return _context.Stivali.Any(e => e.ID == id);
        }
    }
}
