using GruppoStoricoApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GruppoStoricoApp.Data
{
    public class DbInitializer
    {
        public static void Initialize(ApplicationDbContext context)
        {
            context.Database.EnsureCreated();

            // Look for any students.
            if (context.Ruoli.Any())
            {
                return;   // DB has been seeded
            }

            var ruoli = new Ruolo[]
            {
            new Ruolo{NomeRuolo="Sbandieratore"},
            new Ruolo{NomeRuolo="Tamburo"},
            new Ruolo{NomeRuolo="Chiarina"}
            };
            foreach (Ruolo r in ruoli)
            {
                context.Ruoli.Add(r);
            }
            context.SaveChanges();


        }
    }
}
