using CfkkWeb.Mappings;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.ComponentModel.DataAnnotations;

namespace CfkkWeb.Models
{
    public class MemberModel
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Jméno je povinné.")]
        public  string FirstName { get; set; }

        [Required(ErrorMessage = "Příjmení je povinné.")]
        public  string LastName { get; set; }

        [Required(ErrorMessage = "Email je povinný.")]
        [EmailAddress(ErrorMessage = "Zadejte platný email.")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Telefon je povinný.")]
        public  string PhoneNum { get; set; }

        [Required(ErrorMessage = "Datum narození je povinné.")]
        public DateTime BirthDate { get; set; }

        [Required(ErrorMessage = "Klub je povinný.")]
        public int Wp_Club { get; set; }
        public string? Wp_ClubName { get; set; }

        [Required(ErrorMessage = "Pás je povinný.")]
        public int Wp_Belt { get; set; }
        public string? BeltName { get; set; }
        public string? BeltColor { get; set; }
        public IEnumerable<SelectListItem>? Clubs { get; set; }
        public IEnumerable<SelectListItem>? Belts { get; set; }
    }
}
