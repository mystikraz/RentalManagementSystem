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

namespace RentalManagementSystem.Pages.SubMeters
{
    public class EditModel : PageModel
    {
        private readonly RentalManagementSystem.Data.ApplicationDbContext _context;

        public EditModel(RentalManagementSystem.Data.ApplicationDbContext context)
        {
            _context = context;
        }

        [BindProperty]
        public SubMeter SubMeter { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(long? id)
        {
            if (id == null || _context.SubMeters == null)
            {
                return NotFound();
            }

            var submeter =  await _context.SubMeters.FirstOrDefaultAsync(m => m.Id == id);
            if (submeter == null)
            {
                return NotFound();
            }
            SubMeter = submeter;
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

            _context.Attach(SubMeter).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!SubMeterExists(SubMeter.Id))
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

        private bool SubMeterExists(long id)
        {
          return (_context.SubMeters?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
