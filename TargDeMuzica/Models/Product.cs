using System.ComponentModel.DataAnnotations;

namespace TargDeMuzica.Models
{
    public class Product
    {
        [Key]
        public int ProductID { get; set; }
        public string ProductName { get; set; }
        public string ProductDescription { get; set; }
      
        public List<string> ProductGenres { get; set; }
        
        
        //foreign key MusicSuport
        public int MusicSuportID{ get; set; }
        public virtual MusicSuport MusicSuport { get; set; }

        //foreign key Artist
        public int ArtistID { get; set; }
        public virtual Artist Artist { get; set; }
        //many to many products - carts
        public virtual ICollection<Cart> Carts { get; set; }
        //vector review
        public ICollection<Review> Reviews { get; set; }
    }
}
