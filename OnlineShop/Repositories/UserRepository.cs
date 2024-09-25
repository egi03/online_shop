using OnlineShop.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineShop.Repositories
{
    public class UserRepository
    {
        private readonly List<User> _users = new List<User>();

        public void AddUser(User user)
        {
            if (user == null) throw new ArgumentNullException(nameof(user));
            _users.Add(user);
        }

        public User GetUser(int id) => _users.FirstOrDefault(user => user.Id == id);

        public IEnumerable<User> GetAllUsers() => _users;

        public bool RemoveUser(int id)
        {
            var user = GetUser(id);
            if (user == null) return false;
            return _users.Remove(user);
        }
        
        public void UpdateUser(User updatedUser)
        {
            if (updatedUser == null) throw new ArgumentNullException(nameof(updatedUser));
            var user = GetUser(updatedUser.Id);
            if (user == null) throw new KeyNotFoundException("User does not exist.");

            user.Username = updatedUser.Username;
            user.Email = updatedUser.Email;
            user.Password = updatedUser.Password;
        }
        
    }
}
