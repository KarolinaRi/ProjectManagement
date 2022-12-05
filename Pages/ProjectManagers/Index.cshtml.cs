using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Org.BouncyCastle.Utilities;
using ProjectManagement.Data2;

namespace ProjectManagement.Pages.ProjectManagers2
{
    public class IndexModel : PageModel
    {
        private readonly ProjectManagement.Data2.projectmanagementappContext _context;

        public IndexModel(ProjectManagement.Data2.projectmanagementappContext context)
        {
            _context = context;
        }

        public int Count;

        public IList<ProjectManager> ProjectManager { get;set; }

        public async Task OnGetAsync()
        {

            //CountByProjectName = projectName;

             var projectManager = _context.ProjectManagers
               .GroupBy(p => p.ProjectId)
             .Select(p => p.OrderBy(projectManager => projectManager.Project.Id));
            /*IQueryable<ProjectManager> projectManager = (IQueryable<ProjectManager>)_context.ProjectManagers.Where(p=>p.Project.ProjectName.Equals(projectName))
                .GroupBy(p => p.ProjectId)
                .Select(p => new { p.Key, Count = p.Count() });
            Count = projectManager.Count();*/
            ProjectManager = await _context.ProjectManagers.ToListAsync();
            //ProjectManager = (IList<ProjectManager>)await projectManager.ToListAsync();
        }
       
    }
}
