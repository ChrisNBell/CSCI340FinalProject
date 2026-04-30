using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using HendrixAdvancement.Data;
using HendrixAdvancement.Models;
namespace HendrixAdvancement.Pages;

public class IndexModel : PageModel
{

    private readonly HendrixAdvancement.Data.HendrixAdvancementContext _context;

    public IndexModel(HendrixAdvancement.Data.HendrixAdvancementContext context)
    {
        _context = context;
    }

    public IList<Project> Project { get; set; } = default!;

    public async Task OnGetAsync()
    {
        Project = await _context.Projects.ToListAsync();
    }
}


