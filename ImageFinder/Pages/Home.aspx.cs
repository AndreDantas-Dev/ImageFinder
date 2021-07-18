using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using HtmlAgilityPack;
using ImageFinder.Models;

namespace ImageFinder.Pages
{
    public partial class Home : System.Web.UI.Page
    {
        protected const int topWordsAmount = 10;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
                ClearPage();
        }

        protected void btnSearch_Click(object sender, EventArgs e)
        {
            var url = inSearch.Text;
            var document = HtmlPageHandler.GetPageHtmlDocument(url);

            ClearPage();

            if (document != null)
            {
                main.Visible = true;
                LoadImagesFromHtmlDocument(document, url);
                RankPageWords(HttpUtility.HtmlDecode(document.DocumentNode.InnerText));
            }
        }

        protected void LoadImagesFromHtmlDocument(HtmlDocument document, string originUrl = "")
        {
            var imgs = new List<SearchImage>();

            foreach (var node in document.DocumentNode.Descendants())
            {
                if (node.Name.ToLower() == "img")
                {
                    string src = node.Attributes["src"].Value;
                    var uri = HtmlPageHandler.GetUriFromImgSrc(src);

                    if (uri == null)
                        continue;

                    Uri url;

                    url = (uri.Scheme == Uri.UriSchemeHttp || uri.Scheme == Uri.UriSchemeHttps)
                        ? uri
                        : null;

                    if (!string.IsNullOrEmpty(url?.GetLeftPart(UriPartial.Path)))
                        imgs.Add(new SearchImage { src = url.GetLeftPart(UriPartial.Path) });
                }
            }

            grdImages.DataSource = imgs;
            grdImages.DataBind();
        }

        protected void RankPageWords(string text)
        {
            if (string.IsNullOrEmpty(text)) return;

            var wordDict = new Dictionary<string, int>();

            MatchCollection matches = Regex.Matches(text.ToLower(), @"\b[\w']*\b");

            var words = from m in matches.Cast<Match>()
                        where !string.IsNullOrEmpty(m.Value)
                        select m.Value;

            foreach (var word in words)
            {
                if (!wordDict.ContainsKey(word))
                    wordDict[word] = 1;
                else
                    wordDict[word]++;
            }

            var wordList = wordDict.ToList();

            wordList.Sort((pair1, pair2) => pair2.Value.CompareTo(pair1.Value));

            grdWords.DataSource = wordList.Take(topWordsAmount).ToList();
            grdWords.DataBind();
        }

        public void ClearPage()
        {
            main.Visible = false;
        }
    }
}