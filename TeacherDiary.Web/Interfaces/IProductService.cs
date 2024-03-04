using TeacherDiary.WebApi.Database.Dtos;

namespace TeacherDiary.Web.Interfaces
{
    public interface IProductService
    {
        public Task<IEnumerable<PersonDto>> GetPersons();
        public Task<PersonDto> GetPerson(string name);
        public Task<PersonDto> GetPerson(int id);
    }
}
