using System;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows;
using DataStorage;
using Prism.Commands;
using WalletAppWPF.Models.Wallets;
using WalletAppWPF.Models.Transactions;
using WalletAppWPF.Navigation;
using WalletAppWPF.Services;

namespace WalletAppWPF.View.TransactionFolder
{
    public class TransactionCreationViewModel : INotifyPropertyChanged, INavigatable<NavigatableTypes>
    {
        private Action _gotoTransactions;
        private Transaction _transaction = new Transaction();

        public NavigatableTypes Type
        {
            get
            {
                return NavigatableTypes.CreateTransaction;
            }
        }

       

        public string WalletFromName
        {
            get
            {
                return _transaction.FromWallet;
            }
            set
            {
                _transaction.FromWallet = value;
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
                _transaction.Wallet = new Wallet();
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
            }
        }

        public DelegateCommand ReturnToTransactions { get; }
        public DelegateCommand CreateTransactionCommand { get; }

        public TransactionCreationViewModel(Action gotoTransactions)
        {
            CreateTransactionCommand = new DelegateCommand(CreateTransaction);
            _gotoTransactions = gotoTransactions;
            ReturnToTransactions = new DelegateCommand(_gotoTransactions);
        }

        public TransactionCreationViewModel()
        {
        }
        

        public async void CreateTransaction()
        {
            var transactionService = new TransactionService();

            try
            {
                FileDataStorage<Wallet> _storage = new FileDataStorage<Wallet>();
                var walletService = new WalletService();
                var walletFrom = _storage.Get(walletService.GetWalletGuid(WalletFromName));

                _transaction.Wallet = walletFrom; //WalletFromGetter();
                await transactionService.CreateTransaction(_transaction);
                Trans(_transaction.Value, walletFrom);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Creation is failed: {ex.Message}");
                return;
            }
            MessageBox.Show($"User successfully created a transaction");
            _gotoTransactions.Invoke();
        }

        public async void CreateTransaction(Wallet wallet, int sum, string currency, string category,
            string description, string walletFromName)
        {
            var transactionService = new TransactionService();

            try
            {
                Transaction t = new Transaction(wallet, sum, currency, category,
            description, walletFromName);
                await transactionService.CreateTransaction(t);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Failed: {ex.Message}");
                return;
            }
        }

        public void Trans(int sum, Wallet wallet)
        {

            var walletService = new WalletService();

            try
            {
                var walletFrom = wallet;
                
                    if (walletFrom.Balance - sum > 0)
                    {
                        walletService.UpdateWallet(walletFrom.Name, walletFrom.Balance + sum, walletFrom.Description, walletFrom.Currency, walletFrom.Income, walletFrom.Outcome + sum);
                    }
                    else
                    {
                        MessageBox.Show($"Not enough money");
                    }
                
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Transaction failed: {ex.Message}");
                return;
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        public void ClearSensitiveData()
        {

        }
    }
}
