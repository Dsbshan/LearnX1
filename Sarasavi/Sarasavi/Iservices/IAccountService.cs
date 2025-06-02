using Sarasavi.Models;

namespace Sarasavi.Iservices
{
    public interface IAccountService
    {
        Task<IEnumerable<UserAccount>> GetAllUsers();
        Task Register(RegistrataionViewModel model); // Fixed spelling
        Task<UserAccount> Login(LoginViewModel model);
      
    }
}
