namespace projekt2.Models
{
    public class CreateLinkRequest
    {
        public string ShortLink { get; set; }
        public string FullLink { get; set; }

        public Link GetLink()
        {
            var link = new Link
            {
                ShortLink = this.ShortLink,
                FullLink = this.FullLink
            };

            return link;
        }
    }
}