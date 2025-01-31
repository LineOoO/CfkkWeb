using System.ComponentModel.DataAnnotations;

namespace CfkkWeb.Models
{
    public class ClubModel
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Jméno klubu je povinné.")]
        public string Name { get; set; }
        public IList<MemberModel>? ClubMembers { get; set; }
    }
}
