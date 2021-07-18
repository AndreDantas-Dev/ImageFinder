using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using HtmlAgilityPack;
using ImageFinder.Models;

namespace ImageFinder.Pages
{
    public partial class Home : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
        }

        protected void btnSearch_Click(object sender, EventArgs e)
        {
            var url = inSearch.Text;
            var document = HtmlPageHandler.GetPageHtmlDocument(url);

            if (document != null)
            {
                LoadImagesFromHtmlDocument(document);
            }
        }

        protected void LoadImagesFromHtmlDocument(HtmlDocument document)
        {
            var imgs = new List<SearchImage>();

            foreach (var node in document.DocumentNode.Descendants())
            {
                if (node.Name.ToLower() == "img")
                {
                    string src = node.Attributes["src"].Value;
                    if (!string.IsNullOrEmpty(src) && HtmlPageHandler.IsUrlValid(src))
                        imgs.Add(new SearchImage { src = src });
                }
            }

            grdImages.DataSource = imgs;
            grdImages.DataBind();
        }

        protected void RankPageWords(string text)
        {
        }
    }
}