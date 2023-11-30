using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.GithubAddresses.Dtos
{
    public class CreatedGithubDto
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public string GithubLink { get; set; }
    }
}
