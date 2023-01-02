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
using Microsoft.AspNetCore.Authorization;

namespace RentalManagementSystem.Pages.Buildings
{
    [Authorize]
    public class CreateModel : PageModel
    {
        private readonly RentalManagementSystem.Data.ApplicationDbContext _context;
        private readonly UserManager<IdentityUser> _userManager;

        public CreateModel(RentalManagementSystem.Data.ApplicationDbContext context,
            UserManager<IdentityUser> userManager)
        {
            _context = context;
            _userManager = userManager;
        }

        public IActionResult OnGet()
        {
        ViewData["AddressId"] = new SelectList(_context.Address, "Id", "City");
        ViewData["MeterId"] = new SelectList(_context.Meters, "Id", "Description");
            return Page();
        }

        [BindProperty]
        public Building Building { get; set; } = default!;
        

        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync()
        {
          if (!ModelState.IsValid || _context.buildings == null || Building == null)
            {
                return Page();
            }

          Building.CreatedAt= DateTime.Now;
          Building.UpdatedAt = DateTime.Now;
            var loggedInUser = await _userManager.GetUserAsync(User);
            Building.CreatedBy = loggedInUser.UserName;

            _context.buildings.Add(Building);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
