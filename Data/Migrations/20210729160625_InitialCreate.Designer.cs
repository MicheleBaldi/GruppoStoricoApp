// <auto-generated />
using System;
using GruppoStoricoApp.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace GruppoStoricoApp.Data.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    [Migration("20210729160625_InitialCreate")]
    partial class InitialCreate
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.8")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("GruppoStoricoApp.Models.Calzamaglia", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("Numero")
                        .HasColumnType("int");

                    b.Property<int>("RuoloID")
                        .HasColumnType("int");

                    b.Property<string>("Taglia")
                        .IsRequired()
                        .HasMaxLength(10)
                        .HasColumnType("nvarchar(10)");

                    b.HasKey("ID");

                    b.HasIndex("RuoloID");

                    b.HasIndex("Numero", "RuoloID")
                        .IsUnique();

                    b.ToTable("Calzamaglia");
                });

            modelBuilder.Entity("GruppoStoricoApp.Models.Camicia", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("Numero")
                        .HasColumnType("int");

                    b.Property<int>("RuoloID")
                        .HasColumnType("int");

                    b.Property<string>("Taglia")
                        .IsRequired()
                        .HasMaxLength(10)
                        .HasColumnType("nvarchar(10)");

                    b.HasKey("ID");

                    b.HasIndex("RuoloID");

                    b.HasIndex("Numero", "RuoloID")
                        .IsUnique();

                    b.ToTable("Camicia");
                });

            modelBuilder.Entity("GruppoStoricoApp.Models.Cintura", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("Numero")
                        .HasColumnType("int");

                    b.Property<int>("RuoloID")
                        .HasColumnType("int");

                    b.Property<string>("Taglia")
                        .IsRequired()
                        .HasMaxLength(10)
                        .HasColumnType("nvarchar(10)");

                    b.HasKey("ID");

                    b.HasIndex("RuoloID");

                    b.HasIndex("Numero", "RuoloID")
                        .IsUnique();

                    b.ToTable("Cintura");
                });

            modelBuilder.Entity("GruppoStoricoApp.Models.Evento", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("DataEvento")
                        .HasColumnType("datetime2");

                    b.Property<string>("NomeEvento")
                        .IsRequired()
                        .HasMaxLength(200)
                        .HasColumnType("nvarchar(200)");

                    b.HasKey("ID");

                    b.ToTable("Evento");
                });

            modelBuilder.Entity("GruppoStoricoApp.Models.PartecipazioneEvento", b =>
                {
                    b.Property<int>("PartecipazioneEventoID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("CalzamagliaId")
                        .HasColumnType("int");

                    b.Property<int>("CamiciaId")
                        .HasColumnType("int");

                    b.Property<int>("CinturaId")
                        .HasColumnType("int");

                    b.Property<int>("EventoID")
                        .HasColumnType("int");

                    b.Property<int>("PersonaId")
                        .HasColumnType("int");

                    b.Property<int>("StivaleId")
                        .HasColumnType("int");

                    b.Property<int>("VestitoId")
                        .HasColumnType("int");

                    b.HasKey("PartecipazioneEventoID");

                    b.HasIndex("CalzamagliaId");

                    b.HasIndex("CamiciaId");

                    b.HasIndex("CinturaId");

                    b.HasIndex("EventoID");

                    b.HasIndex("PersonaId");

                    b.HasIndex("StivaleId");

                    b.HasIndex("VestitoId");

                    b.ToTable("PartecipazioneEvento");
                });

            modelBuilder.Entity("GruppoStoricoApp.Models.Persona", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Cognome")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<DateTime>("DataNascita")
                        .HasColumnType("datetime2");

                    b.Property<string>("Email")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<string>("Profilo")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("RuoloID")
                        .HasColumnType("int");

                    b.HasKey("ID");

                    b.HasIndex("RuoloID");

                    b.ToTable("Persona");
                });

            modelBuilder.Entity("GruppoStoricoApp.Models.Ruolo", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("NomeRuolo")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("ID");

                    b.ToTable("Ruolo");
                });

            modelBuilder.Entity("GruppoStoricoApp.Models.Stivale", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("Numero")
                        .HasColumnType("int");

                    b.Property<int>("RuoloID")
                        .HasColumnType("int");

                    b.Property<int>("Taglia")
                        .HasColumnType("int");

                    b.HasKey("ID");

                    b.HasIndex("RuoloID");

                    b.HasIndex("Numero", "RuoloID")
                        .IsUnique();

                    b.ToTable("Stivale");
                });

            modelBuilder.Entity("GruppoStoricoApp.Models.Vestito", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("Numero")
                        .HasColumnType("int");

                    b.Property<int>("RuoloID")
                        .HasColumnType("int");

                    b.Property<string>("Taglia")
                        .IsRequired()
                        .HasMaxLength(10)
                        .HasColumnType("nvarchar(10)");

                    b.HasKey("ID");

                    b.HasIndex("RuoloID");

                    b.HasIndex("Numero", "RuoloID")
                        .IsUnique();

                    b.ToTable("Vestito");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRole", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<string>("NormalizedName")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.HasKey("Id");

                    b.HasIndex("NormalizedName")
                        .IsUnique()
                        .HasDatabaseName("RoleNameIndex")
                        .HasFilter("[NormalizedName] IS NOT NULL");

                    b.ToTable("AspNetRoles");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("ClaimType")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("RoleId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("Id");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetRoleClaims");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUser", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<int>("AccessFailedCount")
                        .HasColumnType("int");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Email")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<bool>("EmailConfirmed")
                        .HasColumnType("bit");

                    b.Property<bool>("LockoutEnabled")
                        .HasColumnType("bit");

                    b.Property<DateTimeOffset?>("LockoutEnd")
                        .HasColumnType("datetimeoffset");

                    b.Property<string>("NormalizedEmail")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<string>("NormalizedUserName")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<string>("PasswordHash")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PhoneNumber")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("PhoneNumberConfirmed")
                        .HasColumnType("bit");

                    b.Property<string>("SecurityStamp")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("TwoFactorEnabled")
                        .HasColumnType("bit");

                    b.Property<string>("UserName")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.HasKey("Id");

                    b.HasIndex("NormalizedEmail")
                        .HasDatabaseName("EmailIndex");

                    b.HasIndex("NormalizedUserName")
                        .IsUnique()
                        .HasDatabaseName("UserNameIndex")
                        .HasFilter("[NormalizedUserName] IS NOT NULL");

                    b.ToTable("AspNetUsers");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("ClaimType")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserClaims");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.Property<string>("LoginProvider")
                        .HasMaxLength(128)
                        .HasColumnType("nvarchar(128)");

                    b.Property<string>("ProviderKey")
                        .HasMaxLength(128)
                        .HasColumnType("nvarchar(128)");

                    b.Property<string>("ProviderDisplayName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("LoginProvider", "ProviderKey");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserLogins");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<string>", b =>
                {
                    b.Property<string>("UserId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("RoleId")
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("UserId", "RoleId");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetUserRoles");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.Property<string>("UserId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("LoginProvider")
                        .HasMaxLength(128)
                        .HasColumnType("nvarchar(128)");

                    b.Property<string>("Name")
                        .HasMaxLength(128)
                        .HasColumnType("nvarchar(128)");

                    b.Property<string>("Value")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("UserId", "LoginProvider", "Name");

                    b.ToTable("AspNetUserTokens");
                });

            modelBuilder.Entity("GruppoStoricoApp.Models.Calzamaglia", b =>
                {
                    b.HasOne("GruppoStoricoApp.Models.Ruolo", "Ruolo")
                        .WithMany()
                        .HasForeignKey("RuoloID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Ruolo");
                });

            modelBuilder.Entity("GruppoStoricoApp.Models.Camicia", b =>
                {
                    b.HasOne("GruppoStoricoApp.Models.Ruolo", "Ruolo")
                        .WithMany()
                        .HasForeignKey("RuoloID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Ruolo");
                });

            modelBuilder.Entity("GruppoStoricoApp.Models.Cintura", b =>
                {
                    b.HasOne("GruppoStoricoApp.Models.Ruolo", "Ruolo")
                        .WithMany()
                        .HasForeignKey("RuoloID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Ruolo");
                });

            modelBuilder.Entity("GruppoStoricoApp.Models.PartecipazioneEvento", b =>
                {
                    b.HasOne("GruppoStoricoApp.Models.Calzamaglia", "Calzamaglia")
                        .WithMany("PartecipazioniEventi")
                        .HasForeignKey("CalzamagliaId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("GruppoStoricoApp.Models.Camicia", "Camicia")
                        .WithMany("PartecipazioniEventi")
                        .HasForeignKey("CamiciaId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("GruppoStoricoApp.Models.Cintura", "Cintura")
                        .WithMany("PartecipazioniEventi")
                        .HasForeignKey("CinturaId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("GruppoStoricoApp.Models.Evento", "Evento")
                        .WithMany("PartecipazioniEventi")
                        .HasForeignKey("EventoID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("GruppoStoricoApp.Models.Persona", "Persona")
                        .WithMany("PartecipazioniEventi")
                        .HasForeignKey("PersonaId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("GruppoStoricoApp.Models.Stivale", "Stivale")
                        .WithMany("PartecipazioniEventi")
                        .HasForeignKey("StivaleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("GruppoStoricoApp.Models.Vestito", "Vestito")
                        .WithMany("PartecipazioniEventi")
                        .HasForeignKey("VestitoId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Calzamaglia");

                    b.Navigation("Camicia");

                    b.Navigation("Cintura");

                    b.Navigation("Evento");

                    b.Navigation("Persona");

                    b.Navigation("Stivale");

                    b.Navigation("Vestito");
                });

            modelBuilder.Entity("GruppoStoricoApp.Models.Persona", b =>
                {
                    b.HasOne("GruppoStoricoApp.Models.Ruolo", "Ruolo")
                        .WithMany("Persone")
                        .HasForeignKey("RuoloID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Ruolo");
                });

            modelBuilder.Entity("GruppoStoricoApp.Models.Stivale", b =>
                {
                    b.HasOne("GruppoStoricoApp.Models.Ruolo", "Ruolo")
                        .WithMany()
                        .HasForeignKey("RuoloID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Ruolo");
                });

            modelBuilder.Entity("GruppoStoricoApp.Models.Vestito", b =>
                {
                    b.HasOne("GruppoStoricoApp.Models.Ruolo", "Ruolo")
                        .WithMany()
                        .HasForeignKey("RuoloID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Ruolo");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityRole", null)
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityRole", null)
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("GruppoStoricoApp.Models.Calzamaglia", b =>
                {
                    b.Navigation("PartecipazioniEventi");
                });

            modelBuilder.Entity("GruppoStoricoApp.Models.Camicia", b =>
                {
                    b.Navigation("PartecipazioniEventi");
                });

            modelBuilder.Entity("GruppoStoricoApp.Models.Cintura", b =>
                {
                    b.Navigation("PartecipazioniEventi");
                });

            modelBuilder.Entity("GruppoStoricoApp.Models.Evento", b =>
                {
                    b.Navigation("PartecipazioniEventi");
                });

            modelBuilder.Entity("GruppoStoricoApp.Models.Persona", b =>
                {
                    b.Navigation("PartecipazioniEventi");
                });

            modelBuilder.Entity("GruppoStoricoApp.Models.Ruolo", b =>
                {
                    b.Navigation("Persone");
                });

            modelBuilder.Entity("GruppoStoricoApp.Models.Stivale", b =>
                {
                    b.Navigation("PartecipazioniEventi");
                });

            modelBuilder.Entity("GruppoStoricoApp.Models.Vestito", b =>
                {
                    b.Navigation("PartecipazioniEventi");
                });
#pragma warning restore 612, 618
        }
    }
}
