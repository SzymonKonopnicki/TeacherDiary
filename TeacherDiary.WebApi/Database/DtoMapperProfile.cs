using AutoMapper;
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

            CreateMap<TicketDto, TicketForUse>().ReverseMap();
        }
    }
}
