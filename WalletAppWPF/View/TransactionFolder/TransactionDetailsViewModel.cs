using System;
using System.Windows;
using Prism.Commands;
using Prism.Mvvm;
using WalletAppWPF.Models.Wallets;
using WalletAppWPF.Models.Transactions;

namespace WalletAppWPF.View.TransactionFolder
{
    public class TransactionDetailsViewModel : BindableBase
    {
        public Transaction _transaction;

        public string WalletFromName
        {
            get
            {
                return _transaction.FromWallet;
            }
            set
            {
                _transaction.FromWallet = value;
                RaisePropertyChanged(nameof(DisplayName));
            }
        }

        
        public int Sum
        {
            get
            {
                return _transaction.Value;
            }
            set
            {
                _transaction.Value = value;
                RaisePropertyChanged(nameof(DisplayName));
            }
        }

        public string Currency
        {
            get
            {
                return _transaction.Currency;
            }
            set
            {
                _transaction.Currency = value;
                RaisePropertyChanged(nameof(DisplayName));
            }
        }

        public string Category
        {
            get
            {
                return _transaction.Category;
            }
            set
            {
                _transaction.Category = value;
                RaisePropertyChanged(nameof(DisplayName));
            }
        }

        public string Description
        {
            get
            {
                return _transaction.Description;
            }
            set
            {
                _transaction.Description = value;
                RaisePropertyChanged(nameof(DisplayName));
            }
        }

        public Wallet Wallet
        {

            get
            {
                return _transaction.Wallet;
            }
            set
            {
                _transaction.Wallet = value;
                RaisePropertyChanged(nameof(DisplayName));
            }
        }

        public DateTime Date
        {
            get
            {
                return _transaction.Date;
            }
            set
            {
                _transaction.Date = value;
                RaisePropertyChanged(nameof(DisplayName));
            }
        }

        public string DisplayName
        {
            get
            {
                return $"Wallet: {Wallet.Name}\nCategory: {Category}\n{Sum} {Currency}\n{Description}\n{Date}";
            }
        }

        public DelegateCommand ChangeTransactionCommand { get; }

        public TransactionDetailsViewModel(Transaction transaction)
        {
            ChangeTransactionCommand = new DelegateCommand(ChangeTransaction);
            _transaction = transaction;
        }

        private void ChangeTransaction()
        {
            var creation = new TransactionCreationViewModel();

            try
            {
                creation.CreateTransaction(Wallet, Sum, Currency, Category,
            Description, WalletFromName);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Change failed: {ex.Message}");
                return;
            }
            MessageBox.Show($"User successfully changed transaction");
        }
    }
}
