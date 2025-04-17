using API_Pointage.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;

namespace API_Pointage.DbContext
{
    // Assurez-vous que ApplicationDbContext hérite de DbContext
    public class ApplicationDbContext : Microsoft.EntityFrameworkCore.DbContext
    {
        // Constructeur qui prend les options de configuration
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        // DbSets pour les tables
        public DbSet<Employee> Employees { get; set; }
        public DbSet<Attendance> Attendances { get; set; }
        public DbSet<Department> Departments { get; set; }
        public DbSet<Position> Positions { get; set; }
        public DbSet<User> Users { get; set; }
        // Assurez-vous que ApplicationDbContext hérite de DbContext
        public DbSet<Entreprise> Entreprises { get; set; }
        public DbSet<ScanPoint> ScanPoints { get; set; }


        // La méthode OnModelCreating doit être à l'intérieur de la classe ApplicationDbContext
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // Configurer la relation entre Employee et Entreprise pour éviter les cascades multiples
            modelBuilder.Entity<Employee>()
                .HasOne(e => e.Entreprise)
                .WithMany() // Si tu as une collection d'Employees dans Entreprise, tu peux utiliser .WithMany(e => e.Employees)
                .HasForeignKey(e => e.EntrepriseId)
                // Empêche la suppression si des employés existent
                .OnDelete(DeleteBehavior.Restrict); // Remplace par Restrict ou SetNull selon le comportement que tu veux
        }
    }

    
}
