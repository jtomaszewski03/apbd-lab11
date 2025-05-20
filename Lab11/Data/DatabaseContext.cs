using Lab11.Models;
using Microsoft.EntityFrameworkCore;

namespace Lab11.Data;

public class DatabaseContext : DbContext
{
    public DbSet<Prescription> Prescriptions { get; set; }
    public DbSet<Doctor> Doctors { get; set; }
    public DbSet<PrescriptionMedicament> PrescriptionsMedicaments { get; set; }
    public DbSet<Medicament> Medicaments { get; set; }
    public DbSet<Patient> Patients { get; set; }
    
    protected DatabaseContext()
    {
    }

    public DatabaseContext(DbContextOptions options) : base(options)
    {
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Doctor>().HasData(new List<Doctor>
        {
            new Doctor() { IdDoctor = 1, FirstName = "John", LastName = "Doe", Email = "john.doe@gmail.com" },
        });
        modelBuilder.Entity<Medicament>().HasData(new List<Medicament>
        {
            new Medicament { IdMedicament = 1, Name = "Apap", Description = "Lek przeciwbólowy", Type = "Tabletki" },
            new Medicament { IdMedicament = 4, Name = "Gripex", Description = "Lek na przeziębienie", Type = "Proszek" }
        });
        base.OnModelCreating(modelBuilder);
    }
}