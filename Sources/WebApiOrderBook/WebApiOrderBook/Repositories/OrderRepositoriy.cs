using Microsoft.EntityFrameworkCore;
using WebApiOrderBook.Data;
using WebApiOrderBook.Models;
using WebApiOrderBook.Repositories.Interfaces;

namespace WebApiOrderBook.Repositories
{
    public class OrderRepositoriy : IOrderRepositoriy
    {
        #region Fields
        private readonly ShopDbContext _context;
        #endregion

        #region Сonstructor
        public OrderRepositoriy(ShopDbContext context)
        {
            _context = context;
        }
        #endregion

        #region Methods
        public async Task<IEnumerable<Order>> GetAllOrderAsync()
        {
            if (_context.Orders == null)
            {
                return await Task.FromResult<IEnumerable<Order>>(default);
            }

            return await _context.Orders.Include(b => b.Books).ToListAsync();
        }

        public async Task<IEnumerable<Order>> GetFilteredOrdersAsync(int number, DateTime data)
        {
            if (_context.Orders == null)
            {
                return await Task.FromResult<IEnumerable<Order>>(default);
            }

            var query = _context.Orders.AsQueryable();

            if (number != default)
            {
                query = query.Where(d => d.Number == number);
            }

            if (data != default)
            {
                query = query.Where(d => d.Data == data);
            }

            return await query.Include(b => b.Books).ToListAsync();
        }

        public async Task<Order?> AddOrderAsync(Order order, Book book)
        {
            if (_context.Orders == null)
            {
                return await Task.FromResult<Order>(default);
            }
            if (_context.Orders.Any())
            {
                var number = _context.Orders.Max(o => o.Number);
                order.Number = ++number;
            }
            else
            {
                order.Number = 1;
            }
            _context.Orders.Add(order);

            book.Order = order;
            _context.Books.Add(book);
            await _context.SaveChangesAsync();
            return order;
        }

        public async Task<Order?> AddNewBookInOrderAsync(Guid idOrder, Book book)
        {
            if (_context.Orders == null || _context.Books    == null)
            {
                return await Task.FromResult<Order>(default);
            }

            var order = await _context.Orders.Include(i => i.Books).FirstOrDefaultAsync(o => o.Id == idOrder);

            if (book == null || order == null) 
            {
                return await Task.FromResult<Order>(default);
            }

            _context.Books.Add(book);
            book.Order = order;            
            await _context.SaveChangesAsync();
            return order;
        }
        #endregion
    }
}
