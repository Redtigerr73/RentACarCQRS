using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;

namespace WebUI.MVC.Models
{
    public class Auth0Entity
    {
        
        public Auth0Entity(string email, string firstName, string lastName,  string userId, IConfiguration config)
        {
            Email = email;
            FirstName = firstName;
            LastName = lastName;
            Name = firstName + " " + lastName;
            UserId = userId;
            Connection = config["UserManagementAPI:connectionType"];
            Password = config["UserManagementAPI:defaultPw"];

        }
       

        [JsonProperty("email")]
        public string Email { get; set; }
        [JsonProperty("given_name")]
        public string FirstName { get; set; }
        [JsonProperty("family_name")]
        public string LastName { get; set; }
        [JsonProperty("name")]
        public string Name { get; set; }
        [JsonProperty("user_id")]
        public string UserId { get; set; }
        [JsonProperty("connection")]
        public string Connection { get; set; }
        [JsonProperty("password")]
        public string Password { get; set; }



    }


    
}

/*
 * 
 * {
"email": "johnn.doe@gmail.com",
"given_name": "John",
"family_name": "Doe",
"name": "John Doe",
"user_id": "abcc",
"connection": "Username-Password-Authentication",
"password": "secret1#",
"verify_email": false
}
 */

