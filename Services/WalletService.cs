using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using WalletAppWPF.Models.Wallets;
using DataStorage;

namespace WalletAppWPF.Services
{
    public class WalletService
    {
        private FileDataStorage<Wallet> _storage = new FileDataStorage<Wallet>();

        public List<Wallet> Wallets = new List<Wallet>();

        public async Task<bool> CreateWallet(Wallet newWallet)
        {
            Thread.Sleep(2000);
            var wallets = await _storage.GetAllAsync();
            var myWallet = wallets.FirstOrDefault(wallet => wallet.Name == newWallet.Name);
            if (myWallet != null)
                throw new Exception("Wallet already exists");
            /*if (String.IsNullOrWhiteSpace(newWallet.Name)
                || String.IsNullOrWhiteSpace(newWallet.Description)
                || String.IsNullOrWhiteSpace(newWallet.Currency))
                throw new ArgumentException("Some lines are empty");*/
            myWallet = new Wallet(newWallet.Name, newWallet.Balance, newWallet.Description,
                newWallet.Currency, newWallet.Income, newWallet.Outcome);
            await _storage.AddOrUpdateAsync(myWallet);
            return true;
        }
        
        public async Task<bool> UpdateWallet( string Name, int Balance, string Description, string Currency, int Income, int Outcome)
        {
            Thread.Sleep(2000);
            var wallets = await _storage.GetAllAsync();
            var myWallet = wallets.FirstOrDefault(wallet => wallet.Name == Name);
            if (myWallet != null)
            {
                /*if (String.IsNullOrWhiteSpace(Name)
                    || String.IsNullOrWhiteSpace(Description)
                    || String.IsNullOrWhiteSpace(Currency))
                    throw new ArgumentException("Some lines are empty");*/
                myWallet.Name = Name;
                myWallet.Balance = Balance;
                myWallet.Description = Description;
                myWallet.Currency = Currency;
                myWallet.Income = Income;
                myWallet.Outcome = Outcome;
            }
            else
            {
                throw new Exception("No such wallet");
            }

            await _storage.AddOrUpdateAsync(myWallet);
            return true;
        }

        public void DeleteWallet(Wallet delWallet)
        {
            Thread.Sleep(2000);
            if (String.IsNullOrWhiteSpace(delWallet.Name))
                throw new ArgumentException("Enter name please");
            var wallets = _storage.GetAll();
            var myWallet = wallets.FirstOrDefault(wallet => wallet.Name == delWallet.Name);
            if (myWallet == null)
                throw new Exception("Wallet does not exist");
            _storage.DeleteObj(delWallet);
        }

        public Guid GetWalletGuid(string name)
        {
            var wallets = _storage.GetAll();
            var myWallet = wallets.FirstOrDefault(wallet => wallet.Name == name);
            if (myWallet == null)
                throw new Exception("Wallet does not exist");
            return myWallet.Guid;
        }

        public void UpdateWalletsStorage()
        {
            var wallets = _storage.GetAll();
            foreach (var wallet in wallets)
            {
                Wallets.Add(wallet);
            }
        }

        public List<Wallet> GetWallets()
        {
            return Wallets.ToList();
        }
    }
}
