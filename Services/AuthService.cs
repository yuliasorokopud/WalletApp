using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using WalletAppWPF.Models.Users;
using DataStorage;

namespace WalletAppWPF.Services
{
    public class AuthService
    {
        private FileDataStorage<DBUser> _storage = new FileDataStorage<DBUser>();

        public async Task<User> AuthenticateAsync(AuthorisationUser authorisationUser)
        {
            if (String.IsNullOrWhiteSpace(authorisationUser.Login) || String.IsNullOrWhiteSpace(authorisationUser.Password))
                throw new ArgumentException("Login or Password is Empty");
            var users = await _storage.GetAllAsync();
            var dbUser = users.FirstOrDefault(user => user.Login == authorisationUser.Login && user.Password == authorisationUser.Password);
            if (dbUser == null)
                throw new Exception("Wrong Login or Password");
            return new User(dbUser.Guid, dbUser.FirstName, dbUser.LastName, dbUser.Email, dbUser.Login);
        }

        public async Task<bool> RegisterUserAsync(RegistrationUser regUser)
        {
            Thread.Sleep(2000);
            var users = await _storage.GetAllAsync();
            var dbUser = users.FirstOrDefault(user => user.Login == regUser.Login);
            if (dbUser != null)
                throw new Exception("User already exists");
            if (String.IsNullOrWhiteSpace(regUser.Login)
                || String.IsNullOrWhiteSpace(regUser.Password)
                || String.IsNullOrWhiteSpace(regUser.LastName)
                || String.IsNullOrWhiteSpace(regUser.FirstName)
                || String.IsNullOrWhiteSpace(regUser.Email))
                throw new ArgumentException("Login, Password or Last Name is Empty");
            dbUser = new DBUser(regUser.FirstName, regUser.LastName, regUser.Email,
                regUser.Login, regUser.Password);
            await _storage.AddOrUpdateAsync(dbUser);
            return true;
        }
    }
}
