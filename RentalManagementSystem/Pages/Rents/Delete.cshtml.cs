using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Data.Model;
using RentalManagementSystem.Data;

namespace RentalManagementSystem.Pages.Rents
{
    public class DeleteModel : PageModel
    {
        private readonly RentalManagementSystem.Data.ApplicationDbContext _context;

        public DeleteModel(RentalManagementSystem.Data.ApplicationDbContext context)
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

            var rent = await _context.Rents.FirstOrDefaultAsync(m => m.Id == id);

            if (rent == null)
            {
                return NotFound();
            }
            else 
            {
                Rent = rent;
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(long? id)
        {
            if (id == null || _context.Rents == null)
            {
                return NotFound();
            }
            var rent = await _context.Rents.FindAsync(id);

            if (rent != null)
            {
                Rent = rent;
                _context.Rents.Remove(Rent);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
