using CustomAuh.Entities;
using CustomAuh.Models;


namespace CustomAuth.Services.Interfaces
{
    public interface IAccountService
    {
        Task<IEnumerable<UserAccount>> GetAllUsers();
        Task Register(RegistrataionViewModel model); // Fixed spelling
        Task<UserAccount> Login(LoginViewModel model);
    }
}