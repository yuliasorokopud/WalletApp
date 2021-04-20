using System;
using WalletAppWPF.Navigation;

namespace WalletAppWPF.View
{
    public class AuthViewModel : NavigationBase<NavigatableTypes>, INavigatable<NavigatableTypes>
    {
        private Action _signInSuccess;
        
        public AuthViewModel(Action signInSuccess)
        {
            _signInSuccess = signInSuccess;
            Navigate(NavigatableTypes.SignIn);
        }
        
        protected override INavigatable<NavigatableTypes> CreateViewModel(NavigatableTypes type)
        {
            if (type == NavigatableTypes.SignIn)
            {
                return new SignInViewModel(() => Navigate(NavigatableTypes.SignUp), _signInSuccess);
            }
            else
            {
                return new SignUpViewModel(() => Navigate(NavigatableTypes.SignIn));
            }
        }

        public NavigatableTypes Type
        {
            get
            {
                return NavigatableTypes.Authorization;
            }
        }

        public void ClearSensitiveData()
        {
            CurrentViewModel.ClearSensitiveData();
        }
    }
}
