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
    public class DeleteModel : PageModel
    {
        private readonly RentalManagementSystem.Data.ApplicationDbContext _context;

        public DeleteModel(RentalManagementSystem.Data.ApplicationDbContext context)
        {
            _context = context;
        }

        [BindProperty]
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

        public async Task<IActionResult> OnPostAsync(long? id)
        {
            if (id == null || _context.Tenants == null)
            {
                return NotFound();
            }
            var tenant = await _context.Tenants.FindAsync(id);

            if (tenant != null)
            {
                Tenant = tenant;
                _context.Tenants.Remove(Tenant);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
