using Microsoft.EntityFrameworkCore;
using WebApiOrderBook.Data;
using WebApiOrderBook.Models;
using WebApiOrderBook.Repositories.Interfaces;

namespace WebApiOrderBook.Repositories
{
    public class OrderRepositoriy : IOrderRepositoriy
    {
        private readonly ShopDbContext _context;

        public OrderRepositoriy(ShopDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Order>> GetAllOrderAsync()
        {
            if (_context.Orders == null)
            {
                return await Task.FromResult<IEnumerable<Order>>(default);
            }

            return await _context.Orders.Include(b => b.Books).ToListAsync();
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
    }
}
