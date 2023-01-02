using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Data.Model;
using RentalManagementSystem.Data;

namespace RentalManagementSystem.Pages.Rooms
{
    public class IndexModel : PageModel
    {
        private readonly RentalManagementSystem.Data.ApplicationDbContext _context;

        public IndexModel(RentalManagementSystem.Data.ApplicationDbContext context)
        {
            _context = context;
        }

        public IList<Room> Room { get;set; } = default!;

        public async Task OnGetAsync()
        {
            if (_context.Rooms != null)
            {
                Room = await _context.Rooms
                .Include(r => r.Flat)
                .Include(r => r.SubMeter).ToListAsync();
            }
        }
    }
}
