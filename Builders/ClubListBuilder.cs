using CfkkWeb.Helpers;
using CfkkWeb.Mappings;
using CfkkWeb.Models;
using ISession = NHibernate.ISession;

namespace CfkkWeb.Builders
{
    public class ClubListBuilder
    {
        public ISession Session = NhibernateHelper.OpenSession();

        public ClubListModel Build()
        {
            var clubs = Session.CreateCriteria<Club>()
                .List<Club>()
                .Select(club => new ClubModel()
                {
                    Id = club.Id,
                    Name = club.Name,
                });

            var clubsList = clubs.ToList();
            var model = new ClubListModel()
            {
                Clubs = clubsList,
            };
            return model;
        }
    }
}
