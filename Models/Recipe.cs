using System.ComponentModel.DataAnnotations;

namespace MealPlanner.Models
{
    public class Recipe
    {
        public int Id { get; set; }

        [Required]
        public string Name { get; set; } = string.Empty;

        public string? Description { get; set; }

        public string? Ingredients { get; set; }

        public string? Instructions { get; set; }

        public string? UserId { get; set; }
    }
}
