using GruppoStoricoApp.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace GruppoStoricoApp.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        public DbSet<Persona> Persone { get; set; }
        public DbSet<Ruolo> Ruoli { get; set; }
        public DbSet<Calzamaglia> Calzamaglie { get; set; }
        public DbSet<Camicia> Camicie { get; set; }
        public DbSet<Cintura> Cinture { get; set; }
        public DbSet<Vestito> Vestiti { get; set; }
        public DbSet<Stivale> Stivali { get; set; }
        public DbSet<Evento> Eventi { get; set; }
        public DbSet<PartecipazioneEvento> PartecipazioniEventi { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Persona>().ToTable("Persona");
            modelBuilder.Entity<Ruolo>().ToTable("Ruolo");
            modelBuilder.Entity<Calzamaglia>().ToTable("Calzamaglia");
            modelBuilder.Entity<Camicia>().ToTable("Camicia");
            modelBuilder.Entity<Cintura>().ToTable("Cintura");
            modelBuilder.Entity<Vestito>().ToTable("Vestito");
            modelBuilder.Entity<Stivale>().ToTable("Stivale");
            modelBuilder.Entity<Evento>().ToTable("Evento");
            modelBuilder.Entity<PartecipazioneEvento>().ToTable("PartecipazioneEvento");

            modelBuilder.Entity<Calzamaglia>()
            .HasIndex(p => new { p.Numero, p.RuoloID })
            .IsUnique(true);

            modelBuilder.Entity<Camicia>()
            .HasIndex(p => new { p.Numero, p.RuoloID })
            .IsUnique(true);

            modelBuilder.Entity<Cintura>()
            .HasIndex(p => new { p.Numero, p.RuoloID })
            .IsUnique(true);

            modelBuilder.Entity<Vestito>()
            .HasIndex(p => new { p.Numero, p.RuoloID })
            .IsUnique(true);

            modelBuilder.Entity<Stivale>()
            .HasIndex(p => new { p.Numero, p.RuoloID })
            .IsUnique(true);

            base.OnModelCreating(modelBuilder);
        }
    }
}
