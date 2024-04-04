using TeacherDiary.Web.Models;
using TeacherDiary.WebApi.Database.Dtos;

namespace TeacherDiary.Web.Interfaces
{
    public interface IPersonService
    {
        public Task<IEnumerable<PersonDto>> GetPersons();
        public Task<PersonDto> GetPersonByEmail(string mail);
        public Task<PersonDto> GetPersonById(int id);
        public Task EditPersonByMail(PersonUpdateDto personUpdateDto);
        public Task AddPerson(PersonCreateDto personCreateDto);
        public Task RemovePersonByName(string name);
        public Task AssignTicketToPerson(AssigmentModel assigmentModel);

    }
}
