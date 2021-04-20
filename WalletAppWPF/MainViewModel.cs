using WalletAppWPF.View;
using WalletAppWPF.Navigation;
using WalletAppWPF.View.TransactionFolder;
using WalletAppWPF.View.WalletFolder;

namespace WalletAppWPF
{
    public class MainViewModel : NavigationBase<NavigatableTypes>
    {
        public MainViewModel()
        {
            Navigate(NavigatableTypes.Authorization);
        }
        
        protected override INavigatable<NavigatableTypes> CreateViewModel(NavigatableTypes type)
        {
            if (type == NavigatableTypes.Authorization)
            {
                return new AuthViewModel(() => Navigate(NavigatableTypes.Wallets));
            }
            else if (type == NavigatableTypes.Wallets)
            {
                return new WalletsViewModel(() => Navigate(NavigatableTypes.CreateWallet), () => Navigate(NavigatableTypes.DeleteWallet), () => Navigate(NavigatableTypes.Transactions));
            }
            else if(type == NavigatableTypes.CreateWallet)
            {
                return new WalletCreationViewModel(() => Navigate(NavigatableTypes.Wallets));
            }
            else if (type == NavigatableTypes.Transactions)
            {
                return new TransactionsViewModel(() => Navigate(NavigatableTypes.CreateTransaction),  () => Navigate(NavigatableTypes.Wallets));
            }
            else 
            {
                return new TransactionCreationViewModel(() => Navigate(NavigatableTypes.Transactions));
            }

        }
    }
}