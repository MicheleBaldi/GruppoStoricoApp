using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace GruppoStoricoApp.Models
{
    public class Persona
    {
        public int ID { get; set; }
        [Required]
        [StringLength(100)]
        public string Nome { get; set; }
        [Required]
        [StringLength(100)]
        public string Cognome { get; set; }
        [Required]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:dd-MM-yyyy}", ApplyFormatInEditMode = false)]
        public DateTime DataNascita { get; set; }
        public string Email { get; set; }
        public string Profilo { get; set; }
        [Required]
        public int RuoloID { get; set; }
        public Ruolo Ruolo { get; set; }

        public ICollection<PartecipazioneEvento> PartecipazioniEventi { get; set; }

    }
}
