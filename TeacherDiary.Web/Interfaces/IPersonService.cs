using TeacherDiary.WebApi.Database.Dtos;

namespace TeacherDiary.Web.Interfaces
{
    public interface IPersonService
    {
        public Task<IEnumerable<PersonDto>> GetPersons();
        public Task<PersonDto> GetPersonByName(string name);
        public Task<PersonDto> GetPersonById(int id);
    }
}
