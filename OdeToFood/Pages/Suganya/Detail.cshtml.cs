using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using OdeToFoodCore;
using OdeToFoodData;

namespace OdeToFood.Pages.Suganya
{
    public class DetailModel : PageModel
    {
        [TempData]
        public string Message { get; set; }
        public Restaurant Restaurant { get; set; }
        private IRestaurantRepository RestaurantRepository;
        public DetailModel(IRestaurantRepository restaurantRepository)
        {
            this.RestaurantRepository = restaurantRepository;
        }
        public IActionResult OnGet(int restaurantId)
        {
            Restaurant = this.RestaurantRepository.GetSingleRestaurant(restaurantId);
            if (Restaurant == null)
            {
                return RedirectToPage("./NotFound");
            }
            return Page();
        }
    }
}
