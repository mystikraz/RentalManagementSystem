using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Data.Model;
using RentalManagementSystem.Data;

namespace RentalManagementSystem.Pages.Tenants
{
    public class IndexModel : PageModel
    {
        private readonly RentalManagementSystem.Data.ApplicationDbContext _context;

        public IndexModel(RentalManagementSystem.Data.ApplicationDbContext context)
        {
            _context = context;
        }

        public IList<Tenant> Tenant { get;set; } = default!;

        public async Task OnGetAsync()
        {
            if (_context.Tenants != null)
            {
                Tenant = await _context.Tenants
                .Include(t => t.Building)
                .Include(t => t.Flat)
                .Include(t => t.Room).ToListAsync();
            }
        }
    }
}
