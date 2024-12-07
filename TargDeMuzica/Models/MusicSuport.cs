using System.ComponentModel.DataAnnotations;

namespace TargDeMuzica.Models
{
    public class MusicSuport
    {
        [Key]
        public int MusicSuportID { get; set; }
        public int MusicSuportName { get; set;}
        public virtual Product Product { get; set; }
    }
}
