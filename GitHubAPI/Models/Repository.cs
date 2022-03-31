using System.Text.Json;
using System.Text.Json.Serialization;

namespace GitHubAPI.Models
{
    public class RepositoryList
    {
        [JsonPropertyName("items")]
        public IList<Repository> Name { get; set; }
    }

    public class Repository
    {
        [JsonPropertyName("name")]
        public string Name { get; set; }

        [JsonPropertyName("html_url")]
        public string Url { get; set; }
    }
}
