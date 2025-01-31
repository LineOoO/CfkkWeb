using CfkkWeb.Helpers;
using CfkkWeb.Mappings;
using CfkkWeb.Models;
using NHibernate.Criterion;
using ISession = NHibernate.ISession;

namespace CfkkWeb.Builders
{
    public class HomePageModelBuilder
    {
        public ISession Session = NhibernateHelper.OpenSession();

        public HomePageModel Build()
        {
            var allArticles = Session.CreateCriteria<NewsArticle>()
                .List<NewsArticle>()
                .Select(NewsArticle => new NewsArticleModel()
                {
                    Id = NewsArticle.Id,
                    Title = NewsArticle.Title,
                    Text = NewsArticle.Text,
                    PicturePath = NewsArticle.PicturePath,
                    Author = NewsArticle.Author,
                    CreatedDate = NewsArticle.CreatedDate,
                    UpdatedDate = NewsArticle.UpdatedDate,
                    IsPublished = NewsArticle.IsPublished,
                    ShortDesc = NewsArticle.ShortDesc,
                });

            var allArticlesList = allArticles.ToList();
            
            

            var model = new HomePageModel()
            {
                
                PublishedArticles = allArticlesList.Where(article => article.IsPublished == true).ToList(),
            };

            return model;
        }
    }
}
