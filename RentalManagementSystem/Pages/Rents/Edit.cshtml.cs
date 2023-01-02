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

namespace RentalManagementSystem.Pages.Rents
{
    public class EditModel : PageModel
    {
        private readonly RentalManagementSystem.Data.ApplicationDbContext _context;

        public EditModel(RentalManagementSystem.Data.ApplicationDbContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Rent Rent { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(long? id)
        {
            if (id == null || _context.Rents == null)
            {
                return NotFound();
            }

            var rent =  await _context.Rents.FirstOrDefaultAsync(m => m.Id == id);
            if (rent == null)
            {
                return NotFound();
            }
            Rent = rent;
           ViewData["TenantId"] = new SelectList(_context.Tenants, "Id", "Description");
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

            _context.Attach(Rent).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!RentExists(Rent.Id))
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

        private bool RentExists(long id)
        {
          return (_context.Rents?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
