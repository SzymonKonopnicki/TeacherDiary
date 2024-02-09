using Microsoft.EntityFrameworkCore;
using TeacherDiary.WebApi.Database;
using TeacherDiary.WebApi.Database.Entities;
using TeacherDiary.WebApi.Interfaces;

namespace TeacherDiary.WebApi.Services
{
    //TODO:
    //1. Obsługiwanie wyjątków gdzie nie znalazło nam x rzeczy
    //2. Po utwrzoeniu potrzebna jest jakaś informacja co, gdzie, jak, kiedy...
    //3. Po usunięciu potrzebna jest jakaś informacja co, gdzie, jak, kiedy...
    //4. Poprawić edytowanie klientów nie powinno wyglądać tak jak teraz i dodać info co, gdzie, jak, kiedy...
    public class PersonService : IPersonService
    {
        private readonly DiaryContext _dbContext;

        public PersonService(DiaryContext dbContext)
        {
            _dbContext = dbContext;
        }

        public ICollection<Person> Persons()
        {
            var persons = _dbContext.Persons.ToList();
            return persons;
        }

        public Person PersonById(int id)
        {
            var person = _dbContext.Persons.Where(x => x.Id == id).FirstOrDefault();
            return person;
        }

        public Person PersonByName(string name)
        {
            var person = _dbContext.Persons.Where(x => x.Name.ToLower() == name.ToLower()).FirstOrDefault(); 
            throw new NotImplementedException();
        }

        public void PersonAdd(Person person)
        {
            _dbContext.Persons.Add(person);
            _dbContext.SaveChanges();
        }

        public void PersonRemoveById(int id)
        {
            var person = _dbContext.Persons.Where(x => x.Id == id).FirstOrDefault();
            _dbContext.Persons.Remove(person);
        }
        
        public void PersonRemoveByName(string name)
        {
            var person = _dbContext.Persons.Where(x => x.Name == name).FirstOrDefault();
            _dbContext.Persons.Remove(person);
        }

        public void PersonEdit(Person person)
        {
            var personDb = _dbContext.Persons.Where(x => x.Id == person.Id).FirstOrDefault();

            personDb.Name = person.Name;
            personDb.Surname = person.Surname;
            personDb.Email = person.Email;
            personDb.Phone = person.Phone;
            personDb.Agreement = person.Agreement;
            personDb.Comments = person.Comments;
            personDb.Tickets = person.Tickets;
        }
    }
}
