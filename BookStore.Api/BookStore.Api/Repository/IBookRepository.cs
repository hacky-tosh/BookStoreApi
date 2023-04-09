using BookStore.Api.Models;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.JsonPatch;

namespace BookStore.Api.Repository
{
    public interface IBookRepository
    {
          Task<List<BookModel>> GetAllBooksAsync();
          Task<BookModel> GetBookByIdAsync(int id);
          Task<int> AddBookAsync(BookModel bookModel);

          Task UpdateBookAsync(int bookId, BookModel bookModel);
          Task UpdateBookPatchAsync(int bookId, JsonPatchDocument bookModel);

          Task DeleteBookAsync(int bookId);
    }
}
