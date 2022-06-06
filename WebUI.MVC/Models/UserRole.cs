using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace WebUI.MVC.Models
{
    public class UserRole
    {

        public string Id { get; set; }
        [JsonIgnore]
        public string Name { get; set; }
        [JsonIgnore]
        public string Description { get; set; }
    }
    public class UserRoles
    {
        public IList<string> roles { get; set; } = new List<string>();
    }
}
