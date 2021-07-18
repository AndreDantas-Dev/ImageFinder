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

        public static Uri GetUriFromImgSrc(string src)
        {
            if (Uri.TryCreate(src, UriKind.Absolute, out Uri uriResult))
                return uriResult;

            return null;
        }
    }
}