using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Text;

namespace WalletApp
{
    public class Wallet
    {
        private string _name;
        private Currencies _currency;
        private string _description;
        private double _start_value;           //how much money we put in the wallet when we create it
        private List<Category> _categories; //the categories we can use in this wallet
        private double _current_value;
        private List<Transaction> _transactions;


        //contructor

        public Wallet(string name, Currencies currency, int start_value, string description = "default wallet")
        {
            _name = name;
            _currency = currency;
            _description = description;
            _start_value = start_value;
            _categories = new List<Category>() { new Category()};
            _transactions = new List<Transaction>();
            _current_value = start_value;
        }

        //methods working with the wallet

        public void add_transaction(Transaction transaction)
        {
            if (Categories.Contains(transaction.Category))
            {
                addTransaction(transaction);
            }
           ;
        }

        public void add_transaction(int value, Category category)
        {
            if (Categories.Contains(category))
            {
                Transaction transaction = new Transaction(value, this.WCurrency, category);
                addTransaction(transaction);
            }
        }

        public void add_transaction(int value, Currencies currency, Category category, string description = "Default transaction")
        {
            if (Categories.Contains(category))
            {
                Transaction transaction = new Transaction(value, currency, category, DateTime.Now, description);
                addTransaction(transaction);
            }
        }

        public void add_transaction(int value, Currencies currency, Category category, DateTime date, string description = "Default transaction")
        {
            if (Categories.Contains(category))
            {
                Transaction transaction = new Transaction(value, currency, category, date, description);
                _transactions.Add(transaction);
                addTransaction(transaction);
            }
        }

     
        public void add_category(Category category)
        {
            if (!Categories.Contains(category))
            _categories.Add(category);
        }
        

        //helper
        private void addTransaction(Transaction transaction)
        {
            _transactions.Add(transaction);
            if (transaction.Currency != this.WCurrency)
            {
                var newValue = transaction.convertValue(this.WCurrency);
                _current_value += newValue;
            }
            else
            {
                _current_value += transaction.Value;
            }
        }


        //TODO: the method depends on UI logic, might be changed later
        public void remove_category(Category category) 
        {
            if (_categories.Contains(category))
                foreach(var trans in Transactions)
                {
                    if (trans.Category == category)
                    {
                        trans.edit_category(Categories[0]);
                    }
                }
               _categories.Remove(category);
        }

        //TODO: the method depends on UI logic, might be changed later
        public void remove_transaction(Transaction transaction) 
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

        
        public void edit_transaction_currency(int i, Currencies currency)
        {
            _transactions[i].edit_currency(currency);
        }

        public void edit_transaction_category(int i, Category category)
        {
            if(_categories.Contains(category))
               _transactions[i].edit_category(category);
        }

        public void edit_transaction_description(int i, string description)
        {
            _transactions[i].edit_description(description);
        }

        public void edit_transaction_date(int i, DateTime date)
        {
             _transactions[i].edit_date(date);
        }

        // getters & setters
        public string Name
        {
            get { return _name; }
            private set { _name = value; }
        }

        public Currencies WCurrency
        {
            get { return _currency; }
            private set { _currency = value; }
        }

        public string Description
        {
            get { return _description; }
            private set { _description = value; }
        }

        public double StartValue
        {
            get { return _start_value; }
            private set { _start_value = value; }
        }

        public double CurrentValue
        {
            get { return _current_value; }
            private set { _current_value = value; }
        }

        public List<Category> Categories
        {
            get { return _categories; }
            private set { _categories = value; }
        }

        public List<Transaction> Transactions
        {
            get { return _transactions; }
            private set { _transactions = value; }
        }

        }
}
