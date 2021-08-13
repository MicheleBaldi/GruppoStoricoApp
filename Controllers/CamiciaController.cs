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
    public class CamiciaController : Controller
    {
        private readonly ApplicationDbContext _context;

        public CamiciaController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Camicia
        public async Task<IActionResult> Index(int? ruoloId)
        {
            var camicia = _context.Camicie
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

            return View(await camicia.ToListAsync());
        }

        // GET: Camicia/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var camicia = await _context.Camicie
                .Include(c => c.Ruolo)
                .AsNoTracking()
                .FirstOrDefaultAsync(m => m.ID == id);
            if (camicia == null)
            {
                return NotFound();
            }

            return View(camicia);
        }

        // GET: Camicia/Create
        public IActionResult Create(int? ruoloId)
        {
            PopulateRuoloDropDownList(ruoloId.Value);
            ViewData["RuoloIdValue"] = ruoloId.Value;
            ViewData["Ruolo"] = _context.Ruoli.Where(c => c.ID == ruoloId.Value).FirstOrDefaultAsync().Result.NomeRuolo;
            return View();
        }

        // POST: Camicia/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ID,Numero,Taglia,RuoloID")] Camicia camicia)
        {
            if (ModelState.IsValid)
            {
                _context.Add(camicia);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index), new { ruoloId = camicia.RuoloID });
            }
            PopulateRuoloDropDownList(camicia.RuoloID);
            return View(camicia);
        }

        // GET: Camicia/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var camicia = await _context.Camicie.FindAsync(id);
            if (camicia == null)
            {
                return NotFound();
            }
            ViewData["RuoloIdValue"] = camicia.RuoloID;
            PopulateRuoloDropDownList(camicia.RuoloID);
            return View(camicia);
        }

        // POST: Camicia/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ID,Numero,Taglia,RuoloID")] Camicia camicia)
        {
            if (id != camicia.ID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(camicia);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!CamiciaExists(camicia.ID))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index), new { ruoloId = camicia.RuoloID });
            }
            return View(camicia);
        }

        private void PopulateRuoloDropDownList(object selectedRuolo = null)
        {
            var ruoloQuery = from d in _context.Ruoli
                             orderby d.NomeRuolo
                             select d;
            ViewBag.RuoloID = new SelectList(ruoloQuery.AsNoTracking(), "ID", "NomeRuolo", selectedRuolo);
        }
        // GET: Camicia/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var camicia = await _context.Camicie
                .Include(c => c.Ruolo)
                .FirstOrDefaultAsync(m => m.ID == id);
            if (camicia == null)
            {
                return NotFound();
            }

            return View(camicia);
        }

        // POST: Camicia/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var camicia = await _context.Camicie.FindAsync(id);
            _context.Camicie.Remove(camicia);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool CamiciaExists(int id)
        {
            return _context.Camicie.Any(e => e.ID == id);
        }
    }
}
