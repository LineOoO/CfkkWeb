using CfkkWeb.Helpers;
using CfkkWeb.Mappings;
using CfkkWeb.Models;
using Microsoft.AspNetCore.Http.HttpResults;
using NHibernate.Criterion;
using ISession = NHibernate.ISession;

namespace CfkkWeb.Builders
{
    public class NewsArticleBuilder
    {
        public ISession Session = NhibernateHelper.OpenSession();

        public NewsArticleModel Build()
        {
            return new NewsArticleModel() { };
        }

        public NewsArticleModel Build(int id)
        {
            var newsArticle = Session.Get<NewsArticle>(id);

            

            var model = new NewsArticleModel()
            {
                Id = newsArticle.Id,
                Title = newsArticle.Title,
                Text = newsArticle.Text,
                PicturePath = newsArticle.PicturePath,
                Author = newsArticle.Author,
                CreatedDate = newsArticle.CreatedDate,
                UpdatedDate = newsArticle.UpdatedDate,
                IsPublished = newsArticle.IsPublished,
                ShortDesc = newsArticle.ShortDesc,
            };

            return model;
        }
    }
}
