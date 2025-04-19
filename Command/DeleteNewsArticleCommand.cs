using CfkkWeb.Helpers;
using CfkkWeb.Mappings;
using CfkkWeb.Models;
using ISession = NHibernate.ISession;

namespace CfkkWeb.Command
{
    public class DeleteNewsArticleCommand
    {
        private readonly ISession session = NhibernateHelper.OpenSession();


        public void Execute(int id)
        {
            using (var transaction = session.BeginTransaction())
            {
                try
                {

                    var newsArticle = session.Get<NewsArticle>(id);
                    

                    var imagePath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", newsArticle.PicturePath.TrimStart('/'));


                    if (File.Exists(imagePath))
                    {
                        File.Delete(imagePath);
                    }
                    
                    session.Delete(newsArticle);
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
