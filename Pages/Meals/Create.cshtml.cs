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
        private readonly ApplicationDbContext _context;

        public CreateModel(ApplicationDbContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Meal Meal { get; set; } = default!;

        public SelectList? RecipeOptions { get; set; }

        public IActionResult OnGet()
        {
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);

            RecipeOptions = new SelectList(
                _context.Recipes.Where(r => r.UserId == userId),
                "Id",
                "Name"
            );

            return Page();
        }

        public async Task<IActionResult> OnPostAsync()
        {
            Meal.UserId = User.FindFirstValue(ClaimTypes.NameIdentifier);

            if (!ModelState.IsValid)
            {
                var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);

                RecipeOptions = new SelectList(
                    _context.Recipes.Where(r => r.UserId == userId),
                    "Id",
                    "Name"
                );

                return Page();
            }

            _context.Meals.Add(Meal);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}