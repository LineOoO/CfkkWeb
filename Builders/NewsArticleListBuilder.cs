using CfkkWeb.Helpers;
using CfkkWeb.Mappings;
using CfkkWeb.Models;
using NHibernate.Criterion;
using ISession = NHibernate.ISession;

namespace CfkkWeb.Builders
{
    public class NewsArticleListBuilder
    {
        public ISession Session = NhibernateHelper.OpenSession();

        public NewsArticleListModel Build()
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
            
            var publishedArticles = allArticlesList.Where(article => article.IsPublished == true);
            var unpublishedArticles = allArticlesList.Where(article => article.IsPublished == false);

            var model = new NewsArticleListModel()
            {
                AllArticles = allArticlesList,
                PublishedArticles = publishedArticles.ToList(),
                UnpublishedArticles = unpublishedArticles.ToList(),
            };

            return model;
        }
    }
}
