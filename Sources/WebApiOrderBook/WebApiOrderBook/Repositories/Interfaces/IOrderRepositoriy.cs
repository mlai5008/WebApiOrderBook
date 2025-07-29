using WebApiOrderBook.Models;

namespace WebApiOrderBook.Repositories.Interfaces
{
    public interface IOrderRepositoriy
    {
        Task<IEnumerable<Order>> GetAllOrderAsync();
        Task<Order?> AddOrderAsync(Order order, Book book);
    }
}
