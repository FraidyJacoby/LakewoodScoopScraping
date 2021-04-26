using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LakewoodScoopScraping.Scraping
{
    public class LakewoodScoopPost
    {
        public string Title { get; set; }
        public string TitleUrl { get; set; }

        public string ImageUrl { get; set; }

        public string Blurb { get; set; }

        public string Comments { get; set; }
        public string CommentsUrl { get; set; }
    }
}
