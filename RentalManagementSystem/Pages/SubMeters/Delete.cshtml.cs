using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Data.Model;
using RentalManagementSystem.Data;

namespace RentalManagementSystem.Pages.SubMeters
{
    public class DeleteModel : PageModel
    {
        private readonly RentalManagementSystem.Data.ApplicationDbContext _context;

        public DeleteModel(RentalManagementSystem.Data.ApplicationDbContext context)
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

            var submeter = await _context.SubMeters.FirstOrDefaultAsync(m => m.Id == id);

            if (submeter == null)
            {
                return NotFound();
            }
            else 
            {
                SubMeter = submeter;
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(long? id)
        {
            if (id == null || _context.SubMeters == null)
            {
                return NotFound();
            }
            var submeter = await _context.SubMeters.FindAsync(id);

            if (submeter != null)
            {
                SubMeter = submeter;
                _context.SubMeters.Remove(SubMeter);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
