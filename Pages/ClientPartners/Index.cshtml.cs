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
    public class IndexModel : PageModel
    {
        private readonly ProjectManagement.Data2.projectmanagementappContext _context;

        public IndexModel(ProjectManagement.Data2.projectmanagementappContext context)
        {
            _context = context;
        }

        public IList<ClientPartner> ClientPartner { get;set; }

        public async Task OnGetAsync()
        {
            ClientPartner = await _context.ClientPartners.ToListAsync();
        }
    }
}
