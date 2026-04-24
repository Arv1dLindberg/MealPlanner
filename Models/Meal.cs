using System.ComponentModel.DataAnnotations;

namespace MealPlanner.Models
{
    public class Meal
    {
        public int Id { get; set; }

        [Required]
        public string Name { get; set; } = string.Empty;

        public string? Category { get; set; }

        public string? Description { get; set; }

        public string? Notes { get; set; }

        public int? RecipeId { get; set; }

        public Recipe? Recipe { get; set; }

        public string? UserId { get; set; }
    }
}
