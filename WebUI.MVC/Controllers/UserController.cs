using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Globalization;
using System.Linq;
using System.Security.Claims;
using System.Threading;
using System.Threading.Tasks;
using WebUI.MVC.Models;
using WebUI.MVC.Services.Interfaces;

namespace WebUI.MVC.Controllers
{
    public class UserController : Controller
    {
        public readonly IUserManagement _userManagement;
        public readonly IHttpContextAccessor _httpContextAccessor;

        public UserController(IUserManagement userManagement, IHttpContextAccessor httpContextAccessor)
        {
            _userManagement = userManagement;
            _httpContextAccessor = httpContextAccessor;
        }

        public async Task<IActionResult> Index()
        {
            var idUser = "";
            if (User.Identity.IsAuthenticated)
            {
                string accessToken = await HttpContext.GetTokenAsync("access_token");
                DateTime accessTokenExpiresAt = DateTime.Parse(
                    await HttpContext.GetTokenAsync("expires_at"),
                    CultureInfo.InvariantCulture,
                    DateTimeStyles.RoundtripKind
                    );

                string idtoken = await HttpContext.GetTokenAsync("id_token");
                idUser = _httpContextAccessor.HttpContext.User.Claims.First(i => i.Type == ClaimTypes.NameIdentifier).Value;

                var userRoles = await _userManagement.GetUserRoles(idUser);
                var str = userRoles[0].Name;
                TempData["Role"] = str;
            }


            return View();
        }

        public async Task<IActionResult> CreateUser()
        {
            var idUser = "";
            if (User.Identity.IsAuthenticated)
            {
                string accessToken = await HttpContext.GetTokenAsync("access_token");
                DateTime accessTokenExpiresAt = DateTime.Parse(
                    await HttpContext.GetTokenAsync("expires_at"),
                    CultureInfo.InvariantCulture,
                    DateTimeStyles.RoundtripKind
                    );

                string idtoken = await HttpContext.GetTokenAsync("id_token");
                idUser = _httpContextAccessor.HttpContext.User.Claims.First(i => i.Type == ClaimTypes.NameIdentifier).Value;

                var userRoles = await _userManagement.GetUserRoles(idUser);
                var str = userRoles[0].Name;
                TempData["Role"] = str;
            }

            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> CreateUser(User user)
        {
            var authEntity = await _userManagement.CreateUser(user);
            TempData["Message"] = "Success : User has been succesfully created";
            var idUser = "";
            if (User.Identity.IsAuthenticated)
            {
                string accessToken = await HttpContext.GetTokenAsync("access_token");
                DateTime accessTokenExpiresAt = DateTime.Parse(
                    await HttpContext.GetTokenAsync("expires_at"),
                    CultureInfo.InvariantCulture,
                    DateTimeStyles.RoundtripKind
                    );

                string idtoken = await HttpContext.GetTokenAsync("id_token");
                idUser = _httpContextAccessor.HttpContext.User.Claims.First(i => i.Type == ClaimTypes.NameIdentifier).Value;

                var userRoles = await _userManagement.GetUserRoles(idUser);
                var str = userRoles[0].Name;
                TempData["Role"] = str;
            }

            return RedirectToAction("GetAll");
        }

        

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var idUser = "";
            if (User.Identity.IsAuthenticated)
            {
                string accessToken = await HttpContext.GetTokenAsync("access_token");
                DateTime accessTokenExpiresAt = DateTime.Parse(
                    await HttpContext.GetTokenAsync("expires_at"),
                    CultureInfo.InvariantCulture,
                    DateTimeStyles.RoundtripKind
                    );

                string idtoken = await HttpContext.GetTokenAsync("id_token");
                idUser = _httpContextAccessor.HttpContext.User.Claims.First(i => i.Type == ClaimTypes.NameIdentifier).Value;

                var userRoles = await _userManagement.GetUserRoles(idUser);
                var str = userRoles[0].Name;
                TempData["Role"] = str;
            }
            var users = await _userManagement.GetAllUsers();
            return View(users);
        }

        [HttpGet]
        public async Task<bool> UserExist(string email)
        {

            var users =  await _userManagement.GetAllUsers();
            return users.Any(u => u.Email == email);
        }


        public async Task<IActionResult> Delete(string id)
        {
            var user = await _userManagement.GetUserById(id);
            if(user == null)
            {
                TempData["Message"] = "Error : This user cannot be deleted";
                return RedirectToAction("GetAll");
            }
            return View(user);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Delete(string id, CancellationToken cancellationToken)
        {
            await _userManagement.DeleteById(id);
            TempData["Message"] = "Warning : User has been deleted";
            return RedirectToAction("GetAll");
        }

        public async Task<IActionResult> MakeAgent(string id, CancellationToken cancellationToken)
        {
            //TODO
             //_userManagement.DeleteById(id);
            return RedirectToAction("GetAll");
        }
    }
}
