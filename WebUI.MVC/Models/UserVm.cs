using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace WebUI.MVC.Models
{
    public class UserVm
    {
        [JsonProperty("email")]
        [Required(ErrorMessage = "An email is required")]
        [DisplayName("E-mail")]
        public string Email { get; set; }

        [JsonProperty("name")]
        [Required(ErrorMessage = "A name is required")]
        [DisplayName("Name")]
        public string Name { get; set; }
        
        [JsonProperty("user_id")]
        [Required(ErrorMessage = "An email is required")]
        [DisplayName("User Id")]
        public string UserId { get; set; }
        
        [JsonProperty("last_login")]
        public DateTimeOffset LastLogin { get; set; }
    }

    public class UsersVm
    {
        public List<UserVm> UserList { get; set; }
    }
}

