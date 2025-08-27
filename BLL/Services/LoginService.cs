using DAL.Repositories;

namespace BLL.Services
{
    public class LoginService
    {
        private readonly AccountRepo _accountRepo;

        public LoginService(AccountRepo accountRepo)
        {
            _accountRepo = accountRepo;
        }

        public string LoginWithUserNamePassword(string username, string password)
        {
            return _accountRepo.GetCustomer(username, password);
        }
    }
}
