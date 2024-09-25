using OnlineShop.Models;
using OnlineShop.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineShop.Controllers
{
    public class ProductController
    {
        private readonly ProductRepository _productRepository;

        public ProductController(ProductRepository productRepository)
        {
            _productRepository = productRepository;
        }

        public void AddProduct(Product product)
        {
            _productRepository.AddProduct(product);
            Console.WriteLine($"Product with ID {product.Id} added successfully.");
        }

        public Product GetProduct(int id)
        {
            var product = _productRepository.GetProduct(id);
            if (product == null)
            {
                Console.WriteLine($"Product with ID {id} not found.");
                return null;
            }
            Console.WriteLine($"Product with ID {id} retrieved successfully.");
            return product;
        }

        public IEnumerable<Product> GetAllProducts()
        {
            var products = _productRepository.GetAllProducts();
            Console.WriteLine("All products retrieved successfully.");
            return products;
        }
    }
}
