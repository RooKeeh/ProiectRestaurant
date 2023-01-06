using System.Security.Policy;

namespace ProiectRestaurant.Models.ViewModels
{
    public class FoodTypeIndexData
    {
        public IEnumerable<FoodType> FoodTypes { get; set; }
        public IEnumerable<Restaurant> Restaurants { get; set; }
    }
}
