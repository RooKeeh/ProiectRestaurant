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
    public class DeleteModel : PageModel
    {
        private readonly ProiectRestaurant.Data.ProiectRestaurantContext _context;

        public DeleteModel(ProiectRestaurant.Data.ProiectRestaurantContext context)
        {
            _context = context;
        }

        [BindProperty]
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

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null || _context.FoodType == null)
            {
                return NotFound();
            }
            var foodtype = await _context.FoodType.FindAsync(id);

            if (foodtype != null)
            {
                FoodType = foodtype;
                _context.FoodType.Remove(FoodType);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
