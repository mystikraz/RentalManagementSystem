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
    public class DetailsModel : PageModel
    {
        private readonly RentalManagementSystem.Data.ApplicationDbContext _context;

        public DetailsModel(RentalManagementSystem.Data.ApplicationDbContext context)
        {
            _context = context;
        }

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
    }
}
