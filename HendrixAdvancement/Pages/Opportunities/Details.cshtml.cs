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
    public class DetailsModel : PageModel
    {
        private readonly HendrixAdvancement.Data.HendrixAdvancementContext _context;

        public DetailsModel(HendrixAdvancement.Data.HendrixAdvancementContext context)
        {
            _context = context;
        }

        public Opportunity Opportunity { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var opportunity = await _context.Opportunities.FirstOrDefaultAsync(m => m.OpportunityId == id);

            if (opportunity is not null)
            {
                Opportunity = opportunity;

                return Page();
            }

            return NotFound();
        }
    }
}
