using System.ComponentModel.DataAnnotations;
namespace TargDeMuzica.Models
{
    public class Review
    {
        [Key]
        public int ReviewId { get; set; }
        public string ReviewContent { get; set; }
        public DateTime ReviewDate { get; set; } 
        public int StarRating { get; set; }

        public virtual Product Product { get; set; }

        //foreign key user
        //public int UserID { get; set; }

    }
}
