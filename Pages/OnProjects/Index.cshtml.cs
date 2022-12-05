using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using ProjectManagement.Data2;

namespace ProjectManagement.Pages.OnProjects2
{
    public class IndexModel : PageModel
    {
        private readonly ProjectManagement.Data2.projectmanagementappContext _context;

        public IndexModel(ProjectManagement.Data2.projectmanagementappContext context)
        {
            _context = context;
        }

        public IList<OnProject> OnProject { get;set; }

        public async Task OnGetAsync()
        {
            OnProject = await _context.OnProjects
                .Include(o => o.ClientPartner)
                .Include(o => o.Project).ToListAsync();
        }
    }
}
