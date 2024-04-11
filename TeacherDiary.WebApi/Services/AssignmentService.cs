using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.Net.Sockets;
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

            var ticket = _dbContext.TicketsForUse
                .FirstOrDefault(x => x.Name.ToLower() == ticketName.ToLower());

            if (person == null || ticket == null) 
            {
                throw new Exception("Nie odnaleziono spróbuj ponownie.");
            }

            person.TicketsForUse = new TicketForUse()
            {
                Name = ticket.Name,
                Price = ticket.Price,
                EntryQuantity = ticket.EntryQuantity,
                ValidFrom = DateTime.Today,
                ValidTo = DateTime.Today.AddMonths(1),
                Active = true,
                AvailableEntryQuantity = ticket.EntryQuantity
            };

            _dbContext.SaveChanges();
        }

        public void AssignTicketToPerson(string personMail)
        {
            var person = _dbContext.Persons
                .Include(x => x.TicketsForUse)
                .FirstOrDefault(x => x.Email.ToLower() == personMail.ToLower());

            if (person == null || person.TicketsForUse == null)
            {
                throw new Exception("Nie odnaleziono spróbuj ponownie.");
            }

            person.TicketsForUse = null;
            
            _dbContext.SaveChanges();
        }
    }
}
