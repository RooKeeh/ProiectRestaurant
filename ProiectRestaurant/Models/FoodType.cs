using System.ComponentModel.DataAnnotations;
using System.Xml.Linq;

namespace ProiectRestaurant.Models
{
    public class FoodType
    {
        public int ID { get; set; }
        [Display(Name = "Remarks:")]
        public string? FoodTypeName { get; set; }
        public ICollection<Restaurant>? Restaurants { get; set; }
    }
}
