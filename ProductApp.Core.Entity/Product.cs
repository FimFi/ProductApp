using System;

namespace ProductApp.Core.Entity
{
    public class Product
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public double Price { get; set; }
        // picture?
       // public ?? Picture { get; set; }
        public string Type { get; set; }
    }
}
