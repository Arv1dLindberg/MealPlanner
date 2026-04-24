using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using MealPlanner.Data;
using MealPlanner.Models;

namespace MealPlanner.Pages.Meals
{
    public class DetailsModel : PageModel
    {
        private readonly MealPlanner.Data.ApplicationDbContext _context;

        public DetailsModel(MealPlanner.Data.ApplicationDbContext context)
        {
            _context = context;
        }

        public Meal Meal { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var meal = await _context.Meals.FirstOrDefaultAsync(m => m.Id == id);
            if (meal == null)
            {
                return NotFound();
            }
            else
            {
                Meal = meal;
            }
            return Page();
        }
    }
}
