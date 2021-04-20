using System;
using System.Windows;
using Prism.Commands;
using Prism.Mvvm;
using WalletAppWPF.Models.Wallets;

namespace WalletAppWPF.View.WalletFolder
{
    public class WalletDetailsViewModel : BindableBase
    {
        public Wallet _wallet;

        public string Name
        {
            get
            {
                return _wallet.Name;
            }
            set
            {
                _wallet.Name = value;
                RaisePropertyChanged(nameof(DisplayName));
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
                _wallet.Balance = value;
                RaisePropertyChanged(nameof(DisplayName));
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
                _wallet.Currency = value;
                RaisePropertyChanged(nameof(DisplayName));
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
                _wallet.Description = value;
                RaisePropertyChanged(nameof(DisplayName));
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
                    RaisePropertyChanged(nameof(DisplayName));
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
                    RaisePropertyChanged(nameof(DisplayName));
                }
            }
        }

        public string DisplayName
        {
            get
            {
                return $"{Name}\nBalance: {Balance} {Currency}\n" +
                    $"Month earnings: {Earned}\nMonth expenditure: {Spent}\n{Description}";
            }
        }

        public DelegateCommand ChangeWalletCommand { get; }

        public WalletDetailsViewModel(Wallet wallet)
        {
            ChangeWalletCommand = new DelegateCommand(ChangeWallet);
            _wallet = wallet;
        }

        public void ChangeWallet()
        {
            var creation = new WalletCreationViewModel();

            try
            {
                creation.CreateWallet(Name, Balance, Description, Currency, Earned, Spent);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Change failed: {ex.Message}");
                return;
            }
            MessageBox.Show($"User successfully changed wallet {Name}");
        }
    }
}
