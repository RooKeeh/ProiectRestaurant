using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using ProiectRestaurant.Data;
using ProiectRestaurant.Models;

namespace ProiectRestaurant.Pages.Chefs
{
    public class DetailsModel : PageModel
    {
        private readonly ProiectRestaurant.Data.ProiectRestaurantContext _context;

        public DetailsModel(ProiectRestaurant.Data.ProiectRestaurantContext context)
        {
            _context = context;
        }

      public Chef Chef { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null || _context.Chef == null)
            {
                return NotFound();
            }

            var chef = await _context.Chef.FirstOrDefaultAsync(m => m.ID == id);
            if (chef == null)
            {
                return NotFound();
            }
            else 
            {
                Chef = chef;
            }
            return Page();
        }
    }
}
