using HtmlAgilityPack;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;

namespace ImageFinder.Models
{
    public static class HtmlPageHandler
    {
        public static HtmlDocument GetPageHtmlDocument(string url)
        {
            try
            {
                using (var client = new WebClient())
                {
                    client.Headers.Add("User-Agent", "C# web app");
                    var document = new HtmlDocument();

                    document.LoadHtml(client.DownloadString(url));

                    return document;
                }
            }
            catch
            {
                return null;
            }
        }

        public static bool IsUrlValid(string url)
        {
            return Uri.TryCreate(url, UriKind.Absolute, out Uri uriResult) && (uriResult.Scheme == Uri.UriSchemeHttp || uriResult.Scheme == Uri.UriSchemeHttps);
        }
    }
}