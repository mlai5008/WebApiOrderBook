using Microsoft.EntityFrameworkCore;
using WebApiOrderBook.Models;

namespace WebApiOrderBook.Data
{
    public class ShopDbContext : DbContext
    {
        #region Ctor
        public ShopDbContext(DbContextOptions<ShopDbContext> options) : base(options) { } 
        #endregion

        #region Property
        public DbSet<Order> Orders { get; set; } = default!;
        public DbSet<Book> Books { get; set; } = default!;
        #endregion
    }
}
