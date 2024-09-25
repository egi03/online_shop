using OnlineShop.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineShop.Repositories
{
    public class ShoppingCartRepository
    {
        private readonly Dictionary<User, ShoppingCart> _carts = new Dictionary<User, ShoppingCart>();

        public void AddCart(User user, ShoppingCart cart)
        {
            if (user == null) throw new ArgumentNullException(nameof(user));
            if (cart == null) throw new ArgumentNullException(nameof(cart));
            _carts[user] = cart;
        }

        public ShoppingCart GetCart(User user)
        {
            if (user == null) throw new ArgumentNullException(nameof(user));
            _carts.TryGetValue(user, out var cart);
            return cart;
        }

        public IEnumerable<ShoppingCart> GetAllCarts() => _carts.Values;

        public bool RemoveCart(User user)
        {
            if (user == null) throw new ArgumentNullException(nameof(user));
            return _carts.Remove(user);
        }

        public void UpdateCart(User user, ShoppingCart cart)
        {
            if (user == null) throw new ArgumentNullException(nameof(user));
            if (cart == null) throw new ArgumentNullException(nameof(cart));
            if (!_carts.ContainsKey(user))
                throw new KeyNotFoundException("Cart for the specified user does not exist.");
            _carts[user] = cart;
        }
    }
}
