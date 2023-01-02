using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Data.Model;
using RentalManagementSystem.Data;

namespace RentalManagementSystem.Pages.Tenants
{
    public class EditModel : PageModel
    {
        private readonly RentalManagementSystem.Data.ApplicationDbContext _context;

        public EditModel(RentalManagementSystem.Data.ApplicationDbContext context)
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

            var tenant =  await _context.Tenants.FirstOrDefaultAsync(m => m.Id == id);
            if (tenant == null)
            {
                return NotFound();
            }
            Tenant = tenant;
           ViewData["BuildingId"] = new SelectList(_context.buildings, "Id", "Description");
           ViewData["BuildingId"] = new SelectList(_context.Flats, "Id", "Description");
           ViewData["BuildingId"] = new SelectList(_context.Rooms, "Id", "Description");
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

            _context.Attach(Tenant).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TenantExists(Tenant.Id))
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

        private bool TenantExists(long id)
        {
          return (_context.Tenants?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
