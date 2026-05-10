using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using HendrixAdvancement.Data;
using HendrixAdvancement.Models;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;
using HendrixAdvancement.Pages;


namespace HendrixAdvancement.Pages;

public class IndexModel(HendrixAdvancementContext context, IConfiguration configuration) : PageModel
{

    private readonly HendrixAdvancementContext _context = context;
    private readonly IConfiguration Configuration = configuration;

    public string TitleSort { get; set; }
    public string LocationSort { get; set; }
    public string DepartmentSort { get; set; }
    public string CategorySort { get; set; }
    public string CostSort { get; set; }
    public string CurrentFilter { get; set; }
    public string CurrentSort { get; set; }
    public PaginatedList<Project> Projects { get; set; }

    public async Task OnGetAsync(string sortOrder, string searchString,
        string currentFilter, int? pageIndex)
    {
        CurrentSort = sortOrder;
        TitleSort = String.IsNullOrEmpty(sortOrder) ? "title_desc" : "";
        LocationSort = sortOrder == "Location" ? "location_desc" : "Location";
        DepartmentSort = sortOrder == "Department" ? "department_desc" : "Department";
        CategorySort = sortOrder == "Category" ? "category_desc" : "Category";
        CostSort = sortOrder == "Cost" ? "Cost_desc" : "Cost";
        if (searchString != null)
        {
            pageIndex = 1;
        }
        else
        {
            searchString = currentFilter;
        }

        CurrentFilter = searchString;

        IQueryable<Project> projectsIQ = from p in _context.Projects
                                         select p;
        if (!String.IsNullOrEmpty(searchString))
        {
            projectsIQ = projectsIQ.Where(p => p.Title.ToUpper().Contains(searchString.ToUpper()));
        }


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

        var pageSize = Configuration.GetValue("PageSize", 11);
        Projects = await PaginatedList<Project>.CreateAsync(
            projectsIQ.AsNoTracking(), pageIndex ?? 1, pageSize);


    }

}


