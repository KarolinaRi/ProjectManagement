using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using ProjectManagement.Data2;

namespace ProjectManagement.Pages.ProjectManagers2
{
    public class DetailsModel : PageModel
    {
        private readonly ProjectManagement.Data2.projectmanagementappContext _context;

        public DetailsModel(ProjectManagement.Data2.projectmanagementappContext context)
        {
            _context = context;
        }

        public ProjectManager ProjectManager { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            ProjectManager = await _context.ProjectManagers
                .Include(p => p.Project)
                .Include(p => p.Employee).FirstOrDefaultAsync(m => m.Id == id);

            if (ProjectManager == null)
            {
                return NotFound();
            }
            return Page();
        }
    }
}
