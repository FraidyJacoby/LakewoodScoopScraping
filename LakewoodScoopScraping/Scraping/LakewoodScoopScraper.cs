using AngleSharp.Dom;
using AngleSharp.Html.Parser;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace LakewoodScoopScraping.Scraping
{
    public static class LakewoodScoopScraper
    {
        public static List<LakewoodScoopPost> GetPosts()
        {
            var result = new List<LakewoodScoopPost>();

            var html = GetLakewoodScoopHtml();
            var parser = new HtmlParser();
            var document = parser.ParseDocument(html);
            var divs = document.QuerySelectorAll(".post");
            foreach(var div in divs)
            {
                var post = ParseDiv(div);
                if(post != null)
                {
                    result.Add(post);
                }
            }

            return result;
        }

        private static string GetLakewoodScoopHtml()
        {
            var client = new HttpClient();
            return client.GetStringAsync("https://www.thelakewoodscoop.com/").Result;
        }

        private static LakewoodScoopPost ParseDiv(IElement div)
        {
            var titleH2 = div.QuerySelector("h2");
            var anchorTag = titleH2.QuerySelector("a");
            var titleUrl = anchorTag.Attributes["href"].Value;
            var title = anchorTag.Attributes["title"].Value;

            var imageTag = div.QuerySelector("img");

            var imageUrl = "";
            if (imageTag != null)
            {
                imageUrl = imageTag.Attributes["src"].Value;
            }

            var blurb  = div.QuerySelector("p").TextContent;
            var blurbText = "";
            if (blurb != null)
            {
                blurbText = blurb;
            }

            var commentDiv = div.QuerySelector("div.backtotop");
            var comments = commentDiv.TextContent;
            var commentsUrlAnchorTag = commentDiv.QuerySelector("a");
            var commentsUrl = commentsUrlAnchorTag.Attributes["href"].Value;

            var result = new LakewoodScoopPost
            {
                Title = title,
                TitleUrl = titleUrl,
                ImageUrl = imageUrl,
                Blurb = blurbText,
                Comments = comments,
                CommentsUrl = commentsUrl
            };

            return result;
        }
    }
}
