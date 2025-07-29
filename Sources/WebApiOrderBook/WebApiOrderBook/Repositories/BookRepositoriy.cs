using Microsoft.EntityFrameworkCore;
using WebApiOrderBook.Data;
using WebApiOrderBook.Models;
using WebApiOrderBook.Repositories.Interfaces;

namespace WebApiOrderBook.Repositories
{
    public class BookRepositoriy : IBookRepositoriy
    {
        private readonly ShopDbContext _context;

        public BookRepositoriy(ShopDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Book>> GetAllBookAsync()
        {
            if (_context.Books == null)
            {                
                return await Task.FromResult<IEnumerable<Book>>(default);
            }

            return await _context.Books.Include(b => b.Order).ToListAsync();           
        }

        public async Task<Book?> GetBookByIdAsync(Guid id)
        {
            if (_context.Books == null)
            {
                return await Task.FromResult<Book>(default);
            }

            return await _context.Books.Include(b => b.Order).FirstOrDefaultAsync(m => m.Id == id);

        }

        public async Task<Book?> AddBookAsync(Book book)
        {
            if (_context.Books == null)
            {
                return await Task.FromResult<Book>(default);
            }
            _context.Books.Add(book);
            await _context.SaveChangesAsync();
            return book;
        }
    }
}
