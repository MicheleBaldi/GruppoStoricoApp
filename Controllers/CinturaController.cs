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
    public class CinturaController : Controller
    {
        private readonly ApplicationDbContext _context;

        public CinturaController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Cintura
        public async Task<IActionResult> Index(int? ruoloId)
        {
            var cintura = _context.Cinture
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

            return View(await cintura.ToListAsync());
        }

        // GET: Cintura/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var cintura = await _context.Cinture
                .Include(c => c.Ruolo)
                .AsNoTracking()
                .FirstOrDefaultAsync(m => m.ID == id);
            if (cintura == null)
            {
                return NotFound();
            }

            return View(cintura);
        }

        // GET: Cintura/Create
        public IActionResult Create(int? ruoloId)
        {
            PopulateRuoloDropDownList(ruoloId.Value);
            ViewData["RuoloIdValue"] = ruoloId.Value;
            ViewData["Ruolo"] = _context.Ruoli.Where(c => c.ID == ruoloId.Value).FirstOrDefaultAsync().Result.NomeRuolo;
            return View();
        }

        // POST: Cintura/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ID,Numero,Taglia,RuoloID")] Cintura cintura)
        {
            if (ModelState.IsValid)
            {
                _context.Add(cintura);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index), new { ruoloId = cintura.RuoloID });
            }
            PopulateRuoloDropDownList(cintura.RuoloID);
            return View(cintura);
        }

        // GET: Cintura/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var cintura = await _context.Cinture.FindAsync(id);
            if (cintura == null)
            {
                return NotFound();
            }
            ViewData["RuoloIdValue"] = cintura.RuoloID;
            PopulateRuoloDropDownList(cintura.RuoloID);
            return View(cintura);
        }

        // POST: Cintura/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ID,Numero,Taglia,RuoloID")] Cintura cintura)
        {
            if (id != cintura.ID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(cintura);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!CinturaExists(cintura.ID))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index), new { ruoloId = cintura.RuoloID });
            }
            return View(cintura);
        }

        private void PopulateRuoloDropDownList(object selectedRuolo = null)
        {
            var ruoloQuery = from d in _context.Ruoli
                             orderby d.NomeRuolo
                             select d;
            ViewBag.RuoloID = new SelectList(ruoloQuery.AsNoTracking(), "ID", "NomeRuolo", selectedRuolo);
        }

        // GET: Cintura/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var cintura = await _context.Cinture
                .Include(c => c.Ruolo)
                .FirstOrDefaultAsync(m => m.ID == id);
            if (cintura == null)
            {
                return NotFound();
            }

            return View(cintura);
        }

        // POST: Cintura/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var cintura = await _context.Cinture.FindAsync(id);
            _context.Cinture.Remove(cintura);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool CinturaExists(int id)
        {
            return _context.Cinture.Any(e => e.ID == id);
        }
    }
}