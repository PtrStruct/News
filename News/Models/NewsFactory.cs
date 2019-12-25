using System.Collections.Generic;
using System.Text;
using System.Web;
using System.Xml;
using System.Xml.Serialization;
using HtmlAgilityPack;

namespace News.Models
{
    public class NewsFactory
    {
        private const string NtRssFeed = "http://www.nt.se/nyheter/norrkoping/rss/";

        private const string ExpressenRssFeed =
            "http://www.expressen.se/Pages/OutboundFeedsPage.aspx?id=3642159&viewstyle=rss";

        private const string SvdRssFeed = "https://www.svd.se/?service=rss";
        private static int idIndex;

        private static readonly StringBuilder sb = new StringBuilder();
        public static List<Item> RssItems { get; set; } = new List<Item>();


        public static List<Item> GetAllArticles()
        {
            RssItems?.Clear();
            GetNewsFeed(NtRssFeed);
            GetNewsFeed(ExpressenRssFeed);
            GetNewsFeed(SvdRssFeed);
            return RssItems;
        }


        public static List<Item> GetNTArticles()
        {
            RssItems.Clear();
            GetNewsFeed(NtRssFeed);
            return RssItems;
        }

        public static List<Item> GetExpressenArticles()
        {
            RssItems.Clear();
            GetNewsFeed(ExpressenRssFeed);
            return RssItems;
        }

        public static List<Item> GetSvdArticles()
        {
            RssItems.Clear();
            GetNewsFeed(SvdRssFeed);
            return RssItems;
        }


        public static void GetNewsFeed(string rssFeedEndpoint)
        {
            var serializer = new XmlSerializer(typeof(Rss));
            var reader = new XmlTextReader(rssFeedEndpoint);

            var rssObject = serializer.Deserialize(reader) as Rss;

            if (rssObject != null)
                foreach (var rssArticle in rssObject.Channel.Item)
                {
                    var document = new HtmlDocument();
                    document.LoadHtml(rssArticle.Description);

                    //Null check
                    var image = document.DocumentNode?.SelectSingleNode("//img")?.Attributes["src"]?.Value;
                    var paragraphs = document.DocumentNode?.SelectNodes("//p");

                    rssArticle.Img = image ?? "https://nationalvisionnews.com/uploads/news-default.png";

                    if (paragraphs != null)
                        foreach (var paragraph in paragraphs)
                            sb.Append($"{paragraph.InnerText} ");

                    var fullDescription = HttpUtility.HtmlDecode(sb.ToString());
                    rssArticle.Description = fullDescription;

                    rssArticle.Id = idIndex;
                    rssArticle.Source = Source.NT;

                    idIndex++;
                    sb.Clear();
                    RssItems.Add(rssArticle);
                }
        }
    }
}