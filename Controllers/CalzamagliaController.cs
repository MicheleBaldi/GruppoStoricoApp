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
    public class CalzamagliaController : Controller
    {
        private readonly ApplicationDbContext _context;

        public CalzamagliaController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Calzamaglia
        public async Task<IActionResult> Index(int? ruoloId)
        {
            var calzamaglia = _context.Calzamaglie
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
            return View(await calzamaglia.ToListAsync());
        }

        // GET: Calzamaglia/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var calzamaglia = await _context.Calzamaglie
                .Include(c => c.Ruolo)
                .AsNoTracking()
                .FirstOrDefaultAsync(m => m.ID == id);
            if (calzamaglia == null)
            {
                return NotFound();
            }

            return View(calzamaglia);
        }

        // GET: Calzamaglia/Create
        public IActionResult Create(int? ruoloId)
        {
            PopulateRuoloDropDownList(ruoloId.Value);
            ViewData["RuoloIdValue"] = ruoloId.Value;
            ViewData["Ruolo"] = _context.Ruoli.Where(c => c.ID == ruoloId.Value).FirstOrDefaultAsync().Result.NomeRuolo;
            return View();
        }

        // POST: Calzamaglia/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ID,Numero,Taglia,RuoloID")] Calzamaglia calzamaglia)
        {
            if (ModelState.IsValid)
            {
                _context.Add(calzamaglia);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index), new { ruoloId = calzamaglia.RuoloID });
            }
            PopulateRuoloDropDownList(calzamaglia.RuoloID);
            return View(calzamaglia);
        }

        // GET: Calzamaglia/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var calzamaglia = await _context.Calzamaglie.FindAsync(id);
            if (calzamaglia == null)
            {
                return NotFound();
            }
            ViewData["RuoloID"] = new SelectList(_context.Ruoli, "ID", "ID", calzamaglia.RuoloID);
            return View(calzamaglia);
        }

        // POST: Calzamaglia/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ID,Numero,Taglia,RuoloID")] Calzamaglia calzamaglia)
        {
            if (id != calzamaglia.ID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(calzamaglia);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!CalzamagliaExists(calzamaglia.ID))
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
            ViewData["RuoloID"] = new SelectList(_context.Ruoli, "ID", "ID", calzamaglia.RuoloID);
            return View(calzamaglia);
        }

        private void PopulateRuoloDropDownList(object selectedRuolo = null)
        {
            var ruoloQuery = from d in _context.Ruoli
                             orderby d.NomeRuolo
                             select d;
            ViewBag.RuoloID = new SelectList(ruoloQuery.AsNoTracking(), "ID", "NomeRuolo", selectedRuolo);
        }

        // GET: Calzamaglia/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var calzamaglia = await _context.Calzamaglie
                .Include(c => c.Ruolo)
                .FirstOrDefaultAsync(m => m.ID == id);
            if (calzamaglia == null)
            {
                return NotFound();
            }

            return View(calzamaglia);
        }

        // POST: Calzamaglia/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var calzamaglia = await _context.Calzamaglie.FindAsync(id);
            _context.Calzamaglie.Remove(calzamaglia);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool CalzamagliaExists(int id)
        {
            return _context.Calzamaglie.Any(e => e.ID == id);
        }
    }
}
