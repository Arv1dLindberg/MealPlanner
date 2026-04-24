using MealPlanner.Data;
using MealPlanner.Models;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using System.Security.Claims;

namespace MealPlanner.Pages.RandomMeal
{
    public class IndexModel : PageModel
    {
        private readonly ApplicationDbContext _context;

        public IndexModel(ApplicationDbContext context)
        {
            _context = context;
        }

        public Meal? RandomMeal { get; set; }

        public async Task OnGetAsync()
        {
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);

            var meals = await _context.Meals
                .Include(m => m.Recipe)
                .Where(m => m.UserId == userId)
                .ToListAsync();

            if (meals.Any())
            {
                var random = new System.Random();
                RandomMeal = meals[random.Next(meals.Count)];
            }
        }
    }
}