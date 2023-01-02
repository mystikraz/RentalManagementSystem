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
    public class IndexModel : PageModel
    {
        private readonly RentalManagementSystem.Data.ApplicationDbContext _context;

        public IndexModel(RentalManagementSystem.Data.ApplicationDbContext context)
        {
            _context = context;
        }

        public IList<Flat> Flat { get;set; } = default!;

        public async Task OnGetAsync()
        {
            if (_context.Flats != null)
            {
                Flat = await _context.Flats
                .Include(f => f.Building)
                .Include(f => f.SubMeter).ToListAsync();
            }
        }
    }
}
