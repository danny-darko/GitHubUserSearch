using GitHubUserSearch.Models;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text.Json;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace GitHubUserSearch.Controllers
{
    public class HomeController : Controller
    {
        public async Task<ActionResult> Index(string githubUsername)
        {
        //    GithubUserModel githubUserModel = new GithubUserModel();
        //    GithubReposModel githubReposModel = new GithubReposModel();

        //    return View(new GithubUserViewModel() {GithubUser = await githubUserModel.GetGithubUserAsync(githubUsername), GithubRepos = await githubReposModel.GetGithubRepoAsync(githubUsername) });

            GithubUserModel githubUserModel = new GithubUserModel();
            return View(await githubUserModel.GetGithubUserAsync(githubUsername));
           
        }

    }
}