using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using ProjectManagement.Data2;
using System.Web.Helpers;
using System.Net.Http;

namespace ProjectManagement.Pages.ClientPartners2
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
            return Page();
        }

        [BindProperty]
        public ClientPartner ClientPartner { get; set; }

        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.ClientPartners.Add(ClientPartner);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
