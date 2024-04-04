using Microsoft.AspNetCore.Components;
using System.Security.Cryptography;
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
            try
            {
                var response = await _httpClient.GetAsync($"api/person/{mail}");

                return await response.Content.ReadFromJsonAsync<PersonDto>();

            }
            catch (Exception msg)
            {
                //some log

                throw new Exception(msg.Message);
            }
        }

        public async Task<PersonDto> GetPersonById(int id)
        {
            try
            {

                var product = await _httpClient.GetFromJsonAsync<PersonDto>($"api/person/{id}");
                return product;
            }
            catch (Exception)
            {
                //some log

                throw new Exception();
            }
        }

        public async Task<IEnumerable<PersonDto>> GetPersons()
        {
            try
            {
                var products = await _httpClient.GetFromJsonAsync<IEnumerable<PersonDto>>("api/person");
                return products;
            }
            catch (Exception )
            {
                //some log

                throw new Exception(); 
            }       
        }

        public async Task EditPersonByMail(PersonUpdateDto personUpdateDto)
        {
            try
            {
                var respond = await _httpClient.PutAsJsonAsync<PersonUpdateDto>("api/person", personUpdateDto);

                if (respond.IsSuccessStatusCode)
                {
                    _manager.NavigateTo(_manager.Uri, true);
                }
                else
                {
                    respond.StatusCode.ToString();
                    respond.Headers.ToString();
                }
            }
            catch (Exception)
            {
                //some log

                throw new Exception();
            }
        }

        public async Task AddPerson(PersonCreateDto personCreateDto)
        {
            try
            {
                var respond = await _httpClient.PostAsJsonAsync<PersonCreateDto>("api/person", personCreateDto);
               
                if (respond.IsSuccessStatusCode)
                {
                    _manager.NavigateTo(_manager.Uri, true);
                }
                else
                {
                    respond.StatusCode.ToString();
                    respond.Headers.ToString();
                }
            }
            catch (Exception)
            {
                //some log

                throw new Exception();
            }
        }

        public async Task RemovePersonByName(string name)
        {
            try
            {
                var response = await _httpClient.DeleteAsync($"api/person/{name}");

                _manager.NavigateTo(_manager.Uri, true);

            }
            catch (Exception)
            {
                //some log

                throw new Exception();
            }
        }

        public async Task AssignTicketToPerson(AssigmentModel assigmentModel)
        {
            try
            {
                // Przygotuj dane jako parametry zapytania PUT
                var query = $"?personMail={assigmentModel.PersonMail}&ticketName={assigmentModel.TicketName}";

                // Wyślij zapytanie PUT z parametrami
                var respond = await _httpClient.PutAsync($"api/Assignment{query}", null);

                _manager.NavigateTo(_manager.Uri, true);
            }
            catch (Exception)
            {
                //some log

                throw new Exception();
            }
        }

        public async Task RemoveTicket(string mail)
        {
            try
            {
                var query = $"?personMail={mail}";

                var response = await _httpClient.DeleteAsync($"api/Assignment{query}");

                _manager.NavigateTo(_manager.Uri, true);

            }
            catch (Exception)
            {
                //some log

                throw new Exception();
            }
        }
    }
}
