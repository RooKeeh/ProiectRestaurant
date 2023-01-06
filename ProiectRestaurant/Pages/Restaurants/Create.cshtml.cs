using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Policy;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using ProiectRestaurant.Data;
using ProiectRestaurant.Migrations;
using ProiectRestaurant.Models;

namespace ProiectRestaurant.Pages.Restaurants
{
    public class CreateModel : FoodCategoriesPageModel
    {
        private readonly ProiectRestaurant.Data.ProiectRestaurantContext _context;

        public CreateModel(ProiectRestaurant.Data.ProiectRestaurantContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
            ViewData["FoodTypeID"] = new SelectList(_context.Set<FoodType>(), "ID", "FoodTypeName");
            ViewData["ChefsID"] = new SelectList(_context.Set<Chef>(), "ID", "LastName");
            var restaurant = new Restaurant();
            restaurant.FoodCategories = new List<Models.FoodCategory>();
            PopulateAssignedCategoryData(_context, restaurant);
            return Page();
        }

        [BindProperty]
        public Restaurant Restaurant { get; set; }

        public async Task<IActionResult> OnPostAsync(string[] selectedCategories)
        {
            var newRestaurant = new Restaurant();
            if (selectedCategories != null)
            {
                newRestaurant.FoodCategories = new List<Models.FoodCategory>();
                foreach (var cat in selectedCategories)
                {
                    var catToAdd = new Models.FoodCategory
                    {
                        CategoryID = int.Parse(cat)
                    };
                    newRestaurant.FoodCategories.Add(catToAdd);
                }
            }
            if (await TryUpdateModelAsync<Restaurant>(newRestaurant, "Restaurant", i => i.Dish_Name, i => i.Chefs, i => i.Price, i => i.MenuDate, i => i.FoodTypeID))
            {
                _context.Restaurant.Add(newRestaurant);
                await _context.SaveChangesAsync();
                return RedirectToPage("./Index");
            }
            PopulateAssignedCategoryData(_context, newRestaurant);
            return Page();
        }
    }
}
