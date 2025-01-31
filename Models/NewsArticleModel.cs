using CfkkWeb.Mappings;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.ComponentModel.DataAnnotations;

namespace CfkkWeb.Models
{
    public class NewsArticleModel
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "Článek musí mít nadpis")]
        public string Title { get; set; }
        [Required(ErrorMessage = "Článek musí obsahovat text")]
        public string Text { get; set; }
        public string? PicturePath { get; set; }
        public string? Author { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime? UpdatedDate { get; set; }
        public bool IsPublished { get; set; }

        public string? ShortDesc { get; set; }
    }
    
}
