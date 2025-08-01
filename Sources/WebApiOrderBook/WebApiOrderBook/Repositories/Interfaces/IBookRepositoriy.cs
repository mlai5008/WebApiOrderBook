﻿using WebApiOrderBook.Models;

namespace WebApiOrderBook.Repositories.Interfaces
{
    public interface IBookRepositoriy
    {
        #region Methods
        Task<IEnumerable<Book>> GetAllBookAsync();
        Task<Book?> GetBookByIdAsync(Guid id);
        Task<IEnumerable<Book>> GetFilteredBooks(string title, DateTime startDate);
        Task<Book?> AddBookAsync(Book book); 
        #endregion
    }
}
