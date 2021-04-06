using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CafeApp
{


    public class Product
    {
        public string name { get; set; }
        public int price { get; set; }
        public string image { get; set; }
        public string ingredients { get; set; }
        public string food_value { get; set; }

        public Product(string name, int price, string image, string ingredients)
        {
            this.name = name;
            this.price = price;
            this.image = image;
            this.ingredients = ingredients;
        }
    }
}
