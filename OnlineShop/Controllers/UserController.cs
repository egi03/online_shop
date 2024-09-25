using OnlineShop.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata;
using System.Text;
using System.Threading.Tasks;
using OnlineShop.Repositories;

namespace OnlineShop.Controllers
{
    public class UserController
    {
        private readonly UserRepository _userRepository;

        public UserController(UserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public void AddUser(User user)
        {
            _userRepository.AddUser(user);
            Console.WriteLine($"User with ID {user.Id} added successfully.");
        }

        public User GetUser(int id)
        {
            var user = _userRepository.GetUser(id);
            if (user == null)
            {
                Console.WriteLine($"User with ID {id} not found.");
                return null;
            }
            Console.WriteLine($"User with ID {id} retrieved successfully.");
            return user;
        }

        public IEnumerable<User> GetAllUsers()
        {
            var users = _userRepository.GetAllUsers();
            Console.WriteLine("All users retrieved successfully.");
            return users;
        }

        public void RemoveUser(int id)
        {
            var removed = _userRepository.RemoveUser(id);
            if (!removed)
            {
                Console.WriteLine($"User with ID {id} not found.");
                return;
            }
            Console.WriteLine($"User with ID {id} removed successfully.");
        }
        
        
        public void UpdateUsername(int userId, string newUsername)
        {
            var user = _userRepository.GetUser(userId);
            if (user != null)
            {
                user.Username = newUsername;
                _userRepository.UpdateUser(user);
            }
            else
            {
                throw new ArgumentException("User not found.");
            }
        }

        public void UpdateEmail(int userId, string newEmail)
        {
            var user = _userRepository.GetUser(userId);
            if (user != null)
            {
                user.Email = newEmail;
                _userRepository.UpdateUser(user);
            }
            else
            {
                throw new ArgumentException("User not found.");
            }
        }

        public void UpdatePassword(int userId, string newPassword)
        {
            var user = _userRepository.GetUser(userId);
            if (user != null)
            {
                user.Password = newPassword;
                _userRepository.UpdateUser(user);
            }
            else
            {
                throw new ArgumentException("User not found.");
            }
        }
        
    }
}
