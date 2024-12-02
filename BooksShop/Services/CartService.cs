using BooksShop.Data;
using BooksShop.Extensions;

namespace BooksShop.Services
{
    public interface ICartService
    {
        int GetCount();
        void Append(int id, int count = 1);
    }
    public class CartService : ICartService
    {
        private readonly HttpContext httpContext;
        private readonly BooksShopDbContext context;
        public CartService(BooksShopDbContext context, IHttpContextAccessor httpContextAccessor)
        {
            this.httpContext = httpContextAccessor.HttpContext;
            this.context = context;
        }

        public void Append(int id, int count = 1)
        {
            // отримуємо дані з корзини
            var items = httpContext.Session.Get<Dictionary<int, int>>(WebConstants.CART_KEY);

            // якщо корзина порожня, створюємо список
            if (items == null) items = new Dictionary<int, int>();

            // Отримуємо дані про книгу з бази даних
            var book = context.Books.Find(id);

            // Перевіряємо, чи книга існує та чи вона доступна для продажу
            if (book == null || !book.InStock)
            {
                // Якщо книга не існує або не доступна, нічого не робимо
                return;
            }

            // Перевіряємо, чи кількість продуктів, яку користувач хоче додати, доступна
            if (book.Quantity < count)
            {
                // Якщо книги немає в достатній кількості, нічого не робимо
                return;
            }

            // якщо елемент вже в корзині, тоді збільшуємо кількість
            if (items.ContainsKey(id)) items[id] += count;
            // якщо ні, додаємо новий елемент
            else items.Add(id, count);

            // зберігаємо новий список в корзині
            httpContext.Session.Set(WebConstants.CART_KEY, items);
        }

        public int GetCount()
        {
            var items = httpContext.Session.Get<Dictionary<int, int>>(WebConstants.CART_KEY);

            // якщо корзина порожня, створюємо список
            if (items == null) return 0;

            return items.Count;
        }
    }
}
