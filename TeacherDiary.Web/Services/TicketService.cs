using Microsoft.AspNetCore.Components;
using TeacherDiary.Web.Interfaces;
using TeacherDiary.WebApi.Database.Dtos;

namespace TeacherDiary.Web.Services
{
    public class TicketService : ITicketService
    {
        private readonly HttpClient _httpClient;
        private readonly NavigationManager _manager;

        public TicketService(HttpClient httpClient, NavigationManager manager)
        {
            _httpClient = httpClient;
            _manager = manager;
        }

        public async Task<TicketDto> GetTicketByName(string name)
        {
            try
            {
                var ticket = await _httpClient.GetFromJsonAsync<TicketDto>($"/api/Ticket/{name}");

                return ticket;
            }
            catch (Exception msg)
            {
                //some log

                throw new Exception(msg.Message);
            }
        }

        public async Task<IEnumerable<TicketDto>> GetTickets()
        {
            try
            {
                var tickets = await _httpClient.GetFromJsonAsync<IEnumerable<TicketDto>>("/api/Ticket");

                return tickets;
            }
            catch (Exception msg)
            {
                //some log

                throw new Exception(msg.Message);
            }
        }

        public async Task UpdateTicket(TicketDto ticketDto)
        {
            try
            {
                var respond = await _httpClient.PutAsJsonAsync<TicketDto>($"api/ticket", ticketDto);

                if (respond.IsSuccessStatusCode)
                {
                    _manager.NavigateTo(_manager.Uri, true);
                }
            }
            catch (Exception)
            {
                //some log

                throw new Exception();
            }
        }
    }
}
