using System.Net.Http;
using TeacherDiary.Web.Interfaces;

namespace TeacherDiary.Web.Services
{
    public class ProductService : IProductService
    {
        private readonly HttpClient _httpClient;

        public ProductService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<IEnumerable<WebApi.Database.Dtos.PersonDto>> GetPerson()
        {
            try
            {
                var product = await _httpClient.GetFromJsonAsync<IEnumerable<WebApi.Database.Dtos.PersonDto>>("api/person");
                return product;
            }
            catch (Exception )
            {
                //some log

                throw new Exception(); 
            }       
        }
    }
}
