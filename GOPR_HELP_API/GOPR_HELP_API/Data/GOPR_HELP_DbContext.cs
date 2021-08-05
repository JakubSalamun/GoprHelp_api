using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace GOPR_HELP_API.Data
{
    public class GOPR_HELP_DbContext: DbContext
    {
        private string _connectionString="Server=(localdb)\\mssqllocaldb;Database=GOPR_HELP_Db;Trusted_Connection=True;";
        public DbSet<Mountains> Mountains { get; set; }
        public DbSet<Registration> Registrations { get; set; }
        public DbSet<Tourist> Tourists { get; set; }
        public DbSet<Trails> Trails { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Registration>()
                .Property(x => x.END)
                .HasColumnType("datetime")
                .IsRequired();
            modelBuilder.Entity<Trails>()
                .Property(x => x.Name)
                .IsRequired();
            modelBuilder.Entity<Tourist>()
                .Property(x => x.LastName)
                .IsRequired();
        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(_connectionString);
        }


    }
}
