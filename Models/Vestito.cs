using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace GruppoStoricoApp.Models
{
    public class Vestito
    {
        public int ID { get; set; }
        [Required]
        public int Numero { get; set; }
        [Required]
        [StringLength(10)]
        public string Taglia { get; set; }
        [Required]
        public int RuoloID { get; set; }
        [StringLength(500)]
        public string Note { get; set; }
        public Ruolo Ruolo { get; set; }

        public ICollection<PartecipazioneEvento> PartecipazioniEventi { get; set; }
    }
}
