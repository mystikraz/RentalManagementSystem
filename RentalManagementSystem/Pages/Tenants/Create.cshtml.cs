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

namespace RentalManagementSystem.Pages.Tenants
{
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
        ViewData["BuildingId"] = new SelectList(_context.buildings, "Id", "Description");
        ViewData["FlatId"] = new SelectList(_context.Flats, "Id", "Description");
        ViewData["RoomId"] = new SelectList(_context.Rooms, "Id", "Description");
            return Page();
        }

        [BindProperty]
        public Tenant Tenant { get; set; } = default!;
        

        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync()
        {
          if (!ModelState.IsValid || _context.Tenants == null || Tenant == null)
            {
                return Page();
            }
            var loggedInUser = await _userManager.GetUserAsync(User);
            Tenant.CreatedAt = DateTime.Now;
            Tenant.UpdatedAt = DateTime.Now;
            Tenant.CreatedBy = loggedInUser.UserName;
            _context.Tenants.Add(Tenant);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
