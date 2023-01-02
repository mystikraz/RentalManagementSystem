using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Data.Model;
using RentalManagementSystem.Data;

namespace RentalManagementSystem.Pages.Buildings
{
    public class DetailsModel : PageModel
    {
        private readonly RentalManagementSystem.Data.ApplicationDbContext _context;

        public DetailsModel(RentalManagementSystem.Data.ApplicationDbContext context)
        {
            _context = context;
        }

      public Building Building { get; set; } = default!; 

        public async Task<IActionResult> OnGetAsync(long? id)
        {
            if (id == null || _context.buildings == null)
            {
                return NotFound();
            }

            var building = await _context.buildings.FirstOrDefaultAsync(m => m.Id == id);
            if (building == null)
            {
                return NotFound();
            }
            else 
            {
                Building = building;
            }
            return Page();
        }
    }
}
