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
    public class VestitoController : Controller
    {
        private readonly ApplicationDbContext _context;

        public VestitoController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Vestito
        public async Task<IActionResult> Index(int? ruoloId)
        {
            var vestiti = _context.Vestiti
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

            return View(await vestiti.ToListAsync());
        }

        // GET: Vestito/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var vestito = await _context.Vestiti
                .Include(c => c.Ruolo)
                .AsNoTracking()
                .FirstOrDefaultAsync(m => m.ID == id);
            if (vestito == null)
            {
                return NotFound();
            }

            return View(vestito);
        }

        // GET: Vestito/Create
        public IActionResult Create(int? ruoloId)
        {
            PopulateRuoloDropDownList(ruoloId.Value);
            ViewData["RuoloIdValue"] = ruoloId.Value;
            ViewData["Ruolo"] = _context.Ruoli.Where(c => c.ID == ruoloId.Value).FirstOrDefaultAsync().Result.NomeRuolo;
            return View();
        }

        // POST: Vestito/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ID,Numero,Taglia,Note,RuoloID")] Vestito vestito)
        {
            if (ModelState.IsValid)
            {
                _context.Add(vestito);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index), new { ruoloId = vestito.RuoloID });
            }
            PopulateRuoloDropDownList(vestito.RuoloID);
            return View(vestito);
        }

        // GET: Vestito/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var vestito = await _context.Vestiti.
                AsNoTracking().
                FirstOrDefaultAsync(m => m.ID == id);

            if (vestito == null)
            {
                return NotFound();
            }
            ViewData["RuoloIdValue"] = vestito.RuoloID;
            PopulateRuoloDropDownList(vestito.RuoloID);

            return View(vestito);
        }

        // POST: Vestito/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ID,Numero,Taglia,Note,RuoloID")] Vestito vestito)
        {
            if (id != vestito.ID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(vestito);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!VestitoExists(vestito.ID))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index), new { ruoloId = vestito.RuoloID });
            }
            return View(vestito);
        }

        private void PopulateRuoloDropDownList(object selectedRuolo = null)
        {
            var ruoloQuery = from d in _context.Ruoli
                             orderby d.NomeRuolo
                             select d;
            ViewBag.RuoloID = new SelectList(ruoloQuery.AsNoTracking(), "ID", "NomeRuolo", selectedRuolo);
        }

        // GET: Vestito/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var vestito = await _context.Vestiti
                .FirstOrDefaultAsync(m => m.ID == id);
            if (vestito == null)
            {
                return NotFound();
            }
            ViewData["RuoloIdValue"] = vestito.RuoloID;
            return View(vestito);
        }

        // POST: Vestito/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var vestito = await _context.Vestiti.FindAsync(id);
            _context.Vestiti.Remove(vestito);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index), new { ruoloId = vestito.RuoloID });
        }

        private bool VestitoExists(int id)
        {
            return _context.Vestiti.Any(e => e.ID == id);
        }
    }
}