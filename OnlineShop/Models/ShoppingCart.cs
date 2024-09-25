using System;
using System.Buffers;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineShop.Models
{
    public class ShoppingCart
    {
        #region Properties
        public User Owner { get; private set; }
        public Dictionary<Product, int> Products { get; private set; }
        #endregion

        #region Constructors
        public ShoppingCart(User owner)
        {
            Owner = owner ?? throw new ArgumentNullException(nameof(owner), "Shopping cart must have an owner");
            Products = new Dictionary<Product, int>();
        }
        #endregion

        #region Methods
        public void AddProduct(Product product, int quantity)
        {
            if (product == null)
                throw new ArgumentNullException(nameof(product), "Product cannot be null");
            if (quantity <= 0)
                throw new ArgumentOutOfRangeException(nameof(quantity), "Quantity must be greater than zero");

            if (Products.ContainsKey(product))
            {
                Products[product] += quantity;
            }
            else
            {
                Products[product] = quantity;
            }
        }
        
        public void RemoveProduct(Product product, int quantity)
        {
            if (product == null)
                throw new ArgumentNullException(nameof(product), "Product cannot be null");
            if (quantity <= 0)
                throw new ArgumentOutOfRangeException(nameof(quantity), "Quantity must be greater than zero");

            if (Products.ContainsKey(product))
            {
                Products[product] -= quantity;
                if (Products[product] <= 0)
                {
                    Products.Remove(product);
                }
            }
        }
        public void ClearCart()
        {
            Products.Clear();
        }

        public decimal GetTotalPrice()
        {
            decimal totalPrice = 0M;
            foreach (var product in Products)
            {
                totalPrice += product.Key.Price * product.Value;
            }
            return totalPrice;
        }
        #endregion
    }
}
