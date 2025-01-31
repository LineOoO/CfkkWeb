using CfkkWeb.Helpers;
using CfkkWeb.Mappings;
using CfkkWeb.Models;
using ISession = NHibernate.ISession;

namespace CfkkWeb.Command
{
    public class DeleteMemberCommand
    {
        private readonly ISession session = NhibernateHelper.OpenSession();


        public void Execute(int id)
        {
            using (var transaction = session.BeginTransaction())
            {
                try
                {

                    var member = session.Get<Member>(id);
                    session.Delete(member);
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
