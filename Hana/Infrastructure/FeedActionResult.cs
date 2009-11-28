using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.ServiceModel.Syndication;
using System.Xml;
using SubSonic.DataProviders;
using Hana.Model;
using System.Security.Policy;

namespace Hana.Infrastructure
{

    public enum FeedFormat
    {
        RSS,
        Atom
    }

    public class FeedActionResult : ActionResult
    {
        public FeedFormat Format { get; set; }

        public FeedActionResult(FeedFormat format, UrlHelper url, 
            IEnumerable<Post> posts)
        {
            Feed = new SyndicationFeed(Blog.BlogName, Blog.BlogTagLine, 
                new Uri(url.SiteRoot()), url.SiteRoot(), DateTime.Now);

            List<SyndicationItem> items = new List<SyndicationItem>();

            //load the posts as items
            foreach (var p in posts)
            {
                var slug = p.Slug;

                var postRelative = url.Action(
                    "Details", "Posts",
                    new {
                        year = p.PublishedOn.Year,
                        month = p.PublishedOn.Month.FormattedDayMonth(),
                        day = p.PublishedOn.Day.FormattedDayMonth(),
                        id = p.Slug
                    });

                var postAbsolute = url.SiteRoot() + postRelative;
                
                var item = new SyndicationItem(p.Title, p.Body, 
                    new Uri(postAbsolute),p.PostID.ToString(), p.PublishedOn);
                
                items.Add(item);


            }
            Feed.Items = items.OrderByDescending(x=>x.LastUpdatedTime);
        }

        
        
        public SyndicationFeed Feed { get; set; }
        
        public override void ExecuteResult(ControllerContext context)
        {
            if (Format == FeedFormat.RSS)
            {
                context.HttpContext.Response.ContentType = "application/rss+xml";

                var rssFormatter = new Rss20FeedFormatter(Feed);
                using (var writer = XmlWriter.Create(context.HttpContext.Response.Output))
                {
                    rssFormatter.WriteTo(writer);
                }
            }
            else
            {
                context.HttpContext.Response.ContentType = "application/atom+xml";

                var rssFormatter = new Atom10FeedFormatter(Feed);
                using (var writer = XmlWriter.Create(context.HttpContext.Response.Output))
                {
                    rssFormatter.WriteTo(writer);
                }
            }
        }
    }
}
