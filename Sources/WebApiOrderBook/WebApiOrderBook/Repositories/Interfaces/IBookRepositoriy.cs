using WebApiOrderBook.Models;

namespace WebApiOrderBook.Repositories.Interfaces
{
    public interface IBookRepositoriy
    {
        Task<IEnumerable<Book>> GetAllBookAsync();
        Task<Book?> GetBookByIdAsync(Guid id);
        Task<Book?> AddBookAsync(Book book);
    }
}
