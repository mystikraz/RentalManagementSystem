using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Data.Model;
using RentalManagementSystem.Data;

namespace RentalManagementSystem.Pages.Meters
{
    public class DeleteModel : PageModel
    {
        private readonly RentalManagementSystem.Data.ApplicationDbContext _context;

        public DeleteModel(RentalManagementSystem.Data.ApplicationDbContext context)
        {
            _context = context;
        }

        [BindProperty]
      public Meter Meter { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(long? id)
        {
            if (id == null || _context.Meters == null)
            {
                return NotFound();
            }

            var meter = await _context.Meters.FirstOrDefaultAsync(m => m.Id == id);

            if (meter == null)
            {
                return NotFound();
            }
            else 
            {
                Meter = meter;
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(long? id)
        {
            if (id == null || _context.Meters == null)
            {
                return NotFound();
            }
            var meter = await _context.Meters.FindAsync(id);

            if (meter != null)
            {
                Meter = meter;
                _context.Meters.Remove(Meter);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
