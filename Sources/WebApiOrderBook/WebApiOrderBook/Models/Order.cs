namespace WebApiOrderBook.Models
{
    public class Order
    {
        public Guid Id { get; set; }
        public int Number { get; set; }
        public DateTime Data { get; set; }
        public List<Book> Books { get; set; } = new List<Book>();
    }
}
