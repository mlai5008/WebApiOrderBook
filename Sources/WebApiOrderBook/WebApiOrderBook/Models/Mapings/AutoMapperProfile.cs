using AutoMapper;
using WebApiOrderBook.Models.Dto;

namespace WebApiOrderBook.Models.Mapings
{
    public class AutoMapperProfile : Profile
    {
        #region Сonstructor
        public AutoMapperProfile()
        {
            CreateMap<Book, BookDto>().ReverseMap();
            CreateMap<Order, OrderDto>().ReverseMap();
        } 
        #endregion
    }
}
