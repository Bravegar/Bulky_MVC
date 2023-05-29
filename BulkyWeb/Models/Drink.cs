using System.ComponentModel.DataAnnotations;

namespace BulkyWeb.Models
{
    public class Drink
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        public string Description { get; set; }
        public int CaloriesPerServing { get; set; }
        
    }
}
