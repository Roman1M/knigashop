using System.ComponentModel.DataAnnotations;

namespace BooksShop.Data.Entities
{
    public class Book
    {
        public int Id { get; set; }        
        public string Name { get; set; }
        public decimal Price { get; set; }
        public int Discount { get; set; }
        public bool InStock { get; set; }        
        public string? ImageUrl { get; set; }
        public int Quantity { get; set; }
        public int Year { get; set; }
        public int CategoryId { get; set; }
        public Category? Category { get; set; }
        public int AuthorId { get; set; }
        public Author? Author { get; set; }
    }
}