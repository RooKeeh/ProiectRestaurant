using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using ProiectRestaurant.Data;
using ProiectRestaurant.Models;

namespace ProiectRestaurant.Pages.Restaurants
{
    public class IndexModel : PageModel
    {
        private readonly ProiectRestaurant.Data.ProiectRestaurantContext _context;

        public IndexModel(ProiectRestaurant.Data.ProiectRestaurantContext context)
        {
            _context = context;
        }

        public IList<Restaurant> Restaurant { get; set; } = default!;

        public RestaurantData RestaurantD { get; set; }
        public int RestaurantID { get; set; }
        public int CategoryID { get; set; }

        public string DishNameSort { get; set; }
        public string ChefSort { get; set; }

        public string CurrentFilter { get; set; }

        public async Task OnGetAsync(int? id, int? categoryID, string sortOrder, string searchString)
        {
            RestaurantD = new RestaurantData();

            DishNameSort = String.IsNullOrEmpty(sortOrder) ? "dish_name_desc" : "";
            ChefSort = String.IsNullOrEmpty(sortOrder) ? "chefs_desc" : "";

            CurrentFilter = searchString;

            RestaurantD.Restaurants = await _context.Restaurant
            .Include(b => b.Chefs)
            .Include(b => b.FoodType)
            .Include(b => b.FoodCategories)
            .ThenInclude(b => b.Category)
            .AsNoTracking()
            .OrderBy(b => b.Dish_Name)
            .ToListAsync();

            if (!String.IsNullOrEmpty(searchString))
            {
                RestaurantD.Restaurants = RestaurantD.Restaurants.Where(s => s.Chefs.FirstName.Contains(searchString)

               || s.Chefs.LastName.Contains(searchString)
               || s.Dish_Name.Contains(searchString));
            }

            if (id != null)
            {
                RestaurantID = id.Value;
                Restaurant restaurant = RestaurantD.Restaurants.Where(i => i.ID == id.Value).Single();
                RestaurantD.Categories = restaurant.FoodCategories.Select(s => s.Category);
            }

            switch (sortOrder)
            {
                case "dish_name_desc":
                    RestaurantD.Restaurants = RestaurantD.Restaurants.OrderByDescending(s =>
                   s.Dish_Name);
                    break;
                case "chefs_desc":
                    RestaurantD.Restaurants = RestaurantD.Restaurants.OrderByDescending(s =>
                   s.Chefs.FullName);
                    break;
            }
        }
    }
}
