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
                Role = "Admin"
            });
        }
        public User GetByUsernameAndPassword(string username, string password)
        {
            return _users.FirstOrDefault(user => user.Username == username && user.Password == password.ToSHA256());
        }
    }
}
