using Social.RepositoriesLibrary.Entities.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Social.RepositoriesLibrary.Entities.Crawler
{
    public class Preview : IEntity
    {
        public string Url { get; set; }
        public string Title { get; set; }
        public string Summary { get; set; }
        public List<string> ImageUrls { get; set; }

        public string Host { get; set; }
        public string IFrameUrl { get; set; }

        public List<string> ComputeImageUrls
        {
            get
            {
                List<string> l = new List<string>();
                foreach (string s in ImageUrls)
                {
                    string imageUrl = s;
                    if (imageUrl != null)
                        if (!(imageUrl.StartsWith("http") || imageUrl.StartsWith("//")))
                        {
                            if (!imageUrl.StartsWith("/"))
                                imageUrl = "/" + imageUrl;
                            imageUrl = "//" + Host + imageUrl;
                        }
                    l.Add(imageUrl);
                }
                return l;
            }
        }

        public string Summary50
        {
            get
            {
                string s = Summary ?? "";
                if (s.Length > 150)
                    s = s.Substring(0,147) + "...";
                return s;
            }
        }

        public Preview()
        {
            ImageUrls = new List<string>();
        }

        public override string ToString()
        {
            if (Title != null) Title = Title.Trim();
            if (Summary != null) Summary = Summary.Trim();
            string imageUrl = ComputeImageUrls.FirstOrDefault();
            string s = "<a href=\"{0}\" target=\"_blank\"><div class=\"previewimg\">";
            if (IFrameUrl != null)
                s += "<iframe width=\"480\" height=\"270\" src=\""+ IFrameUrl +"\"  allowfullscreen></iframe>";
            else if (imageUrl != null)
                s += "<img src=\"" + imageUrl + "\" height=\"200\"/>";
            s += "</div><div class=\"previewsummary\">{1}</div></a>";
            return string.Format(s, Url, Summary50);
        }
    }
}
