namespace CfkkWeb.Mappings
{
    public class NewsArticle
    {
        public virtual int Id { get; set; }
        public virtual required string Title { get; set; }

        public virtual required string Text { get; set; }

        public virtual string? PicturePath { get; set; }

        public virtual string? Author { get; set; }

        public virtual DateTime CreatedDate { get; set; }

        public virtual DateTime? UpdatedDate { get; set; }

        public virtual bool IsPublished { get; set; }

        public virtual string? ShortDesc { get; set; }

    }
}
