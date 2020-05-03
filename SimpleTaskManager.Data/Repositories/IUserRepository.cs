using SimpleTaskManager.Data.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace SimpleTaskManager.Data.Repositories
{
    public interface IUserRepository
    {
        User GetByUsernameAndPassword(string username, string password);
        User GetByEmail(string googleId);
        bool IsActiveUser(string name);
    }
}
