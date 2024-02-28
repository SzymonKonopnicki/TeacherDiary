using TeacherDiary.WebApi.Database.Dtos;

namespace TeacherDiary.Web.Interfaces
{
    public interface IProductService
    {
        public Task<IEnumerable<PersonDto>> GetPerson();
    }
}
