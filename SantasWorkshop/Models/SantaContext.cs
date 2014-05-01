using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.Data.Entity.ModelConfiguration.Conventions;

namespace SantasWorkshop.Models
{
    public class SantaContext : DbContext
    {
        public DbSet<Toy> Toy { get; set; }
        public DbSet<WrappingPaper> WrappingPaper { get; set; }
        public DbSet<Elf> Elf { get; set; }
        public DbSet<Present> Present { get; set; }
        public DbSet<Kid> Kid { get; set; }
        public DbSet<House> House { get; set; }
        public DbSet<Department> Department { get; set; }
        public DbSet<Visitor> Visitor { get; set; }
        public DbSet<Workshop> Workshop { get; set; }
        public DbSet<Reindeer> Reindeer { get; set; }
    }
}