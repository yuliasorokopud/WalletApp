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


        //constructor
        public User(string name, string surname, string email)
        {
            _name = name;
            _surname = surname;
            _email = email;
            _wallets = new List<Wallet>();
            _categories = new List<Category>();
        }



        //methods for working with wallets

        public void addWallet(Wallet wallet)
        {
            if (!_wallets.Contains(wallet))
                _wallets.Add(wallet) ;
        }

      
        public void removeWallet(Wallet wallet)
        {
            if (_wallets.Contains(wallet))
                _wallets.Remove(wallet) ;
        }


        public void inviteUserToWallet(User newUser, Wallet wallet)
        {
            if (!newUser.Wallets.Contains(wallet))
                newUser.addWallet(wallet);

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


        //TODO: move later
        public Wallet getMyWalletByName(string name)
        {

            foreach (var wallet in Wallets)
            {
                if (wallet.Name == name)
                {
                    return wallet;
                }
            }
            return null;
        }


    }
}
