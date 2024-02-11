using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.EntityFrameworkCore;
using Microsoft.VisualStudio.TestPlatform.TestHost;
using TeacherDiary.WebApi.Database;
using Microsoft.Extensions.DependencyInjection;


namespace TeacherDiary.Tests
{
    public class PersonControllerTests
    {
        private HttpClient _client;
        private WebApplicationFactory<Program> _factory;

        //TODO:
        //1. Niezale�no�ci od bazy danych. Baza danych w pami��
        public PersonControllerTests(WebApplicationFactory<Program> factory)
        {
            //za pomoc� WithWebHostBuilder nadpisujemy rejestracje serwis�w po to by usun�� isteniej�c� rejestracje
            _client = factory
                .WithWebHostBuilder(builder => 
                {
                    builder.ConfigureServices(services =>
                    {
                        var dbContextOptions = services.SingleOrDefault(service => service.ServiceType == typeof(DbContextOptions<DiaryContext>));

                        services.Remove(dbContextOptions);

                        //Powy�ej pozbyli�my si� istniej�cej rejestracji dbCotextu

                        //A tutaj rejestrujemy nasz w�asny dbCobntext w pami�� 
                        services.AddDbContext<DiaryContext>(options => options.UseInMemoryDatabase("DiaryDb"));
                        
                    });
                })
                .CreateClient();
        }

        [Fact]
        public void Persons_()
        {
            //arrange

            //act

            //assert

        }
    }
}