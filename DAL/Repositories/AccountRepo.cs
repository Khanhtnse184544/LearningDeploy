using DAL.Models;

namespace DAL.Repositories
{
    public class AccountRepo
    {
        private readonly DBContext _dbContext;

        public AccountRepo(DBContext dBContext)
        {
            _dbContext = dBContext;
        }

        public string GetCustomer(string username, string password)
        {
            if (_dbContext.Customers.FirstOrDefault(u => u.UserName == username && u.Password == password) != null)
            {
                return "Dang nhap thanh cong";
            }
            return "Dang nhap that bai";
        }
    }
}
