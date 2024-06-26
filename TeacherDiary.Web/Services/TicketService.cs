﻿using Microsoft.AspNetCore.Components;
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
            var ticket = await _httpClient.GetFromJsonAsync<TicketDto>($"/api/Ticket/{name}");

            if (ticket == null)
            {
                throw new Exception("Akcja nie udała się. Spróbuj ponownie.");
            }

            return ticket;
        }

        public async Task<IEnumerable<TicketDto>> GetTickets()
        {
            var tickets = await _httpClient.GetFromJsonAsync<IEnumerable<TicketDto>>("/api/Ticket");
            
            if (tickets == null)
            {
                throw new Exception("Akcja nie udała się. Spróbuj ponownie.");
            }

            return tickets;
        }

        public async Task UpdateTicket(TicketDto ticketDto)
        {
            var respond = await _httpClient.PutAsJsonAsync<TicketDto>($"api/ticket", ticketDto);

            if (respond.IsSuccessStatusCode)
            {
                _manager.NavigateTo(_manager.Uri, true);
            }
            else
            {
                throw new Exception("Akcja nie udała się. Spróbuj ponownie.");
            }
        }

        public async Task RemoveTicket(string ticketName)
        {
            var respond = await _httpClient.DeleteAsync($"api/ticket/{ticketName}");

            if (respond.IsSuccessStatusCode)
            {
                _manager.NavigateTo(_manager.Uri, true);
            }
            else
            {
                throw new Exception("Akcja nie udała się. Spróbuj ponownie.");
            }
        }

        public async Task AddTicket(TicketDto ticketDto)
        {
            var respond = await _httpClient.PostAsJsonAsync<TicketDto>($"api/ticket", ticketDto);

            if (respond.IsSuccessStatusCode)
            {
                _manager.NavigateTo(_manager.Uri, true);
            }
            else
            {
                throw new Exception("Akcja nie udała się. Spróbuj ponownie.");
            }
        }
    }
}
