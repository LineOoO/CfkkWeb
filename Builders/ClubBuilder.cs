using CfkkWeb.Helpers;
using CfkkWeb.Mappings;
using CfkkWeb.Models;
using NHibernate.Criterion;
using ISession = NHibernate.ISession;

namespace CfkkWeb.Builders
{
    public class ClubBuilder
    {
        public ISession Session = NhibernateHelper.OpenSession();

        public ClubModel Build()
        {
            return new ClubModel();
        }

        public ClubModel Build(int id)
        {
            var club = Session.Get<Club>(id);

            var clubMembers = Session.CreateCriteria<Member>()
                .Add(Restrictions.Eq("wp_club", club.Id))
                .List<Member>()
                .Select(m => new MemberModel
                {
                    Id = m.Id,
                    FirstName = m.FirstName,
                    LastName = m.LastName,
                    Email = m.Email,
                    PhoneNum = m.PhoneNum,
                    BirthDate = m.BirthDate,
                    Wp_Belt = m.wp_belt,
                    BeltColor = Session.Get<Belt>(m.wp_belt).Color,
                    BeltName = Session.Get<Belt>(m.wp_belt).Name,
                });

            var clubMemberList = clubMembers.ToList();

            var model = new ClubModel()
            {
                Id = club.Id,
                Name = club.Name,
                ClubMembers = clubMemberList,
            };

            return model;
        }
    }
}
