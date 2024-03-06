// Ignore Spelling: Api Dto

using AutoMapper;
using Microsoft.EntityFrameworkCore;
using System;
using TeacherDiary.WebApi.Database;
using TeacherDiary.WebApi.Database.Dtos;
using TeacherDiary.WebApi.Database.Entities;
using TeacherDiary.WebApi.Exceptions;
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
            var persons = _dbContext.Persons
                .Include(x => x.TicketsForUse)
                .ToList();

            if (persons == null)
            {
                throw new NotFoundException($"Osoby z nie odnaleziono.");
            }

            var personsDto = _mapper.Map<List<PersonDto>>(persons);

            return personsDto;
        }

        public PersonDto PersonById(int id)
        {
            var person = _dbContext.Persons
                .Include(x => x.TicketsForUse)
                .Where(x => x.Id == id)
                .FirstOrDefault();

            if (person == null) 
            {
                throw new NotFoundException($"Osoba z ID: {id} nie została odnaleziona.");
            }

            var personDto = _mapper.Map<PersonDto>(person);

            return personDto;
        }

        public PersonDto PersonByName(string name)
        {
            var person = _dbContext.Persons
                .Include(x => x.TicketsForUse)
                .Where(x => x.Name.ToLower() == name.ToLower())
                .FirstOrDefault();

            if (person == null)
            {
                throw new NotFoundException($"Osoba z imieniem: {name} nie została odnaleziona.");
            }

            var personDto = _mapper.Map<PersonDto>(person);

            return personDto;
        }

        public PersonCreateDto PersonAdd(PersonCreateDto personCreateDto)
        {
            var person = _mapper.Map<Person>(personCreateDto);


            var personInDb = _dbContext.Persons
                .Where(x => x.Email == person.Email)
                .FirstOrDefault();


            if (person.Email == personInDb.Email)
            {
                throw new Exception();
            }

            _dbContext.Persons.Add(person);

            _dbContext.SaveChanges();

            return personCreateDto;
        }

        public void PersonRemoveById(int id)
        {
            var person = _dbContext.Persons
                .Where(x => x.Id == id)
                .FirstOrDefault();

            if (person == null)
            {
                throw new NotFoundException($"Osoba z ID: {id} nie została odnaleziona.");
            }

            _dbContext.Persons.Remove(person);
        }

        public void PersonRemoveByName(string name)
        {
            var person = _dbContext.Persons
                .Where(x => x.Name.ToLower() == name.ToLower())
                .FirstOrDefault();

            if (person == null)
            {
                throw new NotFoundException($"Osoba z imieniem: {name} nie została odnaleziona.");
            }

            _dbContext.Persons.Remove(person);
        }

        public void PersonEdit(PersonUpdateDto personUpdateDto)
        {
            var personDb = _dbContext.Persons
                .Where(x => x.Email == personUpdateDto.Email)
                .FirstOrDefault();

            if (personDb == null)
            {
                throw new NotFoundException($"Osoba z mailem: {personUpdateDto.Email} nie została odnaleziona.");
            }

            personDb.Name = personUpdateDto.Name;
            personDb.Surname = personUpdateDto.Surname;
            personDb.Phone = personUpdateDto.Phone;
            personDb.Agreement = personUpdateDto.Agreement;
            personDb.Comments = personUpdateDto.Comments;

            if (personUpdateDto.Email != null)
            {
                personDb.Email = personUpdateDto.Email;
            }
        }
    }
}
