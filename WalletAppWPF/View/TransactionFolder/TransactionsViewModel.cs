using System;
using System.Collections.ObjectModel;
using System.Windows;
using Prism.Commands;
using Prism.Mvvm;
using WalletAppWPF.Navigation;
using WalletAppWPF.Services;

namespace WalletAppWPF.View.TransactionFolder
{
    public class TransactionsViewModel : BindableBase, INavigatable<NavigatableTypes> 
    {
        private TransactionService _service;
        private TransactionDetailsViewModel _currentTransaction;
        private Action _gotoCreateTransaction;
        private Action _gotoDeleteTransaction;
        private Action _gotoWallets;
        public ObservableCollection<TransactionDetailsViewModel> Transactions { get; set; }

        public NavigatableTypes Type
        {
            get
            {
                return NavigatableTypes.Transactions;
            }
        }

        public TransactionDetailsViewModel CurrentTransaction
        {
            get
            {
                return _currentTransaction;
            }
            set
            {
                _currentTransaction = value;
                RaisePropertyChanged();
            }
        }

        public DelegateCommand CreateTransactionCommand { get; }
        public DelegateCommand DeleteTransactionCommand { get; }
        public DelegateCommand UpdateTransactionCommand { get; }
        public DelegateCommand ReturnToWalletsCommand { get; }

        public TransactionsViewModel(Action gotoCreation,  Action gotoWallets)
        {
            _service = new TransactionService();
            _service.UpdateTransactionStorage();
            Transactions = new ObservableCollection<TransactionDetailsViewModel>();
            foreach (var transaction in _service.GetTransactions())
            {
                Transactions.Add(new TransactionDetailsViewModel(transaction));
            }
            UpdateTransactionCommand = new DelegateCommand(UpdateTransactions);
            _gotoCreateTransaction = gotoCreation;
            CreateTransactionCommand = new DelegateCommand(_gotoCreateTransaction);
            DeleteTransactionCommand = new DelegateCommand(DeleteTransaction);
            _gotoWallets = gotoWallets;
            ReturnToWalletsCommand = new DelegateCommand(_gotoWallets);
        }

        public void UpdateTransactions()
        {
            try
            {
                _service = new TransactionService();
                _service.UpdateTransactionStorage();
                Transactions.Clear();
                foreach (var transaction in _service.GetTransactions())
                {
                    Transactions.Add(new TransactionDetailsViewModel(transaction));
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Update failed: {ex.Message}");
                return;
            }
        }

        public void DeleteTransaction()
        {
            try
            {
                _service = new TransactionService();
                _service.UpdateTransactionStorage();
                _service.DeleteTransaction(CurrentTransaction._transaction);
                Transactions.Remove(CurrentTransaction);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Delition is failed: {ex.Message}");
                return;
            }
        }



        public void ClearSensitiveData()
        {

        }
    }
}