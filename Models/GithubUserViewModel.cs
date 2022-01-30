using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace GitHubUserSearch.Models
{
    public class GithubUserViewModel
    {
        public GithubUserModel GithubUser { get; set; }
        public GithubReposModel.RepoData GithubRepos { get; set; }
    }
}