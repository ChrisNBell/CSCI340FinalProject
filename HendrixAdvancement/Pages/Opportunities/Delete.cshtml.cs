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
    public class DeleteModel : PageModel
    {
        private readonly HendrixAdvancement.Data.HendrixAdvancementContext _context;

        public DeleteModel(HendrixAdvancement.Data.HendrixAdvancementContext context)
        {
            _context = context;
        }

        [BindProperty]
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

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var opportunity = await _context.Opportunities.FindAsync(id);
            if (opportunity != null)
            {
                Opportunity = opportunity;
                _context.Opportunities.Remove(Opportunity);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
