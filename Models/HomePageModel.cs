using System.ComponentModel.DataAnnotations;

namespace CfkkWeb.Models
{
    public class HomePageModel
    {
        public IList<NewsArticleModel> PublishedArticles { get; set; }
    }
}
