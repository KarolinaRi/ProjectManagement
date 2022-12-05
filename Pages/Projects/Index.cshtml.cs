using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using Microsoft.EntityFrameworkCore;
using Org.BouncyCastle.Utilities;
using ProjectManagement.Data2;

namespace ProjectManagement.Pages.Projects2
{
    public class IndexModel : PageModel
    {
        private readonly ProjectManagement.Data2.projectmanagementappContext _context;

        public IndexModel(ProjectManagement.Data2.projectmanagementappContext context)
        {
            _context = context;
        }

        public string CurrentFilter { get; set; }


        public IList<Project> Project { get;set; }

       public async Task OnGetAsync(string searchString)
        {
            CurrentFilter = searchString;

            IQueryable<Project> projectsIQ = from s in _context.Projects
                                             select s;

            if (!String.IsNullOrEmpty(searchString))
            {
                projectsIQ = projectsIQ.Where(s => s.ProjectName.Contains(searchString));
            }

            Project = await projectsIQ.AsNoTracking().ToListAsync();
        }

    }
}
