using TeacherDiary.WebApi.Database.Dtos;

namespace TeacherDiary.WebApi.Interfaces
{
    public interface ITicketService
    {
        public ICollection<TicketDto> Tickets();
        public TicketDto TicketById(int id);
        public TicketDto TicketByName(string name);
        public TicketDto TicketAdd(TicketDto person);
        public void TicketRemoveById(int id);
        public void TicketRemoveByName(string name);
        public void TicketEdit(TicketDto person);

    }
}
