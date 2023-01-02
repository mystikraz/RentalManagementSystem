using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Data.Model;
using RentalManagementSystem.Data;

namespace RentalManagementSystem.Pages.Flats
{
    public class DetailsModel : PageModel
    {
        private readonly RentalManagementSystem.Data.ApplicationDbContext _context;

        public DetailsModel(RentalManagementSystem.Data.ApplicationDbContext context)
        {
            _context = context;
        }

      public Flat Flat { get; set; } = default!; 

        public async Task<IActionResult> OnGetAsync(long? id)
        {
            if (id == null || _context.Flats == null)
            {
                return NotFound();
            }

            var flat = await _context.Flats.FirstOrDefaultAsync(m => m.Id == id);
            if (flat == null)
            {
                return NotFound();
            }
            else 
            {
                Flat = flat;
            }
            return Page();
        }
    }
}
