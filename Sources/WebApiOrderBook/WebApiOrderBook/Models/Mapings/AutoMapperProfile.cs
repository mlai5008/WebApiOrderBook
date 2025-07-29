using AutoMapper;
using WebApiOrderBook.Models.Dto;

namespace WebApiOrderBook.Models.Mapings
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            //CreateMap<Book, BookDto>()
            //    .ForMember(dest => dest.Title, opt => opt.MapFrom(src => src.Title))
            //    .ForMember(dest => dest.Summary, opt => opt.MapFrom(src => src.Summary))
            //    .ForMember(dest => dest.StartDate, opt => opt.MapFrom(src => src.StartDate)).ReverseMap();

            //.ForMember(dest => dest.UserId, opt => opt.MapFrom(src => src.UserId))
            //.ForMember(dest => dest.FirstName, opt => opt.MapFrom(src => src.FirstName))
            //.ForMember(dest => dest.LastName, opt => opt.MapFrom(src => src.LastName))
            //.ForMember(dest => dest.Email, opt => opt.MapFrom(src => src.Email))
            //.ForMember(dest => dest.BirthYear, opt => opt.MapFrom(src => src.Birthday.Year))
            //.ForMember(dest => dest.BirthMonth, opt => opt.MapFrom(src => src.Birthday.Month))
            //.ForMember(dest => dest.BirthDay, opt => opt.MapFrom(src => src.Birthday.Day))
            //.ForMember(dest => dest.OccupationName, opt => opt.Ignore())

            CreateMap<Book, BookDto>().ReverseMap();
            CreateMap<Order, OrderDto>().ReverseMap();
        }


    }
}
