using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Mvc;
using TeacherDiary.WebApi.Database;
using TeacherDiary.WebApi.Database.Dtos;
using TeacherDiary.WebApi.Interfaces;
using TeacherDiary.WebApi.Services;

#pragma warning disable VSSpell001 // Spell Check
namespace TeacherDiary.WebApi.Controllers
#pragma warning restore VSSpell001 // Spell Check
{
    [Route("api/[controller]")]
    [ApiController]
    public class TicketController : ControllerBase
    {
        private readonly ITicketService _ticketService;

        public TicketController(ITicketService ticketService)
        {
            _ticketService = ticketService;
        }

        [HttpGet]
        public ActionResult<ICollection<TicketDto>> GetTickets()
        {
            var tickets = _ticketService.Tickets();

            return Ok(tickets);
        }

        [HttpGet("{id:int}")]
        public ActionResult<TicketDto> GetTicketById([FromRoute] int id)
        {
            var Ticket = _ticketService.TicketById(id);

            return Ok(Ticket);
        }

        [HttpGet("{name}")]
        public ActionResult<TicketDto> GetTicketByName([FromRoute] string name)
        {
            var Ticket = _ticketService.TicketByName(name);

            return Ok(Ticket);
        }

        [HttpPost]
        public ActionResult TicketAdd([FromBody] TicketCreateDto ticket)
        {
            var creteTicet = _ticketService.TicketAdd(ticket);

            return Created("/api/Ticket/" + ticket.Name, creteTicet);
        }

        [HttpDelete("{id:int}")]
        public ActionResult TicketDeleteById([FromRoute] int id)
        {
            _ticketService.TicketRemoveById(id);

            return Ok();
        }

        [HttpDelete("{name}")]
        public ActionResult TicketDeleteByName([FromRoute] string name)
        {
            _ticketService.TicketRemoveByName(name);

            return Ok();
        }

        [HttpPut]
        public ActionResult TicketEdit([FromBody] TicketUpdateDto ticket)
        {
            _ticketService.TicketEdit(ticket);

            return Ok();
        }

    }
}
