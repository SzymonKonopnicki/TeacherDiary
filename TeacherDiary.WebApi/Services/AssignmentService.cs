using Microsoft.EntityFrameworkCore;
using TeacherDiary.WebApi.Database;
using TeacherDiary.WebApi.Database.Entities;
using TeacherDiary.WebApi.Exceptions;
using TeacherDiary.WebApi.Interfaces;

namespace TeacherDiary.WebApi.Services
{
    public class AssignmentService : IAssignment
    {
        private readonly DiaryContext _dbContext;
        public AssignmentService(DiaryContext dbContext)
        {
            _dbContext = dbContext;
        }

        public void AssignTicketToPerson(string personMail, string ticketName)
        {
            var person = _dbContext.Persons
                .Include(x => x.TicketsForUse)
                .FirstOrDefault(x => x.Email.ToLower() == personMail.ToLower());

            var ticket = _dbContext.Tickets.FirstOrDefault(x => x.Name.ToLower() == ticketName.ToLower());

            if (person == null || ticket == null) 
            {
                throw new NotFoundException("Nie odnaleziono spróbuj ponownie.");
            }

            if (person.TicketsForUse == null)
            {
                //person.TicketsForUse = new List<TicketForUse>();
                //person.TicketsForUse.Add(ticket);
            }
            else
            {
                //person.Tickets.Add(ticket);
            }

            _dbContext.SaveChanges();
        }
    }
}
