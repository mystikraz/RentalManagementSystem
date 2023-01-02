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

namespace RentalManagementSystem.Pages.Rents
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
        ViewData["TenantId"] = new SelectList(_context.Tenants, "Id", "Description");
            return Page();
        }

        [BindProperty]
        public Rent Rent { get; set; } = default!;
        

        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync()
        {
          if (!ModelState.IsValid || _context.Rents == null || Rent == null)
            {
                return Page();
            }
            var loggedInUser = await _userManager.GetUserAsync(User);
            Rent.CreatedAt = DateTime.Now;
            Rent.UpdatedAt = DateTime.Now;
            Rent.CreatedBy = loggedInUser.UserName;
            _context.Rents.Add(Rent);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
