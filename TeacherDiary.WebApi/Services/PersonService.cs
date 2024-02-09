using TeacherDiary.WebApi.Database.Entities;
using TeacherDiary.WebApi.Interfaces;

namespace TeacherDiary.WebApi.Services
{
    public class PersonService : IPersonService
    {
        public ICollection<Person> Persons()
        {
            throw new NotImplementedException();
        }
        public Person PersonById(int id)
        {
            throw new NotImplementedException();
        }
        public Person PersonByName(string name)
        {
            throw new NotImplementedException();
        }
        public void PersonAdd(Person person)
        {
            throw new NotImplementedException();
        }
        public void PersonRemoveById(int id)
        {
            throw new NotImplementedException();
        }
        public void PersonEdit()
        {
            throw new NotImplementedException();
        }
        public void PersonRemoveByName(string name)
        {
            throw new NotImplementedException();
        }
    }
}
