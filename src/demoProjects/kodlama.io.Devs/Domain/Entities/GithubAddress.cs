using Core.Persistence.Repositories;
using Core.Security.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class GithubAddress : Entity
    {
        public int UserId { get; set; }
        public string GithubLink { get; set; }

        public virtual User User { get; set; }

        public GithubAddress()
        {
        }

        public GithubAddress(int id, int userId, string githubLink) : this()
        {
            Id = id;
            UserId = userId;
            GithubLink = githubLink;
        }
    }
}
