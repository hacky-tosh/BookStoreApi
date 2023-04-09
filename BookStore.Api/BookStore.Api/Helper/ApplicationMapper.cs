using AutoMapper;
using BookStore.Api.Folder;
using BookStore.Api.Models;

namespace BookStore.Api.Helper
{
    public class ApplicationMapper : Profile
    {
        public ApplicationMapper()
        {
            CreateMap<Book, BookModel>().ReverseMap();
        }
    }
}