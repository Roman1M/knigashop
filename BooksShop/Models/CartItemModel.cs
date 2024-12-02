using System.Security.Policy;

namespace BooksShop.Models
{
    public class CartItemModel
    {
        public int BookId { get; set; }        
        public int CountToBuy { get; set; }
    }
}
