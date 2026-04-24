using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using MealPlanner.Data;
using MealPlanner.Models;
using System.Security.Claims;

namespace MealPlanner.Pages.Meals
{
    public class CreateModel : PageModel
    {
        private readonly MealPlanner.Data.ApplicationDbContext _context;

        public CreateModel(MealPlanner.Data.ApplicationDbContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
            return Page();
        }

        [BindProperty]
        public Meal Meal { get; set; } = default!;

        // For more information, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            Meal.UserId = User.FindFirstValue(ClaimTypes.NameIdentifier);

            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Meals.Add(Meal);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
