using WalletAppWPF.Models.Transactions;
using DataStorage;
using System;
using System.Collections.Generic;

namespace WalletAppWPF.Models.Wallets
{
    public class Wallet : IStorable
    {
        public Guid Guid { get; set; }
        public string Name { get; set; }
        public int Balance { get; set; }
        public string Description { get; set; }
        public string Currency { get; set; }
        public int Income { get; set; }
        public int Outcome { get; set; }
        public List<Transaction> Transactions { get; set; }

        public Wallet(string name, int balance, string description, string currency, int income, int outcome)
        {
            Guid = Guid.NewGuid();
            Name = name;
            Balance = balance;
            Description = description;
            Currency = currency;
            Income = income;
            Outcome = outcome; 
            Transactions = new List<Transaction>();
        }

        public Wallet()
        {
        }

        public override string ToString()
        {
            return $"{Name} Balance: {Balance} {Currency}\n{Description}";
        }
    }
}
