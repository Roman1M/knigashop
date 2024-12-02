using AutoMapper;
using BooksShop.Data.Entities;
using BooksShop.Models;

namespace BooksShop
{
    public class MapperProfile : Profile
    {
        public MapperProfile()
        {            
            CreateMap<BookFormModel, Book>().ReverseMap();            
            CreateMap<Book, BookCartModel>();            
        }
    }
}
