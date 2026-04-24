using System.ComponentModel.DataAnnotations;

namespace MealPlanner.Models
{
    public class Meal
    {
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

        public string? Category { get; set; }

        public string? UserId { get; set; }
    }
}
