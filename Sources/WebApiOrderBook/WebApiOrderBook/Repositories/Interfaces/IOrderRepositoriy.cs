using WebApiOrderBook.Models;

namespace WebApiOrderBook.Repositories.Interfaces
{
    public interface IOrderRepositoriy
    {
        Task<IEnumerable<Order>> GetAllOrderAsync();
        Task<IEnumerable<Order>> GetFilteredOrders(int number, DateTime data);
        Task<Order?> AddOrderAsync(Order order, Book book);
    }
}
