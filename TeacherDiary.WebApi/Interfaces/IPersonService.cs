using TeacherDiary.WebApi.Database.Entities;

namespace TeacherDiary.WebApi.Interfaces
{
    public interface IPersonService
    {
        public ICollection<Person> Persons();
        public Person PersonById(int id);
        public Person PersonByName(string name);
        public void PersonAdd(Person person);
        public void PersonRemoveById(int id);
        public void PersonRemoveByName(string name);
        public void PersonEdit();

    }
}
