using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Data.Model;
using RentalManagementSystem.Data;

namespace RentalManagementSystem.Pages.Addresses
{
    public class DetailsModel : PageModel
    {
        private readonly RentalManagementSystem.Data.ApplicationDbContext _context;

        public DetailsModel(RentalManagementSystem.Data.ApplicationDbContext context)
        {
            _context = context;
        }

      public Address Address { get; set; } = default!; 

        public async Task<IActionResult> OnGetAsync(long? id)
        {
            if (id == null || _context.Address == null)
            {
                return NotFound();
            }

            var address = await _context.Address.FirstOrDefaultAsync(m => m.Id == id);
            if (address == null)
            {
                return NotFound();
            }
            else 
            {
                Address = address;
            }
            return Page();
        }
    }
}
