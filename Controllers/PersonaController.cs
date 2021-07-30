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
    public class PersonaController : Controller
    {
        private readonly ApplicationDbContext _context;

        public PersonaController(ApplicationDbContext context)
        {
            _context = context;
        }


        // GET: Persona
        public async Task<IActionResult> Index(int? ruoloId)
        {
            var persone = _context.Persone
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

            return View(await persone.ToListAsync());
        }

        // GET: Persona/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var persona = await _context.Persone
                .Include(c => c.Ruolo)
                .AsNoTracking()
                .FirstOrDefaultAsync(m => m.ID == id);
            if (persona == null)
            {
                return NotFound();
            }
            ViewData["RuoloIdValue"] = persona.RuoloID;

            return View(persona);
        }

        // GET: Persona/Create
        public IActionResult Create(int? ruoloId)
        {
            PopulateRuoloDropDownList(ruoloId.Value);
            ViewData["RuoloIdValue"] = ruoloId.Value;
            ViewData["Ruolo"] = _context.Ruoli.Where(c => c.ID == ruoloId.Value).FirstOrDefaultAsync().Result.NomeRuolo;
            return View();
        }

        // POST: Persona/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ID,Nome,Cognome,DataNascita,Email,Profilo,RuoloID")] Persona persona)
        {
            if (ModelState.IsValid)
            {
                _context.Add(persona);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index), new { ruoloId = persona.RuoloID });
            }
            PopulateRuoloDropDownList(persona.RuoloID);
            return View(persona);
        }

        // GET: Persona/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var persona = await _context.Persone.
                AsNoTracking().
                FirstOrDefaultAsync(m => m.ID == id);
            if (persona == null)
            {
                return NotFound();
            }
            ViewData["RuoloIdValue"] = persona.RuoloID;
            PopulateRuoloDropDownList(persona.RuoloID);
            return View(persona);
        }

        // POST: Persona/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost, ActionName("Edit")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> EditPost(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var personaToUpdate = await _context.Persone.
                FirstOrDefaultAsync(c => c.ID == id);
            if (await TryUpdateModelAsync<Persona>(personaToUpdate,
                "",
                c => c.Nome, c => c.Cognome, c => c.DataNascita, c => c.Email, c => c.Profilo, c => c.RuoloID))
            {
                try
                {
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateException)
                {
                    //Log the error (uncomment ex variable name and write a log.)
                    ModelState.AddModelError("", "Unable to save changes. " +
                        "Try again, and if the problem persists, " +
                        "see your system administrator.");
                }
                return RedirectToAction(nameof(Index), new { ruoloId = personaToUpdate.RuoloID });
            }
            PopulateRuoloDropDownList(personaToUpdate.RuoloID);
            return View(personaToUpdate);
        }
        private void PopulateRuoloDropDownList(object selectedRuolo = null)
        {
            var ruoloQuery = from d in _context.Ruoli
                             orderby d.NomeRuolo
                             select d;
            ViewBag.RuoloID = new SelectList(ruoloQuery.AsNoTracking(), "ID", "NomeRuolo", selectedRuolo);
        }
        // GET: Persona/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var persona = await _context.Persone
                .Include(c => c.Ruolo)
                .FirstOrDefaultAsync(m => m.ID == id);
            if (persona == null)
            {
                return NotFound();
            }

            return View(persona);
        }

        // POST: Persona/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var persona = await _context.Persone.FindAsync(id);
            var ruoloId = persona.RuoloID;
            _context.Persone.Remove(persona);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index), new { ruoloId = ruoloId });
        }

        private bool PersonaExists(int id)
        {
            return _context.Persone.Any(e => e.ID == id);
        }
    }
}
