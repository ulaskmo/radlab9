using CsvHelper.Configuration;
using Microsoft.EntityFrameworkCore;
using Rad302SampleExam2024.DataModel.CSVMapper;
using System;
using System.Collections.Generic;
using System.Diagnostics.Metrics;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;

namespace Rad302SampleExam2024.DataModel
{
    public class ProgrammeContext : DbContext
    {
        public DbSet<Module> Modules { get; set; }
        public DbSet<Programme> Programmes { get; set; }
        public DbSet<ProgrammeDelivery> ProgrammeDeliveries { get; set; }

        public ProgrammeContext() : base()
        {
            // Seeding to be done in Seeder after we add the context
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            var myconnectionstring = "Data Source = (localdb)\\MSSQLLocalDB; Initial Catalog = Rad302SampleExam2024DB-ppowell";
            optionsBuilder.UseSqlServer(myconnectionstring)
                            .EnableSensitiveDataLogging();

            base.OnConfiguring(optionsBuilder);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Defining composite key for Programme Delivery
            modelBuilder.Entity<ProgrammeDelivery>().HasKey(l => new { l.ProgCode, l.ModuleCode});

            Module[] modules = DBHelper.Get<Module, ModuleMap>("Rad302SampleExam2024.DataModel.CSVMapper.Modules.csv").ToArray();
            modelBuilder.Entity<Module>().HasData(modules);

            Programme[] programmes = DBHelper.Get<Programme, ProgrammeMap>("Rad302SampleExam2024.DataModel.CSVMapper.Programmes.csv").ToArray();
            modelBuilder.Entity<Programme>().HasData(programmes);


            base.OnModelCreating(modelBuilder);
        }


    }
}
