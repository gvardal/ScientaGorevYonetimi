namespace ScientaScheduler.MVC.Models.Domain
{
    public class BlogPost
    {
        public Guid Id { get; set; }
        public string Heading { get; set; } = string.Empty;
        public string PageTitle { get; set; } = string.Empty;
        public string? Content { get; set; } = string.Empty;
        public string? ShortDescription { get; set; } = string.Empty;
        public string? FeaturedImageUrl { get; set; } = string.Empty;
        public string? UrlHandle { get; set; } = string.Empty;
        public DateTime PublishedDate { get; set; }
        public bool Visible { get; set; }
    }
}
