using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Configuration;
using OdeToFoodCore;
using OdeToFoodData;

namespace OdeToFood.Pages.Suganya
{
    public class ListModel : PageModel
    {
        public string Message { get; set; }
        [BindProperty(SupportsGet =true)]
        public string SearchTerm { get; set; }
        private IRestaurantRepository RestaurantRepository;
        private IConfiguration Configuration;
        public IEnumerable<Restaurant> Restaurants { get; set; }
        public ListModel(IConfiguration configuration, IRestaurantRepository restaurantRepository)
        {
            this.Configuration = configuration;
            this.RestaurantRepository = restaurantRepository;
        }
        public void OnGet()
        {
            this.Message = this.Configuration["Message"];
            this.Restaurants = this.RestaurantRepository.GetRestaurantByName(SearchTerm);
        }
    }
}
