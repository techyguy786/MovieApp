using AutoMapper;
using MovieApp.DTOs;
using MovieApp.Models;

namespace MovieApp.App_Start
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            Mapper.CreateMap<Customer, CustomerDTO>();
            Mapper.CreateMap<CustomerDTO, Customer>()
                .ForMember(c => c.Id, opt => opt.Ignore());

            Mapper.CreateMap<Movie, MovieDTO>();
            Mapper.CreateMap<MovieDTO, Movie>()
                .ForMember(c => c.Id, opt => opt.Ignore());
        }
    }
}