using System.Collections.Generic;

namespace projekt2.Models
{
    public class SearchResult
    {
        public IEnumerable<LinkResult> Items { get; set; }
        public PageInfo PageInfo { get; set; }
    }

    public class PageInfo
    {
        public int CurrentPage { get; set; }

        public int MaxPage { get; set; }
    }

    public class LinkResult
    {
        public LinkResult(Link link)
        {
            Id = link.Id;
            ShortLink = link.ShortLink;
            FullLink = link.FullLink;
        }
        public int Id { get; set; }
        public string ShortLink { get; set; }
        public string FullLink { get; set; }

    }    

}