using System;
using System.Collections.ObjectModel;
using System.Windows;
using Prism.Commands;
using Prism.Mvvm;
using WalletAppWPF.Navigation;
using WalletAppWPF.Services;
using WalletAppWPF.Models.Wallets;

namespace WalletAppWPF.View.WalletFolder
{
    public class WalletsViewModel : BindableBase, INavigatable<NavigatableTypes>
    {
        private WalletService _service;
        private WalletDetailsViewModel _currentWallet;
        private Action _gotoCreateWallet;
        private Action _gotoDeleteWallet;
        private Action _gotoTransactions;
        public ObservableCollection<WalletDetailsViewModel> Wallets { get; set; }

        public WalletDetailsViewModel CurrentWallet
        {
            get
            {
                return _currentWallet;
            }
            set
            {
                _currentWallet = value;
                RaisePropertyChanged();
            }
        }

        public DelegateCommand CreateWalletCommand { get; }
        public DelegateCommand DeleteWalletCommand { get; }
        public DelegateCommand UpdateWalletsCommand { get; }
        public DelegateCommand TransactionsCommand { get; }
        

        public WalletsViewModel(Action gotoCreation, Action gotoDelition, Action gotoTransactions)
        {
            _service = new WalletService();
            _service.UpdateWalletsStorage();
            Wallets = new ObservableCollection<WalletDetailsViewModel>();
            foreach (var wallet in _service.GetWallets())
            {
                Wallets.Add(new WalletDetailsViewModel(wallet));
            }
            UpdateWalletsCommand = new DelegateCommand(UpdateWallets);
            _gotoCreateWallet = gotoCreation;
            CreateWalletCommand = new DelegateCommand(_gotoCreateWallet);
            
            DeleteWalletCommand = new DelegateCommand(DeleteWallet);


            _gotoTransactions = gotoTransactions;
            TransactionsCommand = new DelegateCommand(_gotoTransactions);
        }

        public void UpdateWallets()
        {
            try
            {
                _service = new WalletService();
                _service.UpdateWalletsStorage();
                Wallets.Clear();
                foreach (var wallet in _service.GetWallets())
                {
                    Wallets.Add(new WalletDetailsViewModel(wallet));
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Update failed: {ex.Message}");
                return;
            }
        }

        public void DeleteWallet()
        {
            try
            {
                _service = new WalletService();
                Wallet delWallet = _currentWallet._wallet;
                _service.DeleteWallet(_currentWallet._wallet);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Delition is failed: {ex.Message}");
                return;
            }
        }



        public NavigatableTypes Type
        {
            get
            {
                return NavigatableTypes.Wallets;
            }
        }

        public void ClearSensitiveData()
        {

        }
    }
}