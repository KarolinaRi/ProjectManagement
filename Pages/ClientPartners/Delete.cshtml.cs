using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using ProjectManagement.Data2;

namespace ProjectManagement.Pages.ClientPartners2
{
    public class DeleteModel : PageModel
    {
        private readonly ProjectManagement.Data2.projectmanagementappContext _context;

        public DeleteModel(ProjectManagement.Data2.projectmanagementappContext context)
        {
            _context = context;
        }

        [BindProperty]
        public ClientPartner ClientPartner { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            ClientPartner = await _context.ClientPartners.FirstOrDefaultAsync(m => m.Id == id);

            if (ClientPartner == null)
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

            ClientPartner = await _context.ClientPartners.FindAsync(id);

            if (ClientPartner != null)
            {
                _context.ClientPartners.Remove(ClientPartner);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
