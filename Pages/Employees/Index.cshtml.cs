using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using ProjectManagement.Data2;

namespace ProjectManagement.Pages.Employees
{
    public class IndexModel : PageModel
    {
        private readonly ProjectManagement.Data2.projectmanagementappContext _context;

        public IndexModel(ProjectManagement.Data2.projectmanagementappContext context)
        {
            _context = context;
        }

        public IList<Employee> Employees { get;set; }

        public async Task OnGetAsync()
        {
            var emp = _context.Employees.OrderBy(e => e.Name).Select(e=>e);
            /*var emp = from e in _context.Users
                      orderby e.Name
                      select e;*/
            Employees = await emp.ToListAsync();
        }
    }
}
