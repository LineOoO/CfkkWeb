using CfkkWeb.Helpers;
using CfkkWeb.Mappings;
using CfkkWeb.Models;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Linq;
using ISession = NHibernate.ISession;

namespace CfkkWeb.Builders
{
    public class MemberBuilder
    {
        public ISession Session = NhibernateHelper.OpenSession();

        public MemberModel Build()
        {
            var clubs = Session.CreateCriteria<Club>()
                .List<Club>()
                .Select(x => new SelectListItem
                {
                    Value = x.Id.ToString(),
                    Text = x.Name
                }).Where(x => x.Value != "4");

            var belts = Session.CreateCriteria<Belt>()
                .List<Belt>()
                .Select(x => new SelectListItem
                {
                    Value = x.Id.ToString(),
                    Text = x.Name + " - " + x.Color
                });
            return new MemberModel() { Clubs = clubs, BirthDate = DateTime.Now.Date, Belts=belts};
        }

        public MemberModel Build(int id)
        {
            var member = Session.Get<Member>(id);
            var clubs = Session.CreateCriteria<Club>()
                .List<Club>()
                .Select(x => new SelectListItem
                {
                    Value = x.Id.ToString(),
                    Text = x.Name 
                }).Where(x=> x.Value != "4");

            var belts = Session.CreateCriteria<Belt>()
                .List<Belt>()
                .Select(x => new SelectListItem
                {
                    Value = x.Id.ToString(),
                    Text = x.Name + " - " + x.Color
                });


            var memberClub = Session.Get<Club>(member.wp_club); 

            var memberBelt = Session.Get<Belt>(member.wp_belt);
            var MemberBeltName = memberBelt.Name;
            var MemberBeltColor = memberBelt.Color;

            var model = new MemberModel()
            {
                Id = member.Id,
                FirstName = member.FirstName,
                LastName = member.LastName,
                Email = member.Email,
                PhoneNum = member.PhoneNum,
                BirthDate = member.BirthDate,
                Wp_Club = member.wp_club,
                Wp_ClubName = memberClub.Name,
                Wp_Belt = member.wp_belt,
                BeltName = MemberBeltName,
                BeltColor = MemberBeltColor,
                Clubs = clubs,
                Belts = belts,
            };

            return model;
        }
    }
}
