﻿using System;
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

namespace RentalManagementSystem.Pages.Meters
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
            return Page();
        }

        [BindProperty]
        public Meter Meter { get; set; } = default!;
        

        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync()
        {
          if (!ModelState.IsValid || _context.Meters == null || Meter == null)
            {
                return Page();
            }
            var loggedInUser = await _userManager.GetUserAsync(User);
            Meter.CreatedAt = DateTime.Now;
            Meter.UpdatedAt = DateTime.Now;
            Meter.CreatedBy = loggedInUser.UserName;
            _context.Meters.Add(Meter);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
