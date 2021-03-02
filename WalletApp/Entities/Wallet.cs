using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Text;

namespace WalletApp
{
    public class Wallet
    {
        private string _name;
        private string _currency;
        private string _description;
        private int _start_value; //how much money we put in the wallet when we create it
        private List<Category> _categories; //the categories we can use in this wallet
        private int _current_value;
        private List<Transaction> _transactions;


        //constructors
        /*public Wallet()
        {
            _name = "My wallet";
            _currency = "UAH";
            _description = "default wallet";
            _start_value = 0;
            _categories = new List<Category>();
            _transactions = new List<Transaction>();
        }

        public Wallet(string name)
        {
            _name = name;
            _currency = "UAH";
            _description = "default wallet";
            _start_value = 0;
            _categories = new List<Category>();
            _transactions = new List<Transaction>();
        }*/

        public Wallet(string name, string currency, string description, int start_value)
        {
            _name = name;
            _currency = currency;
            _description = description;
            _start_value = start_value;
            _categories = new List<Category>();
            _transactions = new List<Transaction>();
            _current_value = start_value;
        }

        //methods working with the wallet

        public void add_transaction(Transaction transaction)
        {
            _transactions.Add(transaction);
            _current_value += transaction.Value;
        }

        public void add_category(Category category)
        {
            if (!_categories.Contains(category))
            _categories.Add(category);
        }

        public void remove_category(Category category) //?? the method depends on UI logic, might be changed later
        {
            _categories.Remove(category);
        }

        public void remove_transaction(Transaction transaction) //?? the method depends on UI logic, might be changed later
        {
            _transactions.Remove(transaction);
            _current_value -= transaction.Value;
        }

        public void edit_transaction_value(int i, int value)
        {
            _current_value -= _transactions[i].Value;
            _transactions[i].edit_value(value);
            _current_value += _transactions[i].Value;
        }

        public void edit_transaction_currency(int i, string currency)
        {
            _transactions[i].edit_currency(currency);
            //add code for changing value properly
        }

        public void edit_transaction_category(int i, Category category)
        {
            if(_categories.Contains(category))  //the transaction can have only a category from the wallet categories
            _transactions[i].edit_category(category);
        }

        public void edit_transaction_description(int i, string description)
        {
             _transactions[i].edit_description(description);
        }

        public void edit_date(int i, string date)
        {
            _transactions[i].edit_date(date);
        }

        //getters & setters
        public string Name
        {
            get { return _name; }
            private set { _name = value; }
        }

        public string Currency
        {
            get { return _currency; }
            private set { _currency = value; }
        }

        public string Description
        {
            get { return _description; }
            private set { _description = value; }
        }

        public int StartValue
        {
            get { return _start_value; }
            private set { _start_value = value; }
        }

        public List<Category> Categories
        {
            get { return _categories; }
            private set { _categories = value; }
        }


    }
}
