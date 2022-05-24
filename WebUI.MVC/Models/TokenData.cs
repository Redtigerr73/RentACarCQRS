using Newtonsoft.Json;

namespace WebUI.MVC.Models
{
    public class TokenData
    {
        [JsonProperty]
        public string AccessToken { get; set; }
        [JsonProperty]
        public string Scope { get; set; }
        [JsonProperty]
        public int ExpiresIn { get; set; }
        [JsonProperty]
        public string TokenType { get; set; }
    }
}
