using System;
using System.ComponentModel.DataAnnotations;

namespace OdeToFoodCore
{
    public class Restaurant
    {
        public int Id { get; set; }
        [Required,StringLength(50)]
        public string Name { get; set; }
        [Required,StringLength(255)]
        public string  Location { get; set; }
        public CusineType CusineType { get; set; }

    }
}
