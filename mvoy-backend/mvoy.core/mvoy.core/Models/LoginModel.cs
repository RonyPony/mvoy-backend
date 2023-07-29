using Newtonsoft.Json;

namespace mvoy_backend.Web.Models
{
    public class LoginModel
    {
        [JsonProperty("idUsuario")]
        public string idUsuario { get; set; }

        [JsonProperty("User")]
        public string User { get; set; }

        [JsonProperty("password")]
        public string password { get; set; }
        [JsonProperty("rol")]
        public string roll { get; set; }
    }
}