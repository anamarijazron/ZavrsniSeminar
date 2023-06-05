namespace Zavrsni.Rad.AnamarijaZron.Models
{
    public class ShoppingCart
    {
        public int ProductId { get; set; }
        public Product Product { get; set; }
        public int NumberOfItems { get; set; }
    }
}