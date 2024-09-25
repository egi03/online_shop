using System;
using System.Collections.Generic;
using OnlineShop.Models;
using OnlineShop.Repositories;
using OnlineShop.Controllers;

namespace OnlineShop
{
    class Program
    {
        static void Main(string[] args)
        {
            // Initialize repositories
            var userRepository = new UserRepository();
            var shoppingCartRepository = new ShoppingCartRepository();
            var productRepository = new ProductRepository();
            var orderRepository = new OrderRepository();
            var paymentRepository = new PaymentRepository();

            // Initialize controllers
            var userController = new UserController(userRepository);
            var shoppingCartController = new ShoppingCartController(shoppingCartRepository, userRepository);
            var productController = new ProductController(productRepository);
            var orderController = new OrderController(orderRepository);
            var paymentController = new PaymentController(paymentRepository);

            // Add users
            Console.WriteLine("Adding Users:");
            var user1 = new User (1, "Alice",  "alice@example.com", "Pass@123" );
            var user2 = new User ( 2, "Bob",  "bob@example.com", "Pass@456");
            userController.AddUser(user1);
            userController.AddUser(user2);

            Console.WriteLine();

            // Get users
            Console.WriteLine("Getting Users:");
            var getUser1 = userController.GetUser(1);
            Console.WriteLine($"User 1: {getUser1.Username}");
            var getUser2 = userController.GetUser(2);
            Console.WriteLine($"User 2: {getUser2.Username}");
            
            Console.WriteLine();

            // Add products
            Console.WriteLine("Adding Products:");
            var product1 = new Product (1, "Laptop", "High-end gaming laptop.", ProductCategory.HARDWARE, 999.99M, 10);
            var product2 = new Product (2, "Smartphone", "Latest model smartphone.", ProductCategory.HARDWARE,  499.99M, 20);
            productController.AddProduct(product1);
            productController.AddProduct(product2);

            Console.WriteLine();

            // Get products
            Console.WriteLine("Getting Products:");
            var getProduct1 = productController.GetProduct(1);
            Console.WriteLine($"Product 1: {getProduct1.Name} - ${getProduct1.Price}");
            var getProduct2 = productController.GetProduct(2);
            Console.WriteLine($"Product 2: {getProduct2.Name} - ${getProduct2.Price}");

            Console.WriteLine();

            // Add shopping cart for user1
            Console.WriteLine("Adding Shopping Cart for user1:");
            var cart1 = new ShoppingCart(user1);
            cart1.AddProduct(product1,1);
            cart1.AddProduct(product2,2);
            shoppingCartController.AddCart(user1.Id, cart1);

            Console.WriteLine();

            // Get shopping cart for user1
            Console.WriteLine("Getting Shopping Cart for user1:");
            var getCart1 = shoppingCartController.GetCart(user1.Id);
            Console.WriteLine($"Cart Total Price: ${getCart1.GetTotalPrice()}");

            Console.WriteLine();
            
            // Add payment for order1
            Console.WriteLine("Adding Payment for Order 1:");
            var payment1 = new Payment (1, PaymentMethod.VISA, user1, true, getCart1.GetTotalPrice());
            paymentController.AddPayment(payment1);

            Console.WriteLine();

            // Get payment
            Console.WriteLine("Getting Payment:");
            var getPayment1 = paymentController.GetPayment(1);
            Console.WriteLine($"Payment Amount: ${getPayment1.Amount}");

            Console.WriteLine();

            // Add order for user1
            Console.WriteLine("Adding Order for user1:");
            var productsInOrder = new Dictionary<Product, int>
            {
                { product1, 1 },
                { product2, 1 }
            };
            var order1 = new Order(1, user1, DateTime.Now, getCart1.GetTotalPrice(), productsInOrder, payment1);
            orderController.AddOrder(order1);

            Console.WriteLine();

            // Get order
            Console.WriteLine("Getting Order:");
            var getOrder1 = orderController.GetOrder(1);
            Console.WriteLine($"Order Total Amount: ${getOrder1.Subtotal}");

            Console.WriteLine();

            // Get all users
            Console.WriteLine("Getting All Users:");
            var allUsers = userController.GetAllUsers();
            foreach (var user in allUsers)
            {
                Console.WriteLine($"User: {user.Username}");
            }

            Console.WriteLine();

            // Update user
            Console.WriteLine("Updating User1:");
            userController.UpdateUsername(1, "Alice Updated");
            var updatedUser1 = userController.GetUser(1);
            Console.WriteLine($"Updated User1: {updatedUser1.Username}");

            Console.WriteLine();

            // Remove user2
            Console.WriteLine("Removing User2:");
            userController.RemoveUser(2);
            var removedUser2 = userController.GetUser(2);
            Console.WriteLine(removedUser2 == null ? "User2 removed successfully." : "User2 removal failed.");

            Console.WriteLine();

            // Get all shopping carts
            Console.WriteLine("Getting All Shopping Carts:");
            var allCarts = shoppingCartController.GetAllCarts();
            foreach (var cart in allCarts)
            {
                Console.WriteLine($"Cart Total Price: ${cart.GetTotalPrice()}");
            }
            
            // Print receipt for the order
            Console.WriteLine("Printing Receipt for Order 1:");
            Console.WriteLine(order1.CreateReceipt());

            Console.WriteLine("Test Completed!");
        }
    }
}