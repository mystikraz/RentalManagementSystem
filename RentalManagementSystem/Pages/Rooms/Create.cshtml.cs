using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Data.Model;
using RentalManagementSystem.Data;
using Microsoft.AspNetCore.Identity;

namespace RentalManagementSystem.Pages.Rooms
{
    public class CreateModel : PageModel
    {
        private readonly RentalManagementSystem.Data.ApplicationDbContext _context;
        private readonly UserManager<IdentityUser> _userManager;

        public CreateModel(RentalManagementSystem.Data.ApplicationDbContext context,
            UserManager<IdentityUser> userManager
          )
        {
            _context = context;
            _userManager = userManager;
        }

        public IActionResult OnGet()
        {
        ViewData["FlatId"] = new SelectList(_context.Flats, "Id", "Description");
        ViewData["SubMeterId"] = new SelectList(_context.SubMeters, "Id", "Description");
            return Page();
        }

        [BindProperty]
        public Room Room { get; set; } = default!;
        

        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync()
        {
          if (!ModelState.IsValid || _context.Rooms == null || Room == null)
            {
                return Page();
            }
            var loggedInUser = await _userManager.GetUserAsync(User);
            Room.CreatedAt = DateTime.Now;
            Room.UpdatedAt = DateTime.Now;
            Room.CreatedBy = loggedInUser.UserName;
            _context.Rooms.Add(Room);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
