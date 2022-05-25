using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Restaurant_ad0666
{
    class User
    {
        public int Id { set; get; }
        public string UserName { set; get; }
        public string Password { set; get; }
        public User() { }
        public User(int id, string userName, string password)
        {
            Id = id;
            UserName = userName;
            Password = password;
        }

    }
}
