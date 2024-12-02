namespace BooksShop.Models
{
    public class BookCartModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public decimal Price { get; set; }
        public int Discount { get; set; }
        public bool InStock { get; set; }
        public string? ImageUrl { get; set; }
        public int Quantity { get; set; }
        public int CountToBuy { get; set; }
    }
}
