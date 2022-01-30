using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using System.Web;

namespace GitHubUserSearch.Models
{
    /// <summary>
    /// Model for the main Github user based on API
    /// </summary>
    public class GithubUserModel
    {
            [Display(Name ="Username")]
            public string login { get; set; }
            public int id { get; set; }
            public string node_id { get; set; }
            [Display(Name ="Avatar URL")]
            public string avatar_url { get; set; }
            public string gravatar_id { get; set; }
            public string url { get; set; }
            public string html_url { get; set; }
            public string followers_url { get; set; }
            public string following_url { get; set; }
            public string gists_url { get; set; }
            public string starred_url { get; set; }
            public string subscriptions_url { get; set; }
            public string organizations_url { get; set; }
            public string repos_url { get; set; }
            public string events_url { get; set; }
            public string received_events_url { get; set; }
            public string type { get; set; }
            public bool site_admin { get; set; }
            public string name { get; set; }
            public string company { get; set; }
            public string blog { get; set; }
            [Display (Name = "Location")]
            public string location { get; set; }
            public object email { get; set; }
            public object hireable { get; set; }
            public string bio { get; set; }
            public object twitter_username { get; set; }
            public int public_repos { get; set; }
            public int public_gists { get; set; }
            public int followers { get; set; }
            public int following { get; set; }
            public DateTime created_at { get; set; }
            public DateTime updated_at { get; set; }



        private GithubUserModel githubUserResult;
        /// <summary>
        /// Get the user info from the API based on entered username and return a GithubUserModel object
        /// </summary>
        /// <param name="username"></param>
        /// <returns></returns>
        public async Task<GithubUserModel> GetGithubUserAsync(string username)
        {
            string url = "";
            using (HttpClient client = new HttpClient())
            {
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                client.DefaultRequestHeaders.UserAgent.TryParseAdd("request"); //Set the User Agent to "request" otherwise 403 error
                url = $"https://api.github.com/users/{username}";

                // Deserialise into model object and return to the view
                using (HttpResponseMessage response = client.GetAsync(url).Result)
                {
                    if (response.IsSuccessStatusCode)
                    {
                        var responseBody = await response.Content.ReadAsStringAsync();
                        githubUserResult = JsonConvert.DeserializeObject<GithubUserModel>(responseBody);
                    }

                    return githubUserResult;
                }
            }
        }

    }
}