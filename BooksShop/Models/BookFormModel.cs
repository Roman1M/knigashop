using BooksShop.Data.Entities;
using System.ComponentModel.DataAnnotations;

namespace BooksShop.Models
{
    public class BookFormModel
    {               
        public int Id { get; set; }
        public string Name { get; set; }
        public decimal Price { get; set; }
        public int Discount { get; set; }
        public int Quantity { get; set; }
        //public bool InStock { get; set; }
        [Url]
        public string? ImageUrl { get; set; }        
        public int Year { get; set; }
        public int CategoryId { get; set; }        
        public int AuthorId { get; set; }        
    }
}
