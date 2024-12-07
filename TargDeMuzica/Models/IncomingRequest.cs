using System.ComponentModel.DataAnnotations;

namespace TargDeMuzica.Models
{
    public class IncomingRequest
    {
        [Key]
        public int RequestID { get; set; }

        public bool RequestApproved { get; set; }

        //un vector unde:
        //pe pozitia 0 este produsul vechi
        //pe pozitia 1 este produsul nou
        //idee: cand se afiseaza requestul trebuie afisate
        //ambele produse pentru ca adminul sa vada exact ce s a schimbat
        public ICollection<Product> ProductsToBeReviewed { get; set; }
        public virtual Product Product { get; set; }

        //foreign key user
       // public int UserID { get; set; }

    }
}
