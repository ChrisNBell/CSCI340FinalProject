using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using HendrixAdvancement.Data;
using HendrixAdvancement.Models;

namespace HendrixAdvancement.Pages.Opportunities
{
    public class CreateModel : PageModel
    {
        private readonly HendrixAdvancement.Data.HendrixAdvancementContext _context;

        public CreateModel(HendrixAdvancement.Data.HendrixAdvancementContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
        ViewData["ProjectID"] = new SelectList(_context.Projects, "ProjectId", "ProjectId");
            return Page();
        }

        [BindProperty]
        public Opportunity Opportunity { get; set; } = default!;

        // For more information, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Opportunities.Add(Opportunity);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
