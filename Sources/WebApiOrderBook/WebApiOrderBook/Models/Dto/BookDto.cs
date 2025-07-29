namespace WebApiOrderBook.Models.Dto
{
    public class BookDto
    {
        public Guid Id { get; set; }
        public string Title { get; set; }
        public string Summary { get; set; }
        public DateTime StartDate { get; set; }
        public Order Order { get; set; } = new Order();
    }
}
