using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Mvc;
using System.Net.Http.Headers;
using System.Collections.Generic;
using System.Text.Json;
using System.Text.Json.Serialization;
using GitHubAPI.Models;
using System.Web;
using System.Security.Claims;
using Microsoft.AspNetCore.Identity;

namespace GitHubAPI.Controllers
{
    [Route("[controller]/[action]")]
    public class AuthController : Controller
    {
        [HttpGet]
        public IActionResult Login(string returnUrl = "/auth/getrepos")
        {
            return Challenge(new AuthenticationProperties() { RedirectUri = returnUrl });
        }
        [HttpGet]
        public async Task<ActionResult<RepositoryList>> GetRepos()
        {
            HttpClient client = new HttpClient();
            var token = await HttpContext.GetTokenAsync("access_token");
            var user = GitHubUser.GetLogin;


            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(
                new MediaTypeWithQualityHeaderValue("application/vnd.github.v3+json"));
            client.DefaultRequestHeaders.Add("User-Agent", ".NET Foundation Repository Reporter");
            client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("token", token);
            var uri = $"https://api.github.com/search/repositories?q=user:{user}";
            var response = client.GetStreamAsync(uri);

            //Console.WriteLine(await response);
            var repositories = await JsonSerializer.DeserializeAsync<RepositoryList>(await response); //new RepositoryList();

            return repositories;
        }
    }
}
