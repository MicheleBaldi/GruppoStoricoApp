using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace GruppoStoricoApp.Models
{
    public class PartecipazioneEvento
    {
        public int PartecipazioneEventoID { get; set; }
        [Required]
        public int EventoID { get; set; }
        [Required]
        public int PersonaId { get; set; }
        [Required]
        public int CalzamagliaId { get; set;  }
        [Required]
        public int CamiciaId { get; set; }
        [Required]
        public int CinturaId { get; set; }
        [Required]
        public int VestitoId { get; set; }
        [Required]
        public int StivaleId { get; set; }
        public Evento Evento { get; set; }
        public Persona Persona { get; set; }
        public Calzamaglia Calzamaglia { get; set; }
        public Camicia Camicia { get; set; }
        public Cintura Cintura { get; set; }
        public Vestito Vestito { get; set; }
        public Stivale Stivale { get; set; }
    }
}
