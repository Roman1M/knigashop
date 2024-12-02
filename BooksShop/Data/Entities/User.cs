using Microsoft.AspNetCore.Identity;

namespace BooksShop.Data.Entities
{
    public class User : IdentityUser
    {
        public DateTime? Birthdate { get; set; }
    }
}
