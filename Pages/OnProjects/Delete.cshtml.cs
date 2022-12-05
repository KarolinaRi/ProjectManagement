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
    public class DeleteModel : PageModel
    {
        private readonly ProjectManagement.Data2.projectmanagementappContext _context;

        public DeleteModel(ProjectManagement.Data2.projectmanagementappContext context)
        {
            _context = context;
        }

        [BindProperty]
        public OnProject OnProject { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            OnProject = await _context.OnProjects
                .Include(o => o.ClientPartner)
                .Include(o => o.Project).FirstOrDefaultAsync(m => m.Id == id);

            if (OnProject == null)
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

            OnProject = await _context.OnProjects.FindAsync(id);

            if (OnProject != null)
            {
                _context.OnProjects.Remove(OnProject);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
