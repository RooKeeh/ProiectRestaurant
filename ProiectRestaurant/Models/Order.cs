using System.ComponentModel.DataAnnotations;
using System.Diagnostics.Metrics;

namespace ProiectRestaurant.Models
{
    public class Order
    {
        public int ID { get; set; }
        [Display(Name = "Full Name:")]
        public int? ClientID { get; set; }
        [Display(Name = "Client:")]
        public Client? Client { get; set; }
        [Display(Name = "Dish and Chef Names:")]
        public int? RestaurantID { get; set; }
        [Display(Name = "Dish Name:")]
        public Restaurant? Restaurant { get; set; }
        [DataType(DataType.Date)]
        [Display(Name = "Order Date:")]
        public DateTime OrderDate { get; set; }
    }
}
