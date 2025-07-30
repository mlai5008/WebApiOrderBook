namespace WebApiOrderBook.Models
{
    public class Book
    {
        #region Properties
        public Guid Id { get; set; }
        public string Title { get; set; }
        public string Summary { get; set; }
        public DateTime StartDate { get; set; }
        public Guid OrderId { get; set; }
        public Order Order { get; set; } 
        #endregion
    }
}
