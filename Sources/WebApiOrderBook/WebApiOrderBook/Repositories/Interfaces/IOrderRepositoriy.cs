using WebApiOrderBook.Models;

namespace WebApiOrderBook.Repositories.Interfaces
{
    public interface IOrderRepositoriy
    {
        #region Methods
        Task<IEnumerable<Order>> GetAllOrderAsync();
        Task<IEnumerable<Order>> GetFilteredOrdersAsync(int number, DateTime data);
        Task<Order?> AddOrderAsync(Order order, Book book);
        Task<Order?> AddNewBookInOrderAsync(Guid idOrder, Book book);
        #endregion
    }
}
