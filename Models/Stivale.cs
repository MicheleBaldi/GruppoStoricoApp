using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace GruppoStoricoApp.Models
{
    public class Stivale
    {
        public int ID { get; set; }
        [Required]
        public int Numero { get; set; }
        [Required]
        public int Taglia { get; set; }
        [Required]
        public int RuoloID { get; set; }
        public Ruolo Ruolo { get; set; }

        public ICollection<PartecipazioneEvento> PartecipazioniEventi { get; set; }
    }
}
