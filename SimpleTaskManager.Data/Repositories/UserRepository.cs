using SimpleTaskManager.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SimpleTaskManager.Data.Repositories
{
    public class UserRepository : IUserRepository
    {
        private List<User> _users;
        public UserRepository()
        {
            _users = new List<User>();
            _users.Add(new User()
            {
                Id = 1,
                Username = "tazuddin",
                Password = "A6xnQhbz4Vx2HuGl4lXwZ5U2I8iziLRFnhP5eNfIRvQ=",
                FavoriteColor = "Blue",
                Role = "Admin",
                Active = true,
                ExternalLoginId = "getleton@gmail.com"
            });

            _users.Add(new User()
            {
                Id = 1,
                Username = "kevin",
                Password = "A6xnQhbz4Vx2HuGl4lXwZ5U2I8iziLRFnhP5eNfIRvQ=",
                FavoriteColor = "Blue",
                Role = "Admin",
                Active = false
            });
        }

        public User GetByEmail(string googleId)
        {
            return _users.FirstOrDefault(user => user.ExternalLoginId == googleId);
        }

        public User GetByUsernameAndPassword(string username, string password)
        {
            return _users.FirstOrDefault(user => user.Username == username && user.Password == password.ToSHA256());
        }

        public bool IsActiveUser(string name)
        {
            var user = _users.FirstOrDefault(user => user.Username == name);
            return user != null && user.Active;
        }
    }
}
