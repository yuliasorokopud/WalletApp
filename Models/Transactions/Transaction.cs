using WalletAppWPF.Models.Wallets;
using DataStorage;
using System;

namespace WalletAppWPF.Models.Transactions
{
    public class Transaction : IStorable
    {
        public Guid Guid { get; set; }
        public int Value { get; set; }
        public string Currency { get; set; }
        public string Category { get; set; }
        public string Description { get; set; }
        public string FromWallet { get; set; }
        public DateTime Date { get; set; }
        public Wallet Wallet { get; set; }

        public Transaction(Wallet wallet, int value, string currency, string category,
            string description, string fromWallet /*string toWallet*/)
        {
            Guid = Guid.NewGuid();
            Wallet = wallet;
            Value = value;
            Currency = currency;
            Category = category;
            Description = description;
            FromWallet = fromWallet;
            Date = DateTime.Now;
        }

        public Transaction()
        {

        }

        public override string ToString()
        {
            return $"Wallet: {FromWallet}\n Category: {Category}\n{Value} {Currency}\n{Description}\n{Date}";
        }
    }
}
