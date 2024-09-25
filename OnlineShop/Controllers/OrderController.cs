using OnlineShop.Helpers;
using OnlineShop.Models;
using OnlineShop.Repositories;
using System;
using System.Collections.Generic;

namespace OnlineShop.Controllers
{

    public class OrderController
    {
        private readonly OrderRepository _orderRepository;

        public OrderController(OrderRepository orderRepository)
        {
            _orderRepository = orderRepository;
        }

        public void AddOrder(Order order)
        {
            _orderRepository.AddOrder(order);
            Console.WriteLine($"Order with ID {order.Id} added successfully.");
        }

        public Order GetOrder(int id)
        {
            var order = _orderRepository.GetOrder(id);
            if (order == null)
            {
                Console.WriteLine($"Order with ID {id} not found.");
                return null;
            }
            Console.WriteLine($"Order with ID {id} retrieved successfully.");
            return order;
        }

        public IEnumerable<Order> GetAllOrders()
        {
            var orders = _orderRepository.GetAllOrders();
            Console.WriteLine("All orders retrieved successfully.");
            return orders;
        }
    }
}