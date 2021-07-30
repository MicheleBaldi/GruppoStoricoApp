using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace GruppoStoricoApp.Models
{
    public class Evento
    {
        public int ID { get; set; }
        [Required]
        [StringLength(200)]
        public string NomeEvento { get; set; }
        [Required]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:dd-MM-yyyy}", ApplyFormatInEditMode = false)]
        public DateTime DataEvento { get; set; }
        public ICollection<PartecipazioneEvento> PartecipazioniEventi { get; set; }
    }
}
