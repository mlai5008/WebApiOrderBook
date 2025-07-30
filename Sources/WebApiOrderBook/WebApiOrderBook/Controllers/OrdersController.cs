using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using WebApiOrderBook.Models;
using WebApiOrderBook.Models.Dto;
using WebApiOrderBook.Repositories.Interfaces;

namespace WebApiOrderBook.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrdersController : ControllerBase
    {
        #region Fields
        private readonly IOrderRepositoriy _orderRepositoriy;
        private readonly IMapper _mapper; 
        #endregion

        #region Сonstructor
        public OrdersController(IOrderRepositoriy orderRepositoriy, IMapper mapper)
        {
            _orderRepositoriy = orderRepositoriy;
            _mapper = mapper;
        } 
        #endregion

        #region Methods
        // GET: api/Orders 
        [HttpGet]
        public async Task<ActionResult<IEnumerable<OrderDto>>> GetOrders()
        {
            var orders = await _orderRepositoriy.GetAllOrderAsync();

            if (orders == null)
            {
                return NotFound();
            }
            var ordersDto = _mapper.Map<IEnumerable<OrderDto>>(orders);
            return Ok(ordersDto);
        }

        // GET: api/Orders/Search
        [HttpGet]
        [Route("Search")]
        public async Task<ActionResult<OrderDto>> GetFilteredOrders(int number, DateTime data)
        {
            var orders = await _orderRepositoriy.GetFilteredOrdersAsync(number, data);
            if (orders == null)
            {
                return NotFound();
            }
            var ordersDto = _mapper.Map<IEnumerable<OrderDto>>(orders);
            return Ok(orders);
        }

        // POST: api/Orders        
        [HttpPost]
        public async Task<ActionResult<OrderDto>> PostOrder(string title, string summary, DateTime startDate)
        {
            var book = new Book() { Title = title, Summary = summary, StartDate = startDate };
            var order = new Order() { Data = DateTime.Now.Date };

            var newOrder = await _orderRepositoriy.AddOrderAsync(order, book);

            if (newOrder == null)
            {
                return Problem("Entity set order is null.");
            }
            var orderDto = _mapper.Map<OrderDto>(newOrder);
            return CreatedAtAction("PostOrder", orderDto);
        }

        [HttpPut]
        public async Task<ActionResult<OrderDto>> AddNewBookInOrder(Guid idOrder, string title, string summary, DateTime startDate)
        {
            var book = new Book() { Title = title, Summary = summary, StartDate = startDate };
            var order = await _orderRepositoriy.AddNewBookInOrderAsync(idOrder, book);
            var orderDto = _mapper.Map<OrderDto>(order);
            return Ok(orderDto);
        }
        #endregion
    }
}
