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
        //1. Niezale¿noœci od bazy danych. Baza danych w pamiêæ
        public PersonControllerTests(WebApplicationFactory<Program> factory)
        {
            //za pomoc¹ WithWebHostBuilder nadpisujemy rejestracje serwisów po to by usun¹æ isteniej¹c¹ rejestracje
            _client = factory
                .WithWebHostBuilder(builder => 
                {
                    builder.ConfigureServices(services =>
                    {
                        var dbContextOptions = services.SingleOrDefault(service => service.ServiceType == typeof(DbContextOptions<DiaryContext>));

                        services.Remove(dbContextOptions);

                        //Powy¿ej pozbyliœmy siê istniej¹cej rejestracji dbCotextu

                        //A tutaj rejestrujemy nasz w³asny dbCobntext w pamiêæ 
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