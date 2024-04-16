using AutoMapper;
using Microsoft.EntityFrameworkCore;
using TeacherDiary.WebApi.Database;
using TeacherDiary.WebApi.Database.Dtos;
using TeacherDiary.WebApi.Database.Entities;
using TeacherDiary.WebApi.Exceptions;
using TeacherDiary.WebApi.Interfaces;

namespace TeacherDiary.WebApi.Services
{
    public class TicketService : ITicketService
    {
        private readonly DiaryContext _dbContext;
        private readonly IMapper _mapper;

        public TicketService(DiaryContext diaryContext, IMapper mapper)
        {
            _dbContext = diaryContext;
            _mapper = mapper;
        }

        public ICollection<TicketDto> Tickets()
        {
            var tickets = _dbContext.TicketsForUse.ToList();

            if (tickets == null) 
            {
                throw new NotFoundException($"Nie odnaleziono usług.");
            }

            var ticketsDto = _mapper.Map<List<TicketDto>>(tickets);

            return ticketsDto;
        }

        public TicketDto TicketById(int id)
        {
            var ticket = _dbContext.TicketsForUse.FirstOrDefault(x => x.Id == id);

            if (ticket == null)
            {
                throw new NotFoundException($"Nie odnaleziono usługi.");
            }

            var ticketDto = _mapper.Map<TicketDto>(ticket);

            return ticketDto;
        }

        public TicketDto TicketByName(string name)
        {
            var ticket = _dbContext.TicketsForUse.FirstOrDefault(x => x.Name.ToLower() == name.ToLower());

            if (ticket == null)
            {
                throw new NotFoundException($"Nie odnaleziono usługi.");
            }

            var ticketDto = _mapper.Map<TicketDto>(ticket);

            return ticketDto;
        }

        public TicketDto TicketAdd(TicketDto ticketCreateDto)
        {
            var ticket = _mapper.Map<TicketForUse>(ticketCreateDto);

            _dbContext.TicketsForUse.Add(ticket);

            _dbContext.SaveChanges();

            var ticketDto = _mapper.Map<TicketDto>(ticket);

            return ticketDto;
        }
        
        public void TicketRemoveById(int id)
        {
            var ticet = _dbContext.TicketsForUse.FirstOrDefault(x => x.Id == id);

            if (ticet == null)
            {
                throw new NotFoundException($"Nie odnaleziono usługi.");
            }

            _dbContext.Remove(ticet);

            _dbContext.SaveChanges();
        }

        public void TicketRemoveByName(string name)
        {
            var ticet = _dbContext.TicketsForUse.FirstOrDefault(x => x.Name.ToLower() == name.ToLower());

            if (ticet == null)
            {
                throw new NotFoundException($"Nie odnaleziono usługi.");
            }

            var person = _dbContext.Persons
                .FirstOrDefault(x => x.TicketForUseId == ticet.Id);
            
            if (person != null) 
            {
                person.TicketsForUse = null;
            }

            _dbContext.Remove(ticet);

            _dbContext.SaveChanges();
        }

        public void TicketEdit(TicketDto ticketUpdateDto)
        {
            var ticketDb = _dbContext.TicketsForUse.Where(x => x.Name == ticketUpdateDto.Name).FirstOrDefault();

            if (ticketDb == null)
            {
                throw new NotFoundException($"Usługa o nazwie: {ticketUpdateDto.Name} nie została odnaleziona.");
            }

            ticketDb.Name = ticketUpdateDto.Name;
            ticketDb.Price = ticketUpdateDto.Price;
            ticketDb.EntryQuantity = ticketUpdateDto.EntryQuantity;

            _dbContext.SaveChanges();
        }

    }
}
