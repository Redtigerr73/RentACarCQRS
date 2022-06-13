using Newtonsoft.Json;

namespace WebUI.MVC.Models
{
    public class UserPasswordReset
    {
        [JsonProperty("client_id")]
        public string ClientId { get; set; }
    }
}
