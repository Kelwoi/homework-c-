using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace linq_home
{

    public class Product
    {
        public string name { get; set; }
        public ushort producing_year {  get; set; }
        public float price { get; set; }
        public int production_count { get; set; }
        public enum CategoryType { water = 1, food, furniture, sweets }
        public string country_producer {  get; set; }
        public CategoryType Category { get; set; }

        public override string ToString()
        {
            return $"{name,-30}{producing_year,-5}{price,-10}{production_count,-10}{Category.ToString(),-10}{country_producer, -8}";
        }
    }
}
