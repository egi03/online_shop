using OnlineShop.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OnlineShop.Repositories;

namespace OnlineShop.Controllers
{
    public class ShoppingCartController
{
    private readonly ShoppingCartRepository _shoppingCartRepository;
    private readonly UserRepository _userRepository;

    public ShoppingCartController(
        ShoppingCartRepository shoppingCartRepository,
        UserRepository userRepository)
    {
        _shoppingCartRepository = shoppingCartRepository;
        _userRepository = userRepository;
    }

    private User GetUserById(int userId)
    {
        var user = _userRepository.GetUser(userId);
        if (user == null)
        {
            Console.WriteLine($"User with ID {userId} not found.");
        }
        return user;
    }

    public void AddCart(int userId, ShoppingCart cart)
    {
        var user = GetUserById(userId);
        if (user == null) return;

        _shoppingCartRepository.AddCart(user, cart);
        Console.WriteLine($"Shopping cart for user {user.Id} added successfully.");
    }

    public ShoppingCart GetCart(int userId)
    {
        var user = GetUserById(userId);
        if (user == null) return null;

        var cart = _shoppingCartRepository.GetCart(user);
        if (cart == null)
        {
            Console.WriteLine($"Shopping cart for user {user.Id} not found.");
            return null;
        }
        Console.WriteLine($"Shopping cart for user {user.Id} retrieved successfully.");
        return cart;
    }

    public IEnumerable<ShoppingCart> GetAllCarts()
    {
        var carts = _shoppingCartRepository.GetAllCarts();
        Console.WriteLine("All shopping carts retrieved successfully.");
        return carts;
    }

    public void RemoveCart(int userId)
    {
        var user = GetUserById(userId);
        if (user == null) return;

        var removed = _shoppingCartRepository.RemoveCart(user);
        if (!removed)
        {
            Console.WriteLine($"Shopping cart for user {user.Id} not found.");
            return;
        }
        Console.WriteLine($"Shopping cart for user {user.Id} removed successfully.");
    }

    public void UpdateCart(int userId, ShoppingCart cart)
    {
        var user = GetUserById(userId);
        if (user == null) return;

        try
        {
            _shoppingCartRepository.UpdateCart(user, cart);
            Console.WriteLine($"Shopping cart for user {user.Id} updated successfully.");
        } 
        catch (KeyNotFoundException)
        {
            Console.WriteLine($"Shopping cart for user {user.Id} not found.");
        }
    }
}
}
