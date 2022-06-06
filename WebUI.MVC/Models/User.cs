using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace WebUI.MVC.Models
{
    public class User
    {
        public string Id { get; set; }


        [Required(ErrorMessage = "An email is required")]
        [DisplayName("E-mail")]
        public string Email { get; set; }

        [Required(ErrorMessage = "A name is required")]
        [DisplayName("Last Name")]
        public string LastName { get; set; }
        
        [Required(ErrorMessage = "An email is required")]
        [DisplayName("First Name")]
        public string FirstName { get; set; }

        public string IdRole  { get; set; }
        
        
    }

    public class Users
    {
        public List<User> UserList { get; set; }
    }
}
