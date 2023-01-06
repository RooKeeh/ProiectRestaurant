using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Policy;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using ProiectRestaurant.Data;
using ProiectRestaurant.Models;
using ProiectRestaurant.Models.ViewModels;

namespace ProiectRestaurant.Pages.FoodTypes
{
    public class IndexModel : PageModel
    {
        private readonly ProiectRestaurant.Data.ProiectRestaurantContext _context;

        public IndexModel(ProiectRestaurant.Data.ProiectRestaurantContext context)
        {
            _context = context;
        }

        public IList<FoodType> FoodType { get; set; } = default!;

        public FoodTypeIndexData FoodTypeData { get; set; }
        public int FoodTypeID { get; set; }
        public int RestaurantID { get; set; }
        public async Task OnGetAsync(int? id, int? restaurantID)
        {
            FoodTypeData = new FoodTypeIndexData();
            FoodTypeData.FoodTypes = await _context.FoodType
            .Include(i => i.Restaurants)
            .ThenInclude(c => c.Chefs)
            .OrderBy(i => i.FoodTypeName)
            .ToListAsync();
            if (id != null)
            {
                FoodTypeID = id.Value;
                FoodType foodType = FoodTypeData.FoodTypes
                .Where(i => i.ID == id.Value).Single();
                FoodTypeData.Restaurants = foodType.Restaurants;
            }
        }
    }
}
