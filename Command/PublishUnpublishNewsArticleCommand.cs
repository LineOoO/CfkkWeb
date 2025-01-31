using CfkkWeb.Helpers;
using CfkkWeb.Mappings;
using CfkkWeb.Models;
using ISession = NHibernate.ISession;

namespace CfkkWeb.Command
{
    public class PublishUnpublishNewsArticleCommand
    {
        private readonly ISession session = NhibernateHelper.OpenSession();


        public void Execute(int id, bool publish)
        {
            using (var transaction = session.BeginTransaction())
            {
                try
                {

                    var newsArticle = session.Get<NewsArticle>(id);

                    if (publish)
                    {
                        newsArticle.IsPublished = true;
                        session.Save(newsArticle);
                        transaction.Commit();
                    }

                    
                    else
                    {
                        newsArticle.IsPublished = false;
                        session.Save(newsArticle);
                        transaction.Commit();
                    }
                    

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
