using System.Threading.Tasks;
using WebUI.MVC.Models;

namespace WebUI.MVC.Services.Interfaces
{
    public interface IUserManagement 
    {
        Task CreateUser(User user);
        Task<TokenData> GetToken();
    }
}
