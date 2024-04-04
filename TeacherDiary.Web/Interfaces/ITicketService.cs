using TeacherDiary.WebApi.Database.Dtos;

namespace TeacherDiary.Web.Interfaces
{
    public interface ITicketService
    {
        public Task<IEnumerable<TicketDto>> GetTickets();
        public Task<TicketDto> GetTicketByName(string name);
        public Task UpdateTicket(TicketDto ticketDto);
    }
}
