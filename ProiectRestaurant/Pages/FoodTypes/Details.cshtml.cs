using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using ProiectRestaurant.Data;
using ProiectRestaurant.Models;

namespace ProiectRestaurant.Pages.FoodTypes
{
    public class DetailsModel : PageModel
    {
        private readonly ProiectRestaurant.Data.ProiectRestaurantContext _context;

        public DetailsModel(ProiectRestaurant.Data.ProiectRestaurantContext context)
        {
            _context = context;
        }

      public FoodType FoodType { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null || _context.FoodType == null)
            {
                return NotFound();
            }

            var foodtype = await _context.FoodType.FirstOrDefaultAsync(m => m.ID == id);
            if (foodtype == null)
            {
                return NotFound();
            }
            else 
            {
                FoodType = foodtype;
            }
            return Page();
        }
    }
}
