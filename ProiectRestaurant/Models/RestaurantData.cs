using ProiectRestaurant.Migrations;

namespace ProiectRestaurant.Models
{
    public class RestaurantData
    {
        public IEnumerable<Restaurant>? Restaurants { get; set; }
        public IEnumerable<Category>? Categories { get; set; }
        public IEnumerable<FoodCategory>? FoodCategories { get; set; }
    }
}
