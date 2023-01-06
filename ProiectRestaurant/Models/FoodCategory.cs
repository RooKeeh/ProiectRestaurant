namespace ProiectRestaurant.Models
{
    public class FoodCategory
    {
        public int ID { get; set; }
        public int RestaurantID { get; set; }
        public Restaurant? Restaurant { get; set; }
        public int CategoryID { get; set; }
        public Category? Category { get; set; }
    }
}
