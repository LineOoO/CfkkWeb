using CfkkWeb.Helpers;
using CfkkWeb.Mappings;
using CfkkWeb.Models;
using NHibernate.Criterion;
using ISession = NHibernate.ISession;

namespace CfkkWeb.Command
{
    public class DeleteClubCommand
    {
        private readonly ISession session = NhibernateHelper.OpenSession();


        public void Execute(int id)
        {
            using (var transaction = session.BeginTransaction())
            {
                try
                {

                    var club = session.Get<Club>(id);

                    var clubMembers = session.CreateCriteria<Member>()
                        .Add(Restrictions.Eq("wp_club", id))
                        .List<Member>();

                    foreach (var member in clubMembers)
                    {
                        member.wp_club = 4;
                        session.Update(member);
                    }

                    session.Delete(club);
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
