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
    public class VestitoCompletoPersonaController : Controller
    {
        private readonly ApplicationDbContext _context;

        public VestitoCompletoPersonaController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: VestitoCompletoPersona
        public async Task<IActionResult> Index(string filterRuolo)
        {
            var vesPer = _context.VestitoCompletoPersona
                .Include(v => v.Calzamaglia)
                .Include(v => v.Camicia)
                .Include(v => v.Cintura)
                .Include(v => v.Persona)
                .ThenInclude(r => r.Ruolo)
                .Include(v => v.Stivale)
                .Include(v => v.Vestito)
                .AsNoTracking();

            if (!string.IsNullOrEmpty(filterRuolo))
            {
                vesPer = vesPer.Where(s => s.Persona.RuoloID == int.Parse(filterRuolo));
            }
            PopulateRuoloDropDownList(filterRuolo);

            return View(await vesPer.ToListAsync());
        }

        // GET: VestitoCompletoPersona/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var vesPer = await _context.VestitoCompletoPersona
                .Include(p => p.Calzamaglia)
                .Include(p => p.Camicia)
                .Include(p => p.Cintura)
                .Include(p => p.Persona)
                .ThenInclude(r => r.Ruolo)
                .Include(p => p.Stivale)
                .Include(p => p.Vestito)
                .AsNoTracking()
                .FirstOrDefaultAsync(m => m.VestitoCompletoPersonaID == id);

            if (vesPer == null)
            {
                return NotFound();
            }

            return View(vesPer);
        }

        // GET: VestitoCompletoPersona/Create
        public IActionResult Create(int ruoloID)
        {
            PopulateDropDownLists(ruoloID);
            return View();
        }

        // POST: VestitoCompletoPersona/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("VestitoCompletoPersonaID,PersonaId,CalzamagliaId,CamiciaId,CinturaId,VestitoId,StivaleId")] VestitoCompletoPersona vestitoCompletoPersona)
        {   
            if (ModelState.IsValid)
            {
                _context.Add(vestitoCompletoPersona);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            PopulateDropDownLists(0, vestitoCompletoPersona.PersonaId, vestitoCompletoPersona.CalzamagliaId, vestitoCompletoPersona.CamiciaId, vestitoCompletoPersona.CinturaId, vestitoCompletoPersona.VestitoId, vestitoCompletoPersona.StivaleId);
            return View(vestitoCompletoPersona);
        }

        // GET: VestitoCompletoPersona/Edit/5
        public async Task<IActionResult> Edit(int? id, int ruoloId)
        {
            if (id == null)
            {
                return NotFound();
            }

            var vestitoCompletoPersona = await _context.VestitoCompletoPersona.FindAsync(id);
            if (vestitoCompletoPersona == null)
            {
                return NotFound();
            }
            ViewData["CalzamagliaId"] = new SelectList(_context.Calzamaglie, "ID", "Taglia", vestitoCompletoPersona.CalzamagliaId);
            ViewData["CamiciaId"] = new SelectList(_context.Camicie, "ID", "Taglia", vestitoCompletoPersona.CamiciaId);
            ViewData["CinturaId"] = new SelectList(_context.Cinture, "ID", "Taglia", vestitoCompletoPersona.CinturaId);
            ViewData["PersonaId"] = new SelectList(_context.Persone, "ID", "Cognome", vestitoCompletoPersona.PersonaId);
            ViewData["StivaleId"] = new SelectList(_context.Stivali, "ID", "ID", vestitoCompletoPersona.StivaleId);
            ViewData["VestitoId"] = new SelectList(_context.Vestiti, "ID", "Taglia", vestitoCompletoPersona.VestitoId);

            PopulateDropDownLists(ruoloId, vestitoCompletoPersona.PersonaId, vestitoCompletoPersona.CalzamagliaId, vestitoCompletoPersona.CamiciaId, vestitoCompletoPersona.CinturaId, vestitoCompletoPersona.VestitoId, vestitoCompletoPersona.StivaleId);

            return View(vestitoCompletoPersona);
        }

        // POST: VestitoCompletoPersona/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("VestitoCompletoPersonaID,PersonaId,CalzamagliaId,CamiciaId,CinturaId,VestitoId,StivaleId")] VestitoCompletoPersona vestitoCompletoPersona)
        {
            if (id != vestitoCompletoPersona.VestitoCompletoPersonaID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(vestitoCompletoPersona);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!VestitoCompletoPersonaExists(vestitoCompletoPersona.VestitoCompletoPersonaID))
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
            ViewData["CalzamagliaId"] = new SelectList(_context.Calzamaglie, "ID", "Taglia", vestitoCompletoPersona.CalzamagliaId);
            ViewData["CamiciaId"] = new SelectList(_context.Camicie, "ID", "Taglia", vestitoCompletoPersona.CamiciaId);
            ViewData["CinturaId"] = new SelectList(_context.Cinture, "ID", "Taglia", vestitoCompletoPersona.CinturaId);
            ViewData["PersonaId"] = new SelectList(_context.Persone, "ID", "Cognome", vestitoCompletoPersona.PersonaId);
            ViewData["StivaleId"] = new SelectList(_context.Stivali, "ID", "ID", vestitoCompletoPersona.StivaleId);
            ViewData["VestitoId"] = new SelectList(_context.Vestiti, "ID", "Taglia", vestitoCompletoPersona.VestitoId);
            return View(vestitoCompletoPersona);
        }

        // GET: VestitoCompletoPersona/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var vestitoCompletoPersona = await _context.VestitoCompletoPersona
                .Include(v => v.Calzamaglia)
                .Include(v => v.Camicia)
                .Include(v => v.Cintura)
                .Include(v => v.Persona)
                .Include(v => v.Stivale)
                .Include(v => v.Vestito)
                .FirstOrDefaultAsync(m => m.VestitoCompletoPersonaID == id);
            if (vestitoCompletoPersona == null)
            {
                return NotFound();
            }

            return View(vestitoCompletoPersona);
        }

        // POST: VestitoCompletoPersona/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var vestitoCompletoPersona = await _context.VestitoCompletoPersona.FindAsync(id);
            _context.VestitoCompletoPersona.Remove(vestitoCompletoPersona);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool VestitoCompletoPersonaExists(int id)
        {
            return _context.VestitoCompletoPersona.Any(e => e.VestitoCompletoPersonaID == id);
        }

        private void PopulateDropDownLists(int ruoloId, object selectedPersona = null, object selectedCalzamaglia = null, object selectedCamicia = null, object selectedCintura = null, object selectedVestito = null, object selectedStivale = null)
        {
            var personaQuery = from d in _context.Persone
                               //from pe in _context.PartecipazioniEventi
                               //.Where(pe => pe.PersonaId == d.ID ).DefaultIfEmpty()
                               where d.RuoloID == ruoloId
                               orderby d.Nome
                               select new
                               {
                                   ID = d.ID,
                                   Nome = d.Nome + " " + d.Cognome
                               };
            ViewBag.PersonaID = new SelectList(personaQuery.AsNoTracking(), "ID", "Nome", selectedPersona);

            var calzamagliaQuery = from d in _context.Calzamaglie
                                   from pe in _context.PartecipazioniEventi
                                   .Where(pe => pe.CalzamagliaId == d.ID ).DefaultIfEmpty()
                                   where d.RuoloID == ruoloId
                                   orderby d.Numero
                                   select d;

            ViewBag.CalzamagliaID = new SelectList(calzamagliaQuery.AsNoTracking(), "ID", "Numero", selectedCalzamaglia);

            var camiciaQuery = from d in _context.Camicie
                               from pe in _context.PartecipazioniEventi
                               .Where(pe => pe.CamiciaId == d.ID ).DefaultIfEmpty()
                               where d.RuoloID == ruoloId 
                               orderby d.Numero
                               select d;
            ViewBag.CamiciaID = new SelectList(camiciaQuery.AsNoTracking(), "ID", "Numero", selectedCamicia);

            var cinturaQuery = from d in _context.Cinture
                               from pe in _context.PartecipazioniEventi
                               .Where(pe => pe.CinturaId == d.ID ).DefaultIfEmpty()
                               where d.RuoloID == ruoloId 
                               orderby d.Numero
                               select d;
            ViewBag.CinturaID = new SelectList(cinturaQuery.AsNoTracking(), "ID", "Numero", selectedCintura);

            var vestitoQuery = from d in _context.Vestiti
                               from pe in _context.PartecipazioniEventi
                               .Where(pe => pe.VestitoId == d.ID ).DefaultIfEmpty()
                               where d.RuoloID == ruoloId 
                               orderby d.Numero
                               select d;
            ViewBag.VestitoID = new SelectList(vestitoQuery.AsNoTracking(), "ID", "Numero", selectedVestito);

            var stivaleQuery = from d in _context.Stivali
                               from pe in _context.PartecipazioniEventi
                               .Where(pe => pe.StivaleId == d.ID ).DefaultIfEmpty()
                               where d.RuoloID == ruoloId 
                               orderby d.Numero
                               select d;
            ViewBag.StivaleID = new SelectList(stivaleQuery.AsNoTracking(), "ID", "Numero", selectedStivale);
        }

        private void PopulateRuoloDropDownList(object selectedRuolo = null)
        {
            var ruoloQuery = from d in _context.Ruoli
                             orderby d.NomeRuolo
                             select d;
            ViewBag.RuoloID = new SelectList(ruoloQuery.AsNoTracking(), "ID", "NomeRuolo", selectedRuolo);
        }
    }
}
