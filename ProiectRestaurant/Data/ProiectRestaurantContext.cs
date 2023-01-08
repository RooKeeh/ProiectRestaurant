using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using ProiectRestaurant.Models;

namespace ProiectRestaurant.Data
{
    public class ProiectRestaurantContext : DbContext
    {
        public ProiectRestaurantContext (DbContextOptions<ProiectRestaurantContext> options)
            : base(options)
        {
        }

        public DbSet<ProiectRestaurant.Models.Restaurant> Restaurant { get; set; } = default!;

        public DbSet<ProiectRestaurant.Models.FoodType> FoodType { get; set; }

        public DbSet<ProiectRestaurant.Models.Category> Category { get; set; }

        public DbSet<ProiectRestaurant.Models.Chef> Chef { get; set; }
    }
}
