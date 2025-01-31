namespace CfkkWeb.Models
{
    public class NewsArticleListModel
    {
        public IList<NewsArticleModel> PublishedArticles { get; set; }

        public IList<NewsArticleModel> UnpublishedArticles { get; set; }

        public IList<NewsArticleModel> AllArticles { get; set; }
    }
}
