using OdeToFoodCore;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace OdeToFoodData
{
    public interface IRestaurantRepository
    {
        IEnumerable<Restaurant> GetRestaurant();
        IEnumerable<Restaurant> GetRestaurantByName(string name);
        Restaurant GetSingleRestaurant(int id);
    }
    public class RestaurantRepository : IRestaurantRepository
    {
        private List<Restaurant> restaurants;
        public RestaurantRepository()
        {
            this.restaurants = new List<Restaurant>();
            restaurants.Add(new Restaurant() { 
            Id=3,
            Name="Scoot Pizza",
            Location="5th street",
            CusineType=CusineType.Indian,
            });
            restaurants.Add(new Restaurant()
            {
                Id = 1,
                Name = "Nala Hotel",
                Location = "6th street",
                CusineType = CusineType.Italian,
            });
            restaurants.Add(new Restaurant()
            {
                Id = 2,
                Name = "Ramakirshana",
                Location = "7th street",
                CusineType = CusineType.Mexican,
            });
        }
        public IEnumerable<Restaurant> GetRestaurant()
        {
            return this.restaurants;   
        }

        public IEnumerable<Restaurant> GetRestaurantByName(string name)
        {
            return this.restaurants.Where(x => string.IsNullOrEmpty(name) || x.Name.StartsWith(name, StringComparison.OrdinalIgnoreCase));
        }
        public Restaurant GetSingleRestaurant(int id)
        {
            if (restaurants.Any(x=>x.Id==id))
            {
                return this.restaurants.First(x => x.Id == id);
            }
            return null;
        }
    }
}
