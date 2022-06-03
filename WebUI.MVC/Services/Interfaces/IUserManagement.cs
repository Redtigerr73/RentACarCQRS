using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using WebUI.MVC.Models;

namespace WebUI.MVC.Services.Interfaces
{
    public interface IUserManagement 
    {
        Task CreateUser(User user);
        Task<TokenData> GetToken();

        Task<List<User>> GetAllUsers(CancellationToken cancellationToken = default);
    }
}
