// Ignore Spelling: Api Dto

using AutoMapper;
using TeacherDiary.WebApi.Database;
using TeacherDiary.WebApi.Database.Dtos;
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
        private readonly IMapper _mapper;

        public PersonService(DiaryContext dbContext, IMapper mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;
        }

        public ICollection<PersonDto> Persons()
        {
            var persons = _dbContext.Persons.ToList();

            var personsDto = _mapper.Map<List<PersonDto>>(persons);

            return personsDto;
        }

        public PersonDto PersonById(int id)
        {
            var person = _dbContext.Persons.Where(x => x.Id == id).FirstOrDefault();

            var personDto = _mapper.Map<PersonDto>(person);

            return personDto;
        }

        public PersonDto PersonByName(string name)
        {
            var person = _dbContext.Persons.Where(x => x.Name.ToLower() == name.ToLower()).FirstOrDefault();

            var personDto = _mapper.Map<PersonDto>(person);

            return personDto;
        }

        public void PersonAdd(PersonCreateDto personCreateDto)
        {
            var person = _mapper.Map<Person>(personCreateDto);

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

        public void PersonEdit(PersonUpdateDto personUpdateDto)
        {
            var personDb = _dbContext.Persons.Where(x => x.Email == personUpdateDto.Email).FirstOrDefault();

            personDb.Name = personUpdateDto.Name;
            personDb.Surname = personUpdateDto.Surname;
            personDb.Email = personUpdateDto.Email;
            personDb.Phone = personUpdateDto.Phone;
            personDb.Agreement = personUpdateDto.Agreement;
            personDb.Comments = personUpdateDto.Comments;
            personDb.Tickets = personUpdateDto.Tickets;
        }
    }
}
