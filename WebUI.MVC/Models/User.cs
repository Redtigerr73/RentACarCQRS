using System.Collections.Generic;

namespace WebUI.MVC.Models
{
    public class User
    {
        public string UserName { get; set; }
        public string FirstName { get; set; }        
        public string LastName { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
    }

    public class Users
    {
        public List<User> UserList { get; set; }
    }
}
