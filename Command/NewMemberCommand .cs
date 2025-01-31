using CfkkWeb.Helpers;
using CfkkWeb.Mappings;
using CfkkWeb.Models;
using ISession = NHibernate.ISession;

namespace CfkkWeb.Command
{
    public class NewMemberCommand
    {
        private readonly ISession session = NhibernateHelper.OpenSession();


        public void Execute(MemberModel model)
        {
            using (var transaction = session.BeginTransaction())
            {
                try
                {

                    var member = new Member
                    {
                        FirstName = model.FirstName,
                        LastName = model.LastName,
                        BirthDate = model.BirthDate,
                        Email = model.Email,
                        PhoneNum = model.PhoneNum,
                        wp_club = model.Wp_Club,
                        wp_belt = model.Wp_Belt

                    };

                    session.Save(member);
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
