using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using OdeToFoodCore;
using OdeToFoodData;

namespace OdeToFood.Pages.Suganya
{
    public class EditModel : PageModel
    {
        
        [BindProperty]
        public Restaurant Restaurant { get; set; }
        private IRestaurantRepository restaurantRepository;
        private IHtmlHelper htmlHelper;
        public IEnumerable<SelectListItem> CusineType { get; set; }
        public EditModel(IRestaurantRepository restaurantRepository,IHtmlHelper htmlHelper)
        {
            this.restaurantRepository = restaurantRepository;
            this.htmlHelper = htmlHelper;
        }
        public IActionResult OnGet(int? restaurantid)
        {
            CusineType = htmlHelper.GetEnumSelectList<CusineType>();
            if (restaurantid.HasValue)
            {
                Restaurant = restaurantRepository.GetSingleRestaurant  (restaurantid.Value);
            }
            else
            {
                Restaurant = new Restaurant();
            }
            if (Restaurant == null)
            {
                return RedirectToPage("./NotFound");
            }
            return Page();
        }
        public IActionResult OnPost()
        {
            if (!ModelState.IsValid)
            {
                CusineType = htmlHelper.GetEnumSelectList<CusineType>();

                return Page();
                
            }
            if (Restaurant.Id>0)
            {
                restaurantRepository.UpdateRestaurant(Restaurant);
            }
            else
            {
                restaurantRepository.Add(Restaurant);
            }
            restaurantRepository.commit();
            TempData["Message"] = "Restaruant Saved";
            return RedirectToPage("./Detail", new { restaurantId = Restaurant.Id });
        }
    }
}
