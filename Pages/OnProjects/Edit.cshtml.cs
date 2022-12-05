using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using ProjectManagement.Data2;

namespace ProjectManagement.Pages.OnProjects2
{
    public class EditModel : PageModel
    {
        private readonly ProjectManagement.Data2.projectmanagementappContext _context;

        public EditModel(ProjectManagement.Data2.projectmanagementappContext context)
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
           ViewData["ClientPartnerId"] = new SelectList(_context.ClientPartners, "Id", "CpAddress");
           ViewData["ProjectId"] = new SelectList(_context.Projects, "Id", "ProjectDescription");
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

            _context.Attach(OnProject).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!OnProjectExists(OnProject.Id))
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

        private bool OnProjectExists(int id)
        {
            return _context.OnProjects.Any(e => e.Id == id);
        }
    }
}
