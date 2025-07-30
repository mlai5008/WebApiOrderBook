using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using WebApiOrderBook.Models;
using WebApiOrderBook.Models.Dto;
using WebApiOrderBook.Repositories.Interfaces;

namespace WebApiOrderBook.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BooksController : ControllerBase
    {        
        private readonly IBookRepositoriy _bookRepositoriy;
        private readonly IMapper _mapper;

        public BooksController(IBookRepositoriy bookRepositoriy, IMapper mapper)
        {            
            _bookRepositoriy = bookRepositoriy;
            _mapper = mapper;
        }

        // GET: api/Books
        [HttpGet]
        public async Task<ActionResult<IEnumerable<BookDto>>> GetBooks()
        {
            var books = await _bookRepositoriy.GetAllBookAsync();

            if (books == null)
            {
                return NotFound();
            }
            var booksDto = _mapper.Map<IEnumerable<BookDto>>(books);
            return Ok(booksDto);
        }

        // GET: api/Books/73C3C66C-A8E4-480C-B642-A9F3837F922C
        [HttpGet("{id}")]
        public async Task<ActionResult<BookDto>> GetBook(Guid id)
        {
            var book = await _bookRepositoriy.GetBookByIdAsync(id);

            if (book == null)
            {
                return NotFound();
            }
            var bookDto = _mapper.Map<BookDto>(book);
            return bookDto;
        }

        // GET: api/Books/Search
        [HttpGet]
        [Route("Search")]        
        public async Task<ActionResult<BookDto>> GetFilteredBook(string title, DateTime startDate)
        {
            var books = await _bookRepositoriy.GetFilteredBooks(title, startDate);
            if (books == null)
            {
                return NotFound();
            }
            var bookDto = _mapper.Map<IEnumerable<BookDto>>(books);
            return Ok(bookDto);            
        }

        // POST: api/Books
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<BookDto>> PostBook(string title, string summary, DateTime startDate)
        {
            var book = new Book() { Title = title, Summary = summary, StartDate = startDate };
           
            var newBook = await _bookRepositoriy.AddBookAsync(book);

            if (newBook == null)
            {
                return Problem("Entity set book is null.");
            }
            var bookDto = _mapper.Map<BookDto>(newBook);
            return CreatedAtAction("GetBook", new { id = bookDto.Id }, bookDto);
        }        
    }
}
