using Microsoft.AspNetCore.Mvc;
using TeacherDiary.WebApi.Database.Dtos;
using TeacherDiary.WebApi.Interfaces;

namespace TeacherDiary.WebApi.Controllers
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
        public ActionResult TicketAdd([FromBody] TicketDto ticket)
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
        public ActionResult TicketEdit([FromBody] TicketDto ticket)
        {
            _ticketService.TicketEdit(ticket);

            return Ok();
        }

    }
}
