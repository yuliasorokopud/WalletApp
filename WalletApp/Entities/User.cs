using System;
using System.Collections.Generic;

namespace WalletApp
{
    public class User
    {
        private string _name;
        private string _surname;
        private string _email;
        private List<Wallet> _wallets;
        private List<Category> _categories;

        //constructors

        public User()
        {
            _name = "User";
            _surname = "Userovich";
            _email = "user@gmail.com";
            _wallets = new List<Wallet>();
            _categories = new List<Category>();
        }

        public User(string name, string surname, string email)
        {
            _name = name;
            _surname = surname;
            _email = email;
            _wallets = new List<Wallet>();
            _categories = new List<Category>();
        }

        //methods for working with wallets
        //public void addWallet(string name, string currency, string description, int start_value)
        //{
        //    _wallets.Add(new Wallet(name, currency, description, start_value));
        //}

        public void addWallet(Wallet wallet)
        {
            if (!_wallets.Contains(wallet))
                _wallets.Add(wallet) ;
        }

        /*public void deleteWallet(string name)
        {
            _wallets.Remove(Wallet(name, currency, description, start_value));
        }*/

        public void removeWallet(Wallet wallet)
        {
            if (_wallets.Contains(wallet))
                _wallets.Remove(wallet) ;
        }

    //getters & setters
    public string Name
        {
            get { return _name; }
            private set { _name = value; }
        }

        public string Surname
        {
            get { return _surname; }
            private set { _surname = value; }
        }

        public string Email
        {
            get { return _email; }
            private set { _email = value; }
        }

        public List<Wallet> Wallets
        {
            get { return _wallets; }
            private set { _wallets = value; }
        }

    }
}
