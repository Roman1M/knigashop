using BooksShop.Data;
using BooksShop.Data.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Security.Principal;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;

namespace BooksShop.Data
{
    public class BooksShopDbContext : IdentityDbContext<User>
    {
        public BooksShopDbContext()
        {
            
        }
        public BooksShopDbContext(DbContextOptions options) : base(options) { }
        
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Book>().Property(x=>x.Quantity).HasDefaultValue(0);

            modelBuilder.Entity<Category>().HasData(new[]
            {
                new Category() { Id = 1, Name = "Дитяча"},
                new Category() { Id = 2, Name = "Художня"},
                new Category() { Id = 3, Name = "Навчальна"},
                new Category() { Id = 4, Name = "Культура"},
                new Category() { Id = 5, Name = "Дозвілля"},
                new Category() { Id = 6, Name = "Мова"}
            });
            //children's literature     дитяча література
            //Fiction                   художня література
            //educational literature    навчальна література
            //culture                   культура
            //leisure                   дозвілля
            //language                  мова

            modelBuilder.Entity<Author>().HasData(new[]
            {
                new Author() { Id = 1, Name = "Дерманський Сашко"},
                new Author() { Id = 2, Name = "Ролінґ Дж.К."},
                new Author() { Id = 3, Name = "Олефір Юлія"},
                new Author() { Id = 4, Name = "Костенко Ліна"},
                new Author() { Id = 5, Name = "Федієнко Василь"},
                new Author() { Id = 6, Name = "Протеро Стівен"},
                new Author() { Id = 7, Name = "Кентербері Дейв"},
                new Author() { Id = 8, Name = "Дубчак Ольга"}
            });

            modelBuilder.Entity<Book>().HasData(new[]
            {
                new Book() { Id = 1, Name = "Малим дітям про все на світі", Price = 470, Discount = 5, InStock = true, 
                    ImageUrl = "https://bookopt.com.ua/media/catalog/product/cache/image/850x/m/a/malim-ditjam-pro-vse-na-sviti-enciklopedija-v-kazkah_2.webp", 
                    Year = 2021, CategoryId = 1, AuthorId = 1},
                new Book() { Id = 2, Name = "Лізла жаба по драбині", Price = 320, Discount = 10, InStock = true,
                    ImageUrl = "https://bookopt.com.ua/media/catalog/product/cache/image/850x/l/i/lizla-zhaba-po-drabini.webp",
                    Year = 2023, CategoryId = 1, AuthorId = 1},
                new Book() { Id = 3, Name = "Гаррі Поттер і філософський камінь (Частина 1)", Price = 320, Discount = 0, InStock = true,
                    ImageUrl = "https://bookopt.com.ua/media/catalog/product/cache/image/285x395/g/a/garri-potter-i-filosovs-kij-kamin-chastina-1_3.webp",
                    Year = 2020, CategoryId = 1, AuthorId = 2},
                new Book() { Id = 4, Name = "Гаррі Поттер і таємна кімната (Частина 2)", Price = 320, Discount = 5, InStock = true,
                    ImageUrl = "https://bookopt.com.ua/media/catalog/product/cache/image/850x/g/a/garri-potter-i-taemna-kimnata-chastina-2_3.webp",
                    Year = 2021, CategoryId = 1, AuthorId = 2},
                new Book() { Id = 5, Name = "Казковий ліс", Price = 400, Discount = 15, InStock = false,
                    ImageUrl = "https://bookopt.com.ua/media/catalog/product/cache/image/850x/k/a/kazkovij-lis-prigodi-enotiv-beshketnikiv.webp",
                    Year = 2021, CategoryId = 1, AuthorId = 3},
                new Book() { Id = 6, Name = "Триста поезій", Price = 350, Discount = 0, InStock = true,
                    ImageUrl = "https://bookopt.com.ua/media/catalog/product/cache/image/850x/3/0/300-poezij_3.webp",
                    Year = 2012, CategoryId = 2, AuthorId = 4},
                new Book() { Id = 7, Name = "Маруся Чурай", Price = 350, Discount = 0, InStock = true,
                    ImageUrl = "https://bookopt.com.ua/media/catalog/product/cache/image/850x/m/a/marusja-churaj_7.webp",
                    Year = 2018, CategoryId = 2, AuthorId = 4},
                new Book() { Id = 8, Name = "Ми готуємось до школи", Price = 175, Discount = 0, InStock = true,
                    ImageUrl = "https://bookopt.com.ua/media/catalog/product/cache/image/850x/m/i/mi-gotuemos-do-shkoli-krok-do-shkoli_2.webp",
                    Year = 2024, CategoryId = 3, AuthorId = 5},
                new Book() { Id = 9, Name = "Буквар для дошкільнят", Price = 140, Discount = 5, InStock = true,
                    ImageUrl = "https://bookopt.com.ua/media/catalog/product/cache/image/850x/b/u/bukvar-dlja-doshkil-njat-chitajlik-a4-korablik_4.webp",
                    Year = 2015, CategoryId = 3, AuthorId = 5},
                new Book() { Id = 10, Name = "Вісім релігій, що панують у світі", Price = 250, Discount = 15, InStock = true,
                    ImageUrl = "https://bookopt.com.ua/media/catalog/product/cache/image/285x395/v/i/visim-religij-scho-panujut-u-sviti-chomu-ihni-vidminnosti-majut-znachennja_8.webp",
                    Year = 2022, CategoryId = 4, AuthorId = 6},
                new Book() { Id = 11, Name = "Бушкрафт", Price = 290, Discount = 0, InStock = false,
                    ImageUrl = "https://bookopt.com.ua/media/catalog/product/cache/image/850x/b/u/bushkraft-najvazhlivishi-navichki-dlja-vizhivannja-v-dikij-prirodi_1.webp",
                    Year = 2023, CategoryId = 5, AuthorId = 7},
                new Book() { Id = 12, Name = "Бачити українською", Price = 350, Discount = 0, InStock = true,
                    ImageUrl = "https://bookopt.com.ua/media/catalog/product/cache/image/285x395/b/a/bachiti-ukrains-koju_2.webp",
                    Year = 2024, CategoryId = 5, AuthorId = 8},
                new Book() { Id = 13, Name = "Чути українською", Price = 290, Discount = 0, InStock = true,
                    ImageUrl = "https://bookopt.com.ua/media/catalog/product/cache/image/850x/c/h/chuti-ukrains-koju-u-sviti-zvuki-u-i-bukv_2.webp",
                    Year = 2024, CategoryId = 5, AuthorId = 8}
            });
        }
        public DbSet<Book> Books { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Author> Authors { get; set; }
    }
}
