using System.ComponentModel.DataAnnotations;
using TargDeMuzica.Models;

public class CartItem
{
    [Key]
    public int CartItemId { get; set; }
    public int CartId { get; set; }
    public int ProductId { get; set; }
    public int Quantity { get; set; }

    public virtual Cart Cart { get; set; }
    public virtual Product Product { get; set; }
}