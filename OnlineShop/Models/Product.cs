using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineShop.Models
{
    public enum ProductCategory
    {
        SOFTWARE,
        HARDWARE,
        PERIPHERAL
    }
    
    public class Product
    {
        #region Properties

        public int Id { get; private set; }
        public string Name { get; private set; }
        public string Description { get; private set; }
        public ProductCategory Category { get; private set; }
        public decimal Price { get; private set; }
        public int Stock { get; private set; }

        #endregion

        #region Constructors
        public Product(int id, string name, string description, ProductCategory category, decimal price, int stock)
        {
            if (string.IsNullOrWhiteSpace(name))
                throw new ArgumentException("Product name cannot be null or empty", nameof(name));
            if (string.IsNullOrWhiteSpace(description))
                throw new ArgumentException("Product description cannot be null or empty", nameof(description));
            if (price < 0)
                throw new ArgumentOutOfRangeException(nameof(price), "Product price cannot be negative");
            if (stock < 0)
                throw new ArgumentOutOfRangeException(nameof(stock), "Product stock cannot be negative");

            Id = id;
            Name = name;
            Description = description;
            Category = category;
            Price = price;
            Stock = stock;
        }

        #endregion

        #region Methods
        public void DecrementStock()
        {
            if (Stock <= 0)
                throw new InvalidOperationException("Cannot decrement stock below zero");

            Stock--;
        }
        
        public void IncrementStock()
        {
            Stock++;
        }


        public void SetStock(int value)
        {
            if (value < 0)
                throw new ArgumentOutOfRangeException(nameof(value), "Stock value cannot be negative");

            Stock = value;
        }

        public void ChangePrice(decimal newPrice)
        {
            if (newPrice < 0)
                throw new ArgumentOutOfRangeException(nameof(newPrice), "Price cannot be negative");

            Price = newPrice;
        }

        #endregion
    }
}
