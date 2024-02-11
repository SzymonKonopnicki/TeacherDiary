using AutoMapper;
using System.Linq.Expressions;
using TeacherDiary.WebApi.Database.Dtos;
using TeacherDiary.WebApi.Database.Entities;

namespace TeacherDiary.WebApi.Database
{
    public class DtoMapperProfile : Profile
    {
        protected internal DtoMapperProfile()
        {
            CreateMap<PersonCreateDto, Person>();
            CreateMap<PersonDto, Person>();
            CreateMap<PersonUpdateDto, Person>();
        }
    }
}
