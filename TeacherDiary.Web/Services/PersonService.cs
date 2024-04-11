using Microsoft.AspNetCore.Components;
using TeacherDiary.Web.Interfaces;
using TeacherDiary.Web.Models;
using TeacherDiary.WebApi.Database.Dtos;

namespace TeacherDiary.Web.Services
{
    public class PersonService : IPersonService
    {
        private readonly HttpClient _httpClient;
        private readonly NavigationManager _manager;

        public PersonService(HttpClient httpClient, NavigationManager manager)
        {
            _httpClient = httpClient;
            _manager = manager;
        }

        public async Task<PersonDto> GetPersonByEmail(string mail)
        {

            var response = await _httpClient.GetAsync($"api/person/{mail}");

            if (response.IsSuccessStatusCode)
            {
                return await response.Content.ReadFromJsonAsync<PersonDto>();
            }
            else
            {
                throw new Exception();
            }
        }

        public async Task<PersonDto> GetPersonById(int id)
        {
            var product = await _httpClient.GetFromJsonAsync<PersonDto>($"api/person/{id}");

            if (product == null)
            {
                throw new Exception();
            }

            return product;
        }

        public async Task<IEnumerable<PersonDto>> GetPersons()
        {
            var products = await _httpClient.GetFromJsonAsync<IEnumerable<PersonDto>>("api/person");

            if (products == null)
            {
                throw new Exception();
            }

            return products;
        }

        public async Task EditPersonByMail(PersonUpdateDto personUpdateDto)
        {
            var respond = await _httpClient.PutAsJsonAsync<PersonUpdateDto>("api/person", personUpdateDto);

            if (respond.IsSuccessStatusCode)
            {
                _manager.NavigateTo(_manager.Uri, true);
            }
            else
            {
                throw new Exception();
            }
        }

        public async Task AddPerson(PersonCreateDto personCreateDto)
        {
            var respond = await _httpClient.PostAsJsonAsync<PersonCreateDto>("api/person", personCreateDto);

            if (respond.IsSuccessStatusCode)
            {
                _manager.NavigateTo(_manager.Uri, true);
            }
            else
            {
                throw new Exception();
            }
        }

        public async Task RemovePersonByName(string name)
        {
            var response = await _httpClient.DeleteAsync($"api/person/{name}");

            if (response.IsSuccessStatusCode)
            {
                _manager.NavigateTo(_manager.Uri, true);
            }
            else
            { 
                throw new Exception(); 
            }

        }

        public async Task AssignTicketToPerson(AssigmentModel assigmentModel)
        {
            var query = $"?personMail={assigmentModel.PersonMail}&ticketName={assigmentModel.TicketName}";

            var respond = await _httpClient.PutAsync($"api/Assignment{query}", null);

            if (respond.IsSuccessStatusCode)
            {
                _manager.NavigateTo(_manager.Uri, true);
            }
            else
            {
                throw new Exception();
            }
        }

        public async Task RemoveTicket(string mail)
        {
            var query = $"?personMail={mail}";

            var response = await _httpClient.DeleteAsync($"api/Assignment{query}");

            if (response.IsSuccessStatusCode)
            {
                _manager.NavigateTo(_manager.Uri, true);
            }
            else
            {
                throw new Exception();
            }
        }
    }
}
