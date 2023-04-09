﻿using Microsoft.EntityFrameworkCore;

namespace BookStore.Api.Folder
{
    public class BookStoreContext:DbContext
    {
        public BookStoreContext(DbContextOptions<BookStoreContext> options)
        :base(options)
        {
            
        }


        public DbSet<Book> Books { get; set; }


     
    }
}
