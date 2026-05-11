using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using HendrixAdvancement.Data;
using HendrixAdvancement.Models;

namespace HendrixAdvancement.Pages.Opportunities
{
    public class IndexModel : PageModel
    {
        private readonly HendrixAdvancement.Data.HendrixAdvancementContext _context;

        public IndexModel(HendrixAdvancement.Data.HendrixAdvancementContext context)
        {
            _context = context;
        }

        public string CurrentFilter { get; set; }


        public IList<Opportunity> Opportunity { get;set; } = default!;


        public async Task OnGetAsync(string searchString)

        {
            CurrentFilter = searchString;

            IQueryable<Opportunity> opportunitiesIQ = from o in _context.Opportunities
                                        select o;
        if (!String.IsNullOrEmpty(searchString))
        {
            opportunitiesIQ = opportunitiesIQ.Where(o => o.Title.ToUpper().Contains(searchString.ToUpper()));
        }

            Opportunity = await opportunitiesIQ.AsNoTracking().ToListAsync();
        }

    }
}
