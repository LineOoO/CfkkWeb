using CfkkWeb.Helpers;
using CfkkWeb.Mappings;
using CfkkWeb.Models;
using MySqlX.XDevAPI;
using ISession = NHibernate.ISession;

namespace CfkkWeb.Command
{
    public class EditMemberCommand
    {
        private readonly ISession session = NhibernateHelper.OpenSession();


        public void Execute(MemberModel model)
        {
            using (var transaction = session.BeginTransaction())
            {
                try
                {

                    var member = session.Get<Member>(model.Id);

                    member.FirstName = model.FirstName;
                    member.LastName = model.LastName;
                    member.BirthDate = model.BirthDate;
                    member.Email = model.Email;
                    member.PhoneNum = model.PhoneNum;
                    member.wp_club = model.Wp_Club;
                    member.wp_belt = model.Wp_Belt;
                    
                    session.Update(member);
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
