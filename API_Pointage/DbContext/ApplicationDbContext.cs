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

        //public object Department { get; internal set; }
    }
}
