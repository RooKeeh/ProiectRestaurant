using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Xml.Linq;

namespace ProiectRestaurant.Models
{
    public class Restaurant
    {
        public int ID { get; set; }
        [Display(Name = "Dish:")]
        [StringLength(150, MinimumLength = 3)]
        [Required]
        public string? Dish_Name { get; set; }
        [Display(Name = "Price:")]
        [Column(TypeName = "decimal(6, 2)")]
        [Range(0.01, 500)]
        public decimal Price { get; set; }
        [Display(Name = "Added on:")]
        [DataType(DataType.Date)]
        public DateTime MenuDate { get; set; }
        public int? FoodTypeID { get; set; }
        public FoodType? FoodType { get; set; }
        public int? ChefsID { get; set; }
        [Display(Name = "Chef:")]
        public Chef? Chefs { get; set; }
        [Display(Name = "Categories:")]
        public ICollection<FoodCategory>? FoodCategories { get; set; }
    }
}
