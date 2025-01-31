using CfkkWeb.Helpers;
using CfkkWeb.Mappings;
using CfkkWeb.Models;
using ISession = NHibernate.ISession;

namespace CfkkWeb.Builders
{
    public class MemberListBuilder
    {
        public ISession Session = NhibernateHelper.OpenSession();

        public MemberListModel Build()
        {
            var members = Session.CreateCriteria<Member>()
                .List<Member>()
                .Select(member => new MemberModel()
                {
                    Id = member.Id,
                    FirstName = member.FirstName,
                    LastName = member.LastName,
                    Email = member.Email,
                    PhoneNum = member.PhoneNum,
                    BirthDate = member.BirthDate,
                    Wp_Club = member.wp_club,
                    Wp_ClubName = Session.Get<Club>(member.wp_club).Name,
                    Wp_Belt = member.wp_belt,
                    BeltColor = Session.Get<Belt>(member.wp_belt).Color,
                    BeltName = Session.Get<Belt>(member.wp_belt).Name,


                });

            var membersList = members.ToList();
            var model = new MemberListModel()
            {
                Members = membersList,
            };
            return model;
        }
    }
}
