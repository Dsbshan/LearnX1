using CustomAuh.Entities;
using CustomAuh.Models;


namespace CustomAuh.Infrastructure.Data
{
    public interface IUserRepository
    {
        Task<IEnumerable<UserAccount>> GetAllUsers();
        Task RegisterUser(RegistrataionViewModel model);
        Task<UserAccount> AuthenticateUser(string usernameOrEmail, string password);


        public  Task<IEnumerable<UserAccount>> GetAllUsersAsync();
    }
}