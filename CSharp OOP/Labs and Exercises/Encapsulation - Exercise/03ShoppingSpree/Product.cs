using System;

namespace _03ShoppingSpree
{
    public class Product : Person
    {
        public Product(string name, decimal money) 
            : base(name, money)
        {
            this.Name = name;
            this.Cost = money;
        }

        public string Name { get; set; }
        

        public decimal Cost { get; set; }
        
    }
}
