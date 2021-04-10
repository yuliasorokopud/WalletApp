using AV.ProgrammingWithCSharp.Budgets.GUI.WPF.Authentication;
using AV.ProgrammingWithCSharp.Budgets.GUI.WPF.Navigation;
using AV.ProgrammingWithCSharp.Budgets.GUI.WPF.Wallets;

namespace AV.ProgrammingWithCSharp.Budgets.GUI.WPF
{
    public class MainViewModel : NavigationBase<MainNavigatableTypes>
    {
        public MainViewModel()
        {
            Navigate(MainNavigatableTypes.Auth);
        }
        
        protected override INavigatable<MainNavigatableTypes> CreateViewModel(MainNavigatableTypes type)
        {
            if (type == MainNavigatableTypes.Auth)
            {
                return new AuthViewModel(() => Navigate(MainNavigatableTypes.Wallets));
            }
            else
            {
                return new WalletsViewModel();
            }
        }
    }
}
