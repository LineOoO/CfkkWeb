using CfkkWeb.Helpers;
using CfkkWeb.Mappings;
using CfkkWeb.Models;
using ISession = NHibernate.ISession;

namespace CfkkWeb.Command
{
    public class NewNewsArticleCommand
    {
        private readonly ISession session = NhibernateHelper.OpenSession();


        public void Execute(NewsArticleModel model)
        {
            using (var transaction = session.BeginTransaction())
            {
                try
                {

                    var newsArticle = new NewsArticle
                    {
                        Title = model.Title,
                        Text = model.Text,
                        PicturePath = model.PicturePath,
                        Author = model.Author,
                        CreatedDate = DateTime.Now.Date,
                        UpdatedDate = model.UpdatedDate,
                        IsPublished = model.IsPublished,
                        ShortDesc = model.ShortDesc,
                    };

                    session.Save(newsArticle);
                    transaction.Commit();

                }

                catch (Exception e)
                {
                    transaction.Rollback();
                    throw;
                }
            }
        }


    }
}
