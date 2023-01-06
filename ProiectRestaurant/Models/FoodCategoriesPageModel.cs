using Microsoft.AspNetCore.Mvc.RazorPages;
using ProiectRestaurant.Data;
using ProiectRestaurant.Migrations;

namespace ProiectRestaurant.Models
{
    public class FoodCategoriesPageModel : PageModel
    {
        public List<AssignedFoodCategoryData>? AssignedCategoryDataList;
        public void PopulateAssignedCategoryData(ProiectRestaurantContext context,
        Restaurant restaurant)
        {
            var allCategories = context.Category;
            var foodCategories = new HashSet<int>(restaurant.FoodCategories.Select(c => c.CategoryID));
            AssignedCategoryDataList = new List<AssignedFoodCategoryData>();
            foreach (var cat in allCategories)
            {
                AssignedCategoryDataList.Add(new AssignedFoodCategoryData
                {
                    CategoryID = cat.ID,
                    Name = cat.FoodCategoryName,
                    Assigned = foodCategories.Contains(cat.ID)
                });
            }
        }
        public void UpdateRestaurantCategories(ProiectRestaurantContext context,
        string[] selectedCategories, Restaurant foodToUpdate)
        {
            if (selectedCategories == null)
            {
                foodToUpdate.FoodCategories = new List<FoodCategory>();
                return;
            }
            var selectedCategoriesHS = new HashSet<string>(selectedCategories);
            var foodCategories = new HashSet<int>
            (foodToUpdate.FoodCategories.Select(c => c.Category.ID));
            foreach (var cat in context.Category)
            {
                if (selectedCategoriesHS.Contains(cat.ID.ToString()))
                {
                    if (!foodCategories.Contains(cat.ID))
                    {
                        foodToUpdate.FoodCategories.Add(
                        new FoodCategory
                        {
                            RestaurantID = foodToUpdate.ID,
                            CategoryID = cat.ID
                        });
                    }
                }
                else
                {
                    if (foodCategories.Contains(cat.ID))
                    {
                        FoodCategory courseToRemove
                        = foodToUpdate
                        .FoodCategories
                        .SingleOrDefault(i => i.CategoryID == cat.ID);
                        context.Remove(courseToRemove);
                    }
                }
            }
        }
    }
}
