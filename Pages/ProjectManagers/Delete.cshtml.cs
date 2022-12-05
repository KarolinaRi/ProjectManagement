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
    public class DeleteModel : PageModel
    {
        private readonly ProjectManagement.Data2.projectmanagementappContext _context;

        public DeleteModel(ProjectManagement.Data2.projectmanagementappContext context)
        {
            _context = context;
        }

        [BindProperty]
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

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            ProjectManager = await _context.ProjectManagers.FindAsync(id);

            if (ProjectManager != null)
            {
                _context.ProjectManagers.Remove(ProjectManager);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
