using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Text;

namespace WalletApp.Entities
{
    public class App
    {
        private List<User> _users;

        public App()
        {
            _users = new List<User>();
        }

        static void Main(string[] args)
        {
            App app = new App();
            //app.Users.Add(new User("User", "Userovich", "user@gmail.com"));
        }

        public List<User> Users
        {
            get { return _users; }
            private set { _users = value; }
        }

    }
}
