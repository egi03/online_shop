using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineShop.Models
{
    /// <summary>
    /// Represents a user in the online shop.
    /// </summary>
    public class User
    {
        #region Properties

        public int Id { get; set; }
        public string Username { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }

        #endregion

        #region Constructors
        public User(int id, string username, string email, string password)
        {
            if (string.IsNullOrWhiteSpace(username))
                throw new ArgumentException("Username cannot be null or empty", nameof(username));
            if (string.IsNullOrWhiteSpace(email))
                throw new ArgumentException("Email cannot be null or empty", nameof(email));
            if (string.IsNullOrWhiteSpace(password))
                throw new ArgumentException("Password cannot be null or empty", nameof(password));

            Id = id;
            Username = username;
            Email = email;
            Password = password;
        }

        #endregion
    }
}
