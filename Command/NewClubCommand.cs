using CfkkWeb.Helpers;
using CfkkWeb.Mappings;
using CfkkWeb.Models;
using ISession = NHibernate.ISession;

namespace CfkkWeb.Command
{
    public class NewClubCommand
    {
        private readonly ISession session = NhibernateHelper.OpenSession();


        public void Execute(ClubModel model)
        {
            using (var transaction = session.BeginTransaction())
            {
                try
                {

                    var club = new Club
                    {
                        Name = model.Name,
                    };

                    session.Save(club);
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
