using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using HendrixAdvancement.Models;

namespace HendrixAdvancement.Data
{
    public class HendrixAdvancementContext(DbContextOptions<HendrixAdvancementContext> options) : DbContext(options)
    {
        public DbSet<Project> Projects { get; set; } = default!;
        public DbSet<Opportunity> Opportunities { get; set; }
        
        protected override void OnModelCreating (ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Opportunity>().ToTable("Opportunity");
            modelBuilder.Entity<Project>().ToTable("Projects");
        }
    }
}
