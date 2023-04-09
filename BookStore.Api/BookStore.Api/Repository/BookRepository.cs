using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using BookStore.Api.Folder;
using BookStore.Api.Models;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace BookStore.Api.Repository
{
    public class BookRepository : IBookRepository
    {
        private readonly BookStoreContext _context;
        private readonly IMapper _mapper;
        public BookRepository(BookStoreContext context,IMapper mapper)
        {
            _context = context ;
            _mapper  = mapper ;
        }
        public async Task<List<BookModel>> GetAllBooksAsync()
        {
            // var records = await _context.Books.Select(x=> new BookModel()
            // {
            //     Id = x.Id,
            //     Title = x.Title,
            //     Description = x.Description
            // }).ToListAsync();
            //
            // return records;


            // using automapper 

            var records = await _context.Books.ToListAsync();
            return _mapper.Map<List<BookModel>>(records);

        }

        public async Task<BookModel> GetBookByIdAsync(int id)
        {
            // var records = await _context.Books.Where(x=>x.Id==id).Select(x => new BookModel()
            // {
            //     Id = x.Id,
            //     Title = x.Title,
            //     Description = x.Description
            // }).FirstOrDefaultAsync();
            //
            // return records;

            // using automaper 

            var book = await _context.Books.FindAsync(id);
            return _mapper.Map<BookModel>(book);



        }


        public async Task<int> AddBookAsync(BookModel bookModel)
        {
            var book = new Book()
            {
                Title = bookModel.Title,
                Description = bookModel.Description
            };

            _context.Books.Add(book);
            await _context.SaveChangesAsync();
            return book.Id;

        }

        public async Task UpdateBookAsync(int bookId, BookModel bookModel)
        {
            var book = await _context.Books.FindAsync(bookId);
            if (book != null)
            {
                book.Title = bookModel.Title;
                book.Description = bookModel.Description;

                await _context.SaveChangesAsync();


            }
        }

        public async Task UpdateBookPatchAsync(int bookId, JsonPatchDocument bookModel)
        {
            var book = await _context.Books.FindAsync(bookId);

            if (book != null)
            {
                bookModel.ApplyTo(book);
                await _context.SaveChangesAsync();
            }

        }


        public async Task DeleteBookAsync(int bookId)
        {
            var book = new Book() { Id = bookId };

            _context.Books.Remove(book);

            await _context.SaveChangesAsync();

        }




    }
}
