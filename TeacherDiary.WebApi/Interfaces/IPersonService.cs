// Ignore Spelling: Api

using TeacherDiary.WebApi.Database.Dtos;
using TeacherDiary.WebApi.Database.Entities;

namespace TeacherDiary.WebApi.Interfaces
{
    public interface IPersonService
    {
        public ICollection<PersonDto> Persons();
        public PersonDto PersonById(int id);
        public PersonDto PersonByName(string name);
        public PersonCreateDto PersonAdd(PersonCreateDto person);
        public void PersonRemoveById(int id);
        public void PersonRemoveByName(string name);
        public void PersonEdit(PersonUpdateDto person);

    }
}
