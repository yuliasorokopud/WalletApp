using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace WalletApp
{
    public class Transaction
    {
        private int _value;
        private string _currency;
        private Category _category;
        private string _description;
        private string _date; // variable type may be changed later
        private string _file_path;

        //constructors
        public Transaction()
        {
            _value = 1;
            _currency = "UAH";
            Category = new Category();
            _description = "Default transaction";
            _date = "28.02.2021";
        }

        public Transaction(int value, string currency, Category category, string description, string date)
        {
            _value = value;
            _currency = currency;
            Category = category;
            _description = description;
            _date = date;
        }

        //methods working with the transaction
        public void add_file(string file_path)
        {
            _file_path = file_path;
            //... add later what needs to be done for adding file
        }

        public void edit_value(int value)
        {
            this.Value = value;
        }

        public void edit_currency(string currency)
        {
            this.Currency = currency;
            //add code for changing value properly
        }

        public void edit_category(Category category)
        {
            this.Category = category;
        }

        public void edit_description(string description)
        {
            this.Description = description;
        }

        public void edit_date(string date)
        {
            this.Date = date;
        }

        //getters & setters
        public int Value
        {
            get { return _value; }
            private set { _value = value; }
        }

        public string Currency
        {
            get { return _currency; }
            private set { _currency = value; }
        }

        public Category Category
        {
            get { return _category; }
            private set { _category = value; }
        }


        public string Description
        {
            get { return _description; }
            private set { _description = value; }
        }


        public string Date
        {
            get { return _date; }
            private set { _date = value; }
        }
    }
}
