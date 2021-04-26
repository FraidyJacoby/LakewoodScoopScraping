using LakewoodScoopScraping.Scraping;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LakewoodScoopScraping.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LakewoodScoopController : ControllerBase
    {
        [HttpGet]
        [Route("getposts")]
        public List<LakewoodScoopPost> GetPosts()
        {
            return LakewoodScoopScraper.GetPosts();
        }
    }
}
