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

namespace RentalManagementSystem.Pages.Buildings
{
    public class EditModel : PageModel
    {
        private readonly RentalManagementSystem.Data.ApplicationDbContext _context;

        public EditModel(RentalManagementSystem.Data.ApplicationDbContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Building Building { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(long? id)
        {
            if (id == null || _context.buildings == null)
            {
                return NotFound();
            }

            var building =  await _context.buildings.FirstOrDefaultAsync(m => m.Id == id);
            if (building == null)
            {
                return NotFound();
            }
            Building = building;
           ViewData["AddressId"] = new SelectList(_context.Address, "Id", "City");
           ViewData["MeterId"] = new SelectList(_context.Meters, "Id", "Description");
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

            _context.Attach(Building).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!BuildingExists(Building.Id))
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

        private bool BuildingExists(long id)
        {
          return (_context.buildings?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
