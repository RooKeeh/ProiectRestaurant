using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Policy;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using ProiectRestaurant.Data;
using ProiectRestaurant.Models;

namespace ProiectRestaurant.Pages.Restaurants
{
    public class EditModel : FoodCategoriesPageModel
    {
        private readonly ProiectRestaurant.Data.ProiectRestaurantContext _context;

        public EditModel(ProiectRestaurant.Data.ProiectRestaurantContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Restaurant Restaurant { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null || _context.Restaurant == null)
            {
                return NotFound();
            }

            var restaurant = await _context.Restaurant.Include(b => b.FoodType).Include(b => b.FoodCategories).ThenInclude(b => b.Category).AsNoTracking().FirstOrDefaultAsync(m => m.ID == id);
            if (restaurant == null)
            {
                return NotFound();
            }
            PopulateAssignedCategoryData(_context, restaurant);
            Restaurant = restaurant;
            ViewData["FoodTypeID"] = new SelectList(_context.Set<FoodType>(), "ID", "FoodTypeName");
            ViewData["ChefsID"] = new SelectList(_context.Set<Chef>(), "ID", "FullName");
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int? id, string[] selectedCategories)
        {
            if (id == null)
            {
                return NotFound();
            }
            var restaurantToUpdate = await _context.Restaurant.Include(i => i.FoodType).Include(i => i.FoodCategories).ThenInclude(i => i.Category).FirstOrDefaultAsync(s => s.ID == id);
            if (restaurantToUpdate == null)
            {
                return NotFound();
            }
            if (await TryUpdateModelAsync<Restaurant>(restaurantToUpdate, "Restaurant", i => i.Dish_Name, i => i.ChefsID, i => i.Price, i => i.MenuDate, i => i.FoodType))
            {
                UpdateRestaurantCategories(_context, selectedCategories, restaurantToUpdate);
                await _context.SaveChangesAsync();
                return RedirectToPage("./Index");
            }
            UpdateRestaurantCategories(_context, selectedCategories, restaurantToUpdate);
            PopulateAssignedCategoryData(_context, restaurantToUpdate);
            return Page();
        }
    }
}
