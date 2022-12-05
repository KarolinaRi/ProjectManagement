using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using ProjectManagement.Data2;

namespace ProjectManagement.Pages.ProjectManagers2
{
    public class EditModel : PageModel
    {
        private readonly ProjectManagement.Data2.projectmanagementappContext _context;

        public EditModel(ProjectManagement.Data2.projectmanagementappContext context)
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
           ViewData["ProjectId"] = new SelectList(_context.Projects, "Id", "ProjectDescription");
           ViewData["EmployeeId"] = new SelectList(_context.Employees, "Id", "Email");
            return Page();
        }

        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Attach(ProjectManager).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ProjectManagerExists(ProjectManager.Id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return RedirectToPage("./Index");
        }

        private bool ProjectManagerExists(int id)
        {
            return _context.ProjectManagers.Any(e => e.Id == id);
        }
    }
}
