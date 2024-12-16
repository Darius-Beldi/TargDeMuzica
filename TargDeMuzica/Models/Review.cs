using System.ComponentModel.DataAnnotations;
namespace TargDeMuzica.Models
{
    public class Review
    {
        [Key]
        public int ReviewId { get; set; }
        [Required(ErrorMessage = "Continutul comentariului este obligatoriu!")]
        public string ReviewContent { get; set; }
        public DateTime ReviewDate { get; set; }
        [Required(ErrorMessage = "Rating-ul este obligatoriu!")]
        public int StarRating { get; set; }

        public virtual Product Product { get; set; }

        //foreign key user
        public virtual ApplicationUser User { get; set; }

    }
}
