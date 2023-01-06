using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using ProiectRestaurant.Data;
using ProiectRestaurant.Models;

namespace ProiectRestaurant.Pages.FoodCategories
{
    public class IndexModel : PageModel
    {
        private readonly ProiectRestaurant.Data.ProiectRestaurantContext _context;

        public IndexModel(ProiectRestaurant.Data.ProiectRestaurantContext context)
        {
            _context = context;
        }

        public IList<Category> Category { get;set; } = default!;

        public async Task OnGetAsync()
        {
            if (_context.Category != null)
            {
                Category = await _context.Category.ToListAsync();
            }
        }
    }
}
