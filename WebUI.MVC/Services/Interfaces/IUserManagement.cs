using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using WebUI.MVC.Models;

namespace WebUI.MVC.Services.Interfaces
{
    public interface IUserManagement 
    {
        Task<Auth0Entity> CreateUser(User user);
        Task<TokenData> GetToken();
        Task DeleteById(string id, CancellationToken cancellationToken = default);
        Task<List<UserVm>> GetAllUsers(CancellationToken cancellationToken = default);
        Task<UserVm> GetUserById(string id, CancellationToken cancellationToken = default);
        Task MakeAgent (string id, CancellationToken cancellationToken = default);
        Task<List<UserRole>> GetUserRoles(string id, CancellationToken cancellationToken = default);
        Task ResetPassword(string clientId, CancellationToken cancellationToken = default);    
    }
}
