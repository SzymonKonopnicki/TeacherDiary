// Ignore Spelling: Api

using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TeacherDiary.WebApi.Database.Dtos;
using TeacherDiary.WebApi.Database.Entities;
using TeacherDiary.WebApi.Interfaces;
using TeacherDiary.WebApi.Services;

namespace TeacherDiary.WebApi.Controllers
{
    //TODO:
    //1. Obsługa wyjątków
    //2. Post ogarnąć
    [Route("api/[controller]")]
    [ApiController]
    public class PersonController : ControllerBase
    {
        public readonly IPersonService _personService;

        public PersonController(IPersonService personService)
        {
            _personService = personService;
        }

        [HttpGet]
        public ActionResult<ICollection<PersonDto>> GetPersons()
        {
            var persons = _personService.Persons();

            return Ok(persons);
        }

        [HttpGet("{id:int}")]
        public ActionResult<PersonDto> GetPersonById([FromRoute] int id)
        {
            var person = _personService.PersonById(id);

            return Ok(person);
        }

        [HttpGet("{name}")]
        public ActionResult<PersonDto> GetPersonByName([FromRoute] string name)
        {
            var person = _personService.PersonByName(name);

            return Ok(person);
        }

        [HttpPost]
        public ActionResult PersonAdd([FromBody] PersonCreateDto person)
        {
            var CretePerson = _personService.PersonAdd(person);

            return Created("/api/person/" + person.Name, CretePerson);
        }

        [HttpDelete("{id:int}")]
        public ActionResult PersonDeleteById([FromRoute] int id)
        {
            _personService.PersonRemoveById(id);

            return Ok();
        }

        [HttpDelete("{name}")]
        public ActionResult PersonDeleteByName([FromRoute] string name)
        {
            _personService.PersonRemoveByName(name);

            return Ok();
        }

        [HttpPut]
        public ActionResult PersonEdit([FromBody] PersonUpdateDto person)
        {
            _personService.PersonEdit(person);

            return Ok();
        }
    }
}
