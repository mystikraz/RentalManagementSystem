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
    public class DetailsModel : PageModel
    {
        private readonly RentalManagementSystem.Data.ApplicationDbContext _context;

        public DetailsModel(RentalManagementSystem.Data.ApplicationDbContext context)
        {
            _context = context;
        }

      public Tenant Tenant { get; set; } = default!; 

        public async Task<IActionResult> OnGetAsync(long? id)
        {
            if (id == null || _context.Tenants == null)
            {
                return NotFound();
            }

            var tenant = await _context.Tenants.FirstOrDefaultAsync(m => m.Id == id);
            if (tenant == null)
            {
                return NotFound();
            }
            else 
            {
                Tenant = tenant;
            }
            return Page();
        }
    }
}
