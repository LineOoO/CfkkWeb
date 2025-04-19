using CfkkWeb.Helpers;
using CfkkWeb.Mappings;
using CfkkWeb.Models;
using MySqlX.XDevAPI;
using System.Web.Mvc;
using ISession = NHibernate.ISession;
using Microsoft.AspNetCore.Html;
using System.Text.RegularExpressions;

namespace CfkkWeb.Command
{
    public class EditNewsArticleCommand
    {
        private readonly ISession session = NhibernateHelper.OpenSession();


        public void Execute(NewsArticleModel model)
        {
            using (var transaction = session.BeginTransaction())
            {
                try
                {

                    var article = session.Get<NewsArticle>(model.Id);

                    
                    if (ContainsHtml(article.Text)) article.Text = model.Text;
                    else
                    {
                        transaction.Rollback();
                    }
                    article.Title = model.Title;
                    article.ShortDesc = model.ShortDesc;
                    article.Author = model.Author;
                    article.CreatedDate = DateTime.Now.Date;
                    if(model.PicturePath != null) { article.PicturePath = model.PicturePath; }
                    

                    session.Update(article);
                    transaction.Commit();

                }

                catch (Exception e)
                {
                    transaction.Rollback();
                    throw;
                }
            }
        }

        private bool ContainsHtml(string input)
        {
            return Regex.IsMatch(input ?? "", "<.*?>");
        }
    }
}
