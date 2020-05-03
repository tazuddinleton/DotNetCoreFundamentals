using System;
using System.Collections.Generic;
using System.Text;

namespace SimpleTaskManager.Data.Entities
{
    public class User
    {
        public int Id { get; set; }        
        public string Username { get; set; }
        public string Password { get; set; }
        public string Role { get; set; }
        public string FavoriteColor { get; set; }

        public string ExternalLoginId { get; set; }

        public bool Active { get; set; }

    }
}
