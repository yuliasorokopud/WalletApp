using System;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows;
using Prism.Commands;
using WalletAppWPF.Navigation;
using WalletAppWPF.Services;

namespace WalletAppWPF.View.WalletFolder
{
    class WalletCreationViewModel : INotifyPropertyChanged, INavigatable<NavigatableTypes>
    {
        private Action _gotoWallets;
        private Models.Wallets.Wallet _wallet = new Models.Wallets.Wallet();

        public NavigatableTypes Type
        {
            get
            {
                return NavigatableTypes.CreateWallet;
            }
        }

        public Guid Guid
        {
            get
            {
                return _wallet.Guid;
            }
            set
            {
                if (_wallet.Guid != value)
                {
                    _wallet.Guid = value;
                    OnPropertyChanged();
                    ReturnToWallets.RaiseCanExecuteChanged();
                }
            }
        }

        public string Name
        {
            get
            {
                return _wallet.Name;
            }
            set
            {
                if (_wallet.Name != value)
                {
                    _wallet.Name = value;
                    OnPropertyChanged();
                    ReturnToWallets.RaiseCanExecuteChanged();
                }
            }
        }

        public int Balance
        {
            get
            {
                return _wallet.Balance;
            }
            set
            {
                if (_wallet.Balance != value)
                {
                    _wallet.Balance = value;
                    OnPropertyChanged();
                    ReturnToWallets.RaiseCanExecuteChanged();
                }
            }
        }

        public string Description
        {
            get
            {
                return _wallet.Description;
            }
            set
            {
                if (_wallet.Description != value)
                {
                    _wallet.Description = value;
                    OnPropertyChanged();
                    ReturnToWallets.RaiseCanExecuteChanged();
                }
            }
        }

        public string Currency
        {
            get
            {
                return _wallet.Currency;
            }
            set
            {
                if (_wallet.Currency != value)
                {
                    _wallet.Currency = value;
                    OnPropertyChanged();
                    ReturnToWallets.RaiseCanExecuteChanged();
                }
            }
        }

        public int Earned
        {
            get
            {
                return _wallet.Income;
            }
            set
            {
                if (_wallet.Income != value)
                {
                    _wallet.Income = value;
                    OnPropertyChanged();
                    ReturnToWallets.RaiseCanExecuteChanged();
                }
            }
        } 
        public int Spent
        {
            get
            {
                return _wallet.Outcome;
            }
            set
            {
                if (_wallet.Outcome != value)
                {
                    _wallet.Outcome = value;
                    OnPropertyChanged();
                    ReturnToWallets.RaiseCanExecuteChanged();
                }
            }
        }

        public DelegateCommand ReturnToWallets { get; }
        public DelegateCommand CreateWalletCommand { get; }

        public WalletCreationViewModel(Action gotoWallets)
        {
            CreateWalletCommand = new DelegateCommand(CreateWallet);
            _gotoWallets = gotoWallets;
            ReturnToWallets = new DelegateCommand(_gotoWallets);
        }

        public WalletCreationViewModel()
        {
        }

        public async void CreateWallet()
        {
            var walletService = new WalletService();

            try
            {
                await walletService.CreateWallet(_wallet);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Creation is failed: {ex.Message}");
                return;
            }
            MessageBox.Show($"User successfully created a wallet {Name}");
            _gotoWallets.Invoke();
        }

        public async void CreateWallet(string name, int balance, string description,
            string currency, int earned, int spent)
        {
            var walletService = new WalletService();

            try
            {
                Models.Wallets.Wallet w = new Models.Wallets.Wallet(name, balance, description, currency, earned, spent);
                await walletService.CreateWallet(w);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Failed: {ex.Message}");
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
