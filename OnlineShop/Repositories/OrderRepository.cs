using OnlineShop.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineShop.Repositories
{
    public class OrderRepository
    {
        private readonly List<Order> _orders = new List<Order>();

        public void AddOrder(Order order)
        {
            if (order == null) throw new ArgumentNullException(nameof(order));
            _orders.Add(order);
        }

        public Order GetOrder(int id) => _orders.FirstOrDefault(order => order.Id == id);

        public IEnumerable<Order> GetAllOrders() => _orders;
    }
}
