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

namespace RentalManagementSystem.Pages.Flats
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
            ViewData["SubMeterId"] = new SelectList(_context.SubMeters, "Id", "Description");
            return Page();
        }

        [BindProperty]
        public Flat Flat { get; set; } = default!;


        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid || _context.Flats == null || Flat == null)
            {
                return Page();
            }
            var loggedInUser = await _userManager.GetUserAsync(User);
            Flat.CreatedAt = DateTime.Now;
            Flat.UpdatedAt = DateTime.Now;
            Flat.CreatedBy = loggedInUser.UserName;

            _context.Flats.Add(Flat);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
