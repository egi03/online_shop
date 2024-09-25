using OnlineShop.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineShop.Repositories
{
    public class ProductRepository
    {
        private readonly List<Product> _products = new List<Product>();

        public void AddProduct(Product product)
        {
            if (product == null) throw new ArgumentNullException(nameof(product));
            _products.Add(product);
        }

        public Product GetProduct(int id) => _products.FirstOrDefault(product => product.Id == id);

        public IEnumerable<Product> GetAllProducts() => _products;
        
    }
}
