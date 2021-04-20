using DataStorage;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using WalletAppWPF.Models.Transactions;

namespace WalletAppWPF.Services
{
    public class TransactionService
    {

        private FileDataStorage<Transaction> _storage = new FileDataStorage<Transaction>();

        public List<Transaction> Transactions = new List<Transaction>();

        public async Task<bool> CreateTransaction(Transaction newTransaction)
        {
            Thread.Sleep(2000);
            /*if (String.IsNullOrWhiteSpace(newTransaction.Currency)
                || String.IsNullOrWhiteSpace(newTransaction.Category)
                || String.IsNullOrWhiteSpace(newTransaction.Description))
                throw new ArgumentException("Some lines are empty");*/
            var myTransaction = new Transaction(newTransaction.Wallet, newTransaction.Value,
                newTransaction.Currency, newTransaction.Category,
                newTransaction.Description, newTransaction.FromWallet);
            await _storage.AddOrUpdateAsync(myTransaction);
            return true;
        }

        public void DeleteTransaction(Transaction delTransaction)
        {
            Thread.Sleep(2000);
           
            var transactions = _storage.GetAll();
            var myTransaction = transactions.FirstOrDefault(transaction => 
                transaction.FromWallet == delTransaction.FromWallet
                && transaction.Value == delTransaction.Value);
            if (myTransaction == null)
                throw new Exception("Transaction does not exist");
            _storage.DeleteObj(delTransaction);
        }

        public void UpdateTransactionStorage()
        {
            var transactions = _storage.GetAll();
            foreach (var transaction in transactions)
            {
                Transactions.Add(transaction);
            }
        }

        public List<Transaction> GetTransactions()
        {
            return Transactions.ToList();
        }
    }
}
