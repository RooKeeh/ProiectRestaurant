using System.ComponentModel.DataAnnotations;
using System.Xml.Linq;

namespace ProiectRestaurant.Models
{
    public class Category
    {
        public int ID { get; set; }
        [Display(Name = "Food Categories:")]
        public string FoodCategoryName { get; set; }
        public ICollection<FoodCategory>? FoodCategories { get; set; }
    }
}
