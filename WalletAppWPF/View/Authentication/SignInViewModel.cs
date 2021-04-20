using System;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows;
using WalletAppWPF.Navigation;
using WalletAppWPF.Models.Users;
using WalletAppWPF.Services;
using Prism.Commands;

namespace WalletAppWPF.View
{
    public class SignInViewModel : INotifyPropertyChanged, INavigatable<NavigatableTypes>
    {
        private AuthorisationUser _authorisationUser = new AuthorisationUser();
        private Action _gotoSignUp;
        private Action _gotoWallets;
        private bool _isEnabled = true;

        public bool IsEnabled
        {
            get
            {
                return _isEnabled;
            }
            set
            {
                _isEnabled = value;
                OnPropertyChanged();
            }
        }

        public NavigatableTypes Type
        {
            get
            {
                return NavigatableTypes.SignIn;
            }
        }
        public string Login
        {
            get
            {
                return _authorisationUser.Login;
            }
            set
            {
                if (_authorisationUser.Login != value)
                {
                    _authorisationUser.Login = value;
                    OnPropertyChanged();
                    SignInCommand.RaiseCanExecuteChanged();
                }
            }
        }
        public string Password
        {
            get
            {
                return _authorisationUser.Password;
            }
            set
            {
                if (_authorisationUser.Password != value)
                {
                    _authorisationUser.Password = value;
                    OnPropertyChanged();
                    SignInCommand.RaiseCanExecuteChanged();
                }
            }
        }

        public DelegateCommand SignInCommand { get; }
        public DelegateCommand CloseCommand { get; }
        public DelegateCommand SignUpCommand { get; }

        public SignInViewModel(Action gotoSignUp, Action gotoWallets)
        {
            SignInCommand = new DelegateCommand(SignIn, IsSignInEnabled);
            CloseCommand = new DelegateCommand(() => Environment.Exit(0));
            _gotoSignUp = gotoSignUp;
            SignUpCommand = new DelegateCommand(_gotoSignUp);
            _gotoWallets = gotoWallets;
        }

        private async void SignIn()
        {
            if (String.IsNullOrWhiteSpace(Login) || String.IsNullOrWhiteSpace(Password))
                MessageBox.Show("Login or password is empty.");
            else
            {
                var authService = new AuthService();
                User user = null;
                try
                {
                    IsEnabled = false;
                    user = await authService.AuthenticateAsync(_authorisationUser);
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Sign In failed: {ex.Message}");
                    return;
                }
                finally
                {
                    IsEnabled = true;
                }
                MessageBox.Show($"Sign In was successful for user {user.FirstName} {user.LastName}");
                _gotoWallets.Invoke();
            }
        }

        private bool IsSignInEnabled()
        {
            return !String.IsNullOrWhiteSpace(Login) && !String.IsNullOrWhiteSpace(Password);
        }

        public void ClearSensitiveData()
        {
            Password = "";
        }


        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        
    }
}
