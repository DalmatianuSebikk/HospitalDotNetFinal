using HospitalDotNetFinal.DAL.Configurations;
using HospitalDotNetFinal.DAL.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Extensions.Logging;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;

namespace HospitalDotNetFinal.DAL
{
    public class AppDbContext : IdentityDbContext<
        User,
        Role,
        int,
        IdentityUserClaim<int>,
        UserRole,
        IdentityUserLogin<int>,
        IdentityRoleClaim<int>,
        IdentityUserToken<int>
        >
    {
        // facem constructor

        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {

        }
        public DbSet<Boala> Boli { get; set; }
        public DbSet<Spital> Spitale { get; set; }
        public DbSet<Oras> Orase { get; set; }
        public DbSet<Pacient> Pacienti { get; set; }
        public DbSet<Medic> Medici { get; set; }
        public DbSet<MedicPacient> MediciPacienti { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseLoggerFactory(LoggerFactory.Create(options => options.AddConsole()));
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            // specificam anumite configuratii
            // trebuie sa apelam configuratia 

            modelBuilder.ApplyConfiguration(new BoalaConfiguration());
            modelBuilder.ApplyConfiguration(new SpitalConfiguration());
            modelBuilder.ApplyConfiguration(new OrasConfiguration());
            modelBuilder.ApplyConfiguration(new PacientConfiguration());
            modelBuilder.ApplyConfiguration(new MedicConfiguration());

            // ----------------------------CONFIGURARI PENTRU FIECARE TABEL---------------------
            modelBuilder.Entity<Pacient>()
                        .HasOne(pacient => pacient.Spital)
                        .WithMany(spital => spital.Pacienti)
                        .HasForeignKey(pacient => pacient.SpitalId);

            modelBuilder.Entity<Oras>()
                        .HasOne<Spital>(oras => oras.Spital)
                        .WithOne(spital => spital.Oras)
                        .HasForeignKey<Spital>(spital => spital.OrasId);

            modelBuilder.Entity<Medic>()
                        .HasOne(medic => medic.Spital)
                        .WithMany(spital => spital.Medici)
                        .HasForeignKey(medic => medic.SpitalId);

            modelBuilder.Entity<MedicPacient>()
                        .HasOne(mediciPacienti => mediciPacienti.Medic)
                        .WithMany(medic => medic.MediciPacienti)
                        .HasForeignKey(mediciPacienti => mediciPacienti.MedicId)
                        .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<MedicPacient>()
                        .HasOne(mediciPacienti => mediciPacienti.Pacient)
                        .WithMany(pacient => pacient.MediciPacienti)
                        .HasForeignKey(mediciPacienti => mediciPacienti.PacientId)
                        .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
