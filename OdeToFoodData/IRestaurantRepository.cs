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
        Restaurant UpdateRestaurant(Restaurant updaterestaurant);
        Restaurant Add(Restaurant newRestaurant);
        int commit();
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

        public Restaurant Add(Restaurant newRestaurant)
        {
            restaurants.Add(newRestaurant);
            newRestaurant.Id = restaurants.Max(r=>r.Id)+1;
            return newRestaurant;
        }

        public int commit()
        {
            return 1;
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

        public Restaurant UpdateRestaurant(Restaurant updaterestaurant)
        {
            var restaurant = restaurants.SingleOrDefault(r => r.Id == updaterestaurant.Id);
            if (restaurant != null)
            {
                restaurant.Name = updaterestaurant.Name;
                restaurant.Location = updaterestaurant.Location;
                restaurant.CusineType = updaterestaurant.CusineType;
            }
            return restaurant;
        }
    }
}
