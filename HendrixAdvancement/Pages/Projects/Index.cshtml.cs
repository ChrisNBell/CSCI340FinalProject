using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using HendrixAdvancement.Data;
using HendrixAdvancement.Models;
 
namespace HendrixAdvancement.Pages_Projects
{
    public class IndexModel : PageModel
    {
        private readonly HendrixAdvancement.Data.HendrixAdvancementContext _context;
 
        public IndexModel(HendrixAdvancement.Data.HendrixAdvancementContext context)
        {
            _context = context;
        }

        public string TitleSort { get; set; }
         public string LocationSort { get; set; }
        public string DepartmentSort { get; set; }
        public string CategorySort { get; set; }
        public string CostSort { get; set; }
        public string CurrentFilter { get; set; }
        public string CurrentSort { get; set; }
    
        public IList<Project> Project { get;set; } = default!;
 
        public async Task OnGetAsync(string sortOrder)
        {
            CurrentSort = sortOrder;
            TitleSort = String.IsNullOrEmpty(sortOrder) ? "title_desc": "";
            LocationSort = sortOrder == "Location" ? "location_desc" : "Location";
            DepartmentSort = sortOrder == "Department" ? "department_desc" : "Department";
            CategorySort = sortOrder == "Category" ? "category_desc" : "Category"; 
            CostSort = sortOrder == "Cost" ? "Cost_desc" : "Cost";

             IQueryable<Project> projectsIQ = from p in _context.Projects
                                        select p;

             switch (sortOrder)
        {
            case "title_desc":
                projectsIQ = projectsIQ.OrderByDescending(p => p.Title);
                break;
            case "Location":
                projectsIQ = projectsIQ.OrderBy(p => p.Title);
                break;
            case "location_desc":
                projectsIQ = projectsIQ.OrderByDescending(p => p.Location);
                break;
            case "Department":
                projectsIQ = projectsIQ.OrderBy(p => p.Department);
                break;
            case "department_desc":
                projectsIQ = projectsIQ.OrderByDescending(p => p.Department);
                break;
            case "Category":
                projectsIQ = projectsIQ.OrderBy(p => p.Category);
                break;
            case "category_desc":
                projectsIQ = projectsIQ.OrderByDescending(p => p.Category);
                break;
            case "Cost":
                projectsIQ = projectsIQ.OrderBy(p => p.Cost);
                break;
            case "cost_desc":
                projectsIQ = projectsIQ.OrderByDescending(p => p.Cost);
                break;
            default: 
                projectsIQ = projectsIQ.OrderBy(p => p.Title);
                break;
        }




            Project = await _context.Projects.ToListAsync();


        
        }
    }
}
 