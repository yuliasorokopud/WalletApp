using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace WalletApp
{
    public class Transaction
    {
        private double _value;
        private Currencies _currency;
        private Category _category;
        private string _description;
        private DateTime _date;
        private string _file_path;

        //constructors
        public Transaction()
        {
            _value = 1;
            _currency = Currencies.UAH;
            Category = new Category();
            _description = "Default transaction";
            _date = DateTime.Now;
        }

        public Transaction(double value, Currencies currency, Category category, string description = "Default transaction")
        {
            _value = value;
            _currency = currency;
            Category = category;
            _description = description;
            _date = DateTime.Now;
        }

        public Transaction(double value, Currencies currency, Category category, DateTime date, string description = "Default transaction")
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
            //TODO: ... add later what needs to be done for adding file
        }

        public void edit_value(double value)
        {
            this.Value = value;
        }

        public void edit_currency(Currencies currency)
        {
            edit_value(convertValue(currency));
            this.Currency = currency;
            
            //TODO: add code for changing value properly
        }

        public void edit_category(Category category)
        {
            this.Category = category;
        }

        public void edit_description(string description)
        {
            this.Description = description;
        }

        public void edit_date(DateTime date)
        {
            this.Date = date;
        }

        public double convertValue(Currencies toCurrency)
        {
            switch(this.Currency){
                case Currencies.UAH:
                    switch (toCurrency)
                    {
                        case Currencies.USD: return Math.Round(Value / 28, 2);
                        case Currencies.EURO: return Math.Round(Value / 32, 2);
                        default:
                            Console.WriteLine("Default case1");
                            break;
                    }
                    break;
                case Currencies.USD:
                    switch (toCurrency)
                    {
                        case Currencies.UAH: return Math.Round(Value * 28,2);
                        case Currencies.EURO: return Math.Round(Value * 0.842);
                        default:
                            Console.WriteLine("Default case2");
                            break;
                    }
                    break;
                case Currencies.EURO:
                    switch (toCurrency)
                    {
                        case Currencies.USD: return Math.Round(Value * 1.19, 2);
                        case Currencies.UAH: return Math.Round(Value * 32,2);
                        default:
                            Console.WriteLine("Default case3");
                            break;
                    }
                    break;
                default:
                    Console.WriteLine("Default case4");
                    break;
            }
            Console.WriteLine("No match");
            return 0;
        }


        //getters & setters
        public double Value
        {
            get { return _value; }
            private set { _value = value; }
        }

        public Currencies Currency
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


        public DateTime Date
        {
            get { return _date; }
            private set { _date = value; }
        }
    }

    public enum Currencies
    {
        UAH = 1,
        USD = 2,
        EURO = 3
    }
}
