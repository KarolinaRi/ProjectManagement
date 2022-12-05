using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using ProjectManagement.Data2;

namespace ProjectManagement.Pages.ProjectManagers2
{
    public class CreateModel : PageModel
    {
        private readonly ProjectManagement.Data2.projectmanagementappContext _context;

        public CreateModel(ProjectManagement.Data2.projectmanagementappContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
        ViewData["ProjectId"] = new SelectList(_context.Projects, "Id", "ProjectDescription");
        ViewData["EmployeeId"] = new SelectList(_context.Employees, "Id", "Email");
            return Page();
        }

        [BindProperty]
        public ProjectManager ProjectManager { get; set; }

        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.ProjectManagers.Add(ProjectManager);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
