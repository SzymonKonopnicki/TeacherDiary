using Microsoft.AspNetCore.Mvc;
using TeacherDiary.WebApi.Interfaces;

namespace TeacherDiary.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AssignmentController : ControllerBase
    {
        private readonly IAssignment _serviceAssigment;
        public AssignmentController(IAssignment serviceAssigment)
        {
            _serviceAssigment = serviceAssigment;
        }

        [HttpPut]
        public ActionResult TicketForPerson([FromQuery] string personMail, [FromQuery] string ticketName)
        {
            _serviceAssigment.AssignTicketToPerson(personMail, ticketName);

            return Ok();
        }


        [HttpDelete]
        public ActionResult TicketFromPerson([FromQuery] string personMail)
        {
            _serviceAssigment.AssignTicketToPerson(personMail);

            return Ok();
        }

    }
}
