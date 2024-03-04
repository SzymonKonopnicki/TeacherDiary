using System.Net.Http;
using TeacherDiary.Web.Interfaces;
using TeacherDiary.WebApi.Database.Dtos;

namespace TeacherDiary.Web.Services
{
    public class ProductService : IProductService
    {
        private readonly HttpClient _httpClient;

        public ProductService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<PersonDto> GetPerson(string name)
        {
            try
            {
                var product = await _httpClient.GetFromJsonAsync<PersonDto>($"api/person/{name}");
                return product;
            }
            catch (Exception)
            {
                //some log

                throw new Exception();
            }
        }

        public async Task<PersonDto> GetPerson(int id)
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
                var products = await _httpClient.GetFromJsonAsync<IEnumerable<WebApi.Database.Dtos.PersonDto>>("api/person");
                return products;
            }
            catch (Exception )
            {
                //some log

                throw new Exception(); 
            }       
        }
    }
}
