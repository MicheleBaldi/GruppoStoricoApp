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
    public class PartecipazioneEventoController : Controller
    {
        private readonly ApplicationDbContext _context;

        public PartecipazioneEventoController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: PartecipazioneEvento
        public async Task<IActionResult> Index(int? eventoId)
        {
            var partEv = _context.PartecipazioniEventi
                .Include(p => p.Calzamaglia)
                .Include(p => p.Camicia)
                .Include(p => p.Cintura)
                .Include(p => p.Evento)
                .Include(p => p.Persona)
                .Include(p => p.Stivale)
                .Include(p => p.Vestito)
                .Where(p => p.Evento.ID == eventoId.Value)
                .AsNoTracking();

            ViewData["EventoIdValue"] = eventoId.Value;
            ViewData["Evento"] = _context.Eventi.Where(c => c.ID == eventoId.Value).FirstOrDefaultAsync().Result.NomeEvento;

            return View(await partEv.ToListAsync());
        }

        // GET: PartecipazioneEvento/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var partEv = await _context.PartecipazioniEventi
                .Include(p => p.Calzamaglia)
                .Include(p => p.Camicia)
                .Include(p => p.Cintura)
                .Include(p => p.Evento)
                .Include(p => p.Persona)
                .Include(p => p.Stivale)
                .Include(p => p.Vestito)
                .AsNoTracking()
                .FirstOrDefaultAsync(m => m.PartecipazioneEventoID == id);

            if (partEv == null)
            {
                return NotFound();
            }

            return View(partEv);
        }

        // GET: PartecipazioneEvento/Create
        public IActionResult Create(int ruoloID, int eventoId)
        {
            PopulateDropDownLists(ruoloID, eventoId);
            return View();
        }

        // POST: PartecipazioneEvento/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("PartecipazioneEventoID,EventoID,PersonaId,CalzamagliaId,CamiciaId,CinturaId,VestitoId,StivaleId")] PartecipazioneEvento partecipazioneEvento)
        {
            if (ModelState.IsValid)
            {
                _context.Add(partecipazioneEvento);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index), new { eventoId = partecipazioneEvento.EventoID });
            }
            PopulateDropDownLists(partecipazioneEvento.EventoID, partecipazioneEvento.PersonaId, partecipazioneEvento.CalzamagliaId, partecipazioneEvento.CamiciaId, partecipazioneEvento.CinturaId, partecipazioneEvento.VestitoId, partecipazioneEvento.StivaleId);
            return View(partecipazioneEvento);
        }

        // GET: PartecipazioneEvento/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var partecipazioneEvento = await _context.PartecipazioniEventi.FindAsync(id);
            if (partecipazioneEvento == null)
            {
                return NotFound();
            }
            ViewData["CalzamagliaId"] = new SelectList(_context.Calzamaglie, "ID", "ID", partecipazioneEvento.CalzamagliaId);
            ViewData["CamiciaId"] = new SelectList(_context.Camicie, "ID", "ID", partecipazioneEvento.CamiciaId);
            ViewData["CinturaId"] = new SelectList(_context.Cinture, "ID", "ID", partecipazioneEvento.CinturaId);
            ViewData["EventoID"] = new SelectList(_context.Eventi, "ID", "ID", partecipazioneEvento.EventoID);
            ViewData["PersonaId"] = new SelectList(_context.Persone, "ID", "ID", partecipazioneEvento.PersonaId);
            ViewData["StivaleId"] = new SelectList(_context.Stivali, "ID", "ID", partecipazioneEvento.StivaleId);
            ViewData["VestitoId"] = new SelectList(_context.Vestiti, "ID", "ID", partecipazioneEvento.VestitoId);
            return View(partecipazioneEvento);
        }

        // POST: PartecipazioneEvento/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("PartecipazioneEventoID,EventoID,PersonaId,CalzamagliaId,CamiciaId,CinturaId,VestitoId,StivaleId")] PartecipazioneEvento partecipazioneEvento)
        {
            if (id != partecipazioneEvento.PartecipazioneEventoID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(partecipazioneEvento);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!PartecipazioneEventoExists(partecipazioneEvento.PartecipazioneEventoID))
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
            ViewData["CalzamagliaId"] = new SelectList(_context.Calzamaglie, "ID", "ID", partecipazioneEvento.CalzamagliaId);
            ViewData["CamiciaId"] = new SelectList(_context.Camicie, "ID", "ID", partecipazioneEvento.CamiciaId);
            ViewData["CinturaId"] = new SelectList(_context.Cinture, "ID", "ID", partecipazioneEvento.CinturaId);
            ViewData["EventoID"] = new SelectList(_context.Eventi, "ID", "ID", partecipazioneEvento.EventoID);
            ViewData["PersonaId"] = new SelectList(_context.Persone, "ID", "ID", partecipazioneEvento.PersonaId);
            ViewData["StivaleId"] = new SelectList(_context.Stivali, "ID", "ID", partecipazioneEvento.StivaleId);
            ViewData["VestitoId"] = new SelectList(_context.Vestiti, "ID", "ID", partecipazioneEvento.VestitoId);
            return View(partecipazioneEvento);
        }

        private void PopulateDropDownLists(int ruoloId, int eventoId, object selectedEvento = null, object selectedPersona = null, object selectedCalzamaglia = null, object selectedCamicia = null, object selectedCintura = null, object selectedVestito = null, object selectedStivale = null)
        {
            var eventoQuery = from d in _context.Eventi
                              where d.ID == eventoId
                              orderby d.DataEvento
                              select d;
            ViewBag.EventoID = new SelectList(eventoQuery.AsNoTracking(), "ID", "NomeEvento", selectedEvento);

            var personaQuery = from d in _context.Persone
                               where d.RuoloID == ruoloId
                               orderby d.Nome
                               select d;
            ViewBag.PersonaID = new SelectList(personaQuery.AsNoTracking(), "ID", "Nome", selectedPersona);

            var calzamagliaQuery = from d in _context.Calzamaglie
                                   where d.RuoloID == ruoloId
                                   orderby d.Numero
                                   select d;
            ViewBag.CalzamagliaID = new SelectList(calzamagliaQuery.AsNoTracking(), "ID", "Numero", selectedCalzamaglia);

            var camiciaQuery = from d in _context.Camicie
                               where d.RuoloID == ruoloId
                               orderby d.Numero
                               select d;
            ViewBag.CamiciaID = new SelectList(camiciaQuery.AsNoTracking(), "ID", "Numero", selectedCamicia);

            var cinturaQuery = from d in _context.Cinture
                               where d.RuoloID == ruoloId
                               orderby d.Numero
                               select d;
            ViewBag.CinturaID = new SelectList(cinturaQuery.AsNoTracking(), "ID", "Numero", selectedCintura);

            var vestitoQuery = from d in _context.Vestiti
                               where d.RuoloID == ruoloId
                               orderby d.Numero
                               select d;
            ViewBag.VestitoID = new SelectList(vestitoQuery.AsNoTracking(), "ID", "Numero", selectedVestito);

            var stivaleQuery = from d in _context.Stivali
                               where d.RuoloID == ruoloId
                               orderby d.Numero
                               select d;
            ViewBag.StivaleID = new SelectList(stivaleQuery.AsNoTracking(), "ID", "Numero", selectedStivale);
        }

        // GET: PartecipazioneEvento/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var partecipazioneEvento = await _context.PartecipazioniEventi
                .Include(p => p.Calzamaglia)
                .Include(p => p.Camicia)
                .Include(p => p.Cintura)
                .Include(p => p.Evento)
                .Include(p => p.Persona)
                .Include(p => p.Stivale)
                .Include(p => p.Vestito)
                .FirstOrDefaultAsync(m => m.PartecipazioneEventoID == id);
            if (partecipazioneEvento == null)
            {
                return NotFound();
            }

            return View(partecipazioneEvento);
        }

        // POST: PartecipazioneEvento/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var partecipazioneEvento = await _context.PartecipazioniEventi.FindAsync(id);
            _context.PartecipazioniEventi.Remove(partecipazioneEvento);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool PartecipazioneEventoExists(int id)
        {
            return _context.PartecipazioniEventi.Any(e => e.PartecipazioneEventoID == id);
        }
    }
}
