using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GruppoStoricoApp.Models
{
    public class Ruolo
    {
        public int ID { get; set; }
        public string NomeRuolo { get; set; }
        public ICollection<Persona> Persone { get; set; }
    }
}
