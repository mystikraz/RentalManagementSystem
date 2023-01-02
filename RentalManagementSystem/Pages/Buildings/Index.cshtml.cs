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
    public class IndexModel : PageModel
    {
        private readonly RentalManagementSystem.Data.ApplicationDbContext _context;

        public IndexModel(RentalManagementSystem.Data.ApplicationDbContext context)
        {
            _context = context;
        }

        public IList<Building> Building { get;set; } = default!;

        public async Task OnGetAsync()
        {
            if (_context.buildings != null)
            {
                Building = await _context.buildings
                .Include(b => b.Address)
                .Include(b => b.Meter).ToListAsync();
            }
        }
    }
}
