using System.Text.Json;
using System.Text.Json.Serialization;

namespace GitHubAPI.Models
{
    public class GitHubUser
    {
        [JsonPropertyName("login")]
        public string Login { get; set; }

        public static string GetLogin
        {
            get; set;
        }

    }
}
