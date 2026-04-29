using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using HendrixAdvancement.Models;

namespace HendrixAdvancement.Data
{
    public class HendrixAdvancementContext : DbContext
    {
        public HendrixAdvancementContext (DbContextOptions<HendrixAdvancementContext> options)
            : base(options)
        {
        }

        public DbSet<HendrixAdvancement.Models.Project> Project { get; set; } = default!;
    }
}
