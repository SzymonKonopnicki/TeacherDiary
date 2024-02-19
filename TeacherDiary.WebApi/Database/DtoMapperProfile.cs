// Ignore Spelling: Dto Api

using AutoMapper;
using System.Linq.Expressions;
using TeacherDiary.WebApi.Database.Dtos;
using TeacherDiary.WebApi.Database.Entities;

namespace TeacherDiary.WebApi.Database
{
    public class DtoMapperProfile : Profile
    {
        public DtoMapperProfile()
        {
            CreateMap<PersonCreateDto, Person>().ReverseMap();
            CreateMap<PersonDto, Person>().ReverseMap();
            CreateMap<PersonUpdateDto, Person>().ReverseMap();

            CreateMap<TicketCreateDto, Ticket>().ReverseMap();
            CreateMap<TicketDto, Ticket>().ReverseMap();
            CreateMap<TicketUpdateDto, Ticket>().ReverseMap();

        }
    }
}
