using Xunit;
using Microsoft.AspNetCore.Mvc.Testing;
using FluentAssertions;
using System.Net;
using TeacherDiary.WebApi.Database;
using Microsoft.EntityFrameworkCore;

namespace TeacherDiary.Tests
{
    public class PersonControllerTests : IClassFixture<WebApplicationFactory<Program>>
    {
        private readonly WebApplicationFactory<Program> _factory;
        private readonly HttpClient _client;

        public PersonControllerTests(WebApplicationFactory<Program> factory)
        {
            _factory = factory;
            _client = _factory
                .WithWebHostBuilder(builder =>
                {
                    builder.ConfigureServices(services =>
                    {
                        var dbContextOptions = services.SingleOrDefault(service => service.ServiceType == typeof(DbContextOptions<DiaryContext>));

                        services.Remove(dbContextOptions);

                        services.AddDbContext<DiaryContext>(options => options.UseInMemoryDatabase("DiaryDb"));
                    });
                })
                .CreateClient();
        }

        [Fact]
        public async Task GetPerson_GetAllPersonsInDb_StatusOk()
        {
            // Arrange

            // Act
            var response = await _client.GetAsync("/api/Person");

            // Assert
            response.StatusCode.Should().Be(HttpStatusCode.OK);
        }

        [Theory]
        [InlineData(1)]//nie działa bo w db nie ma osoby z tym id
        [InlineData(2)]//nie działa bo w db nie ma osoby z tym id
        [InlineData(3)]//nie działa bo w db nie ma osoby z tym id
        public async Task GetPersonById_GetOnePersonByInt_StatusOk(int id)
        {
            // Arrange

            // Act
            var response = await _client.GetAsync("/api/Person/" + id);

            // Assert
            response.StatusCode.Should().Be(HttpStatusCode.OK);
        }

        [Theory]
        [InlineData(2)]
        [InlineData(-3)]
        [InlineData(null)]
        public async Task GetPersonById_GetOnePersonByInt_StatusNoContent(int id)
        {
            // Arrange

            // Act
            var response = await _client.GetAsync("/api/Person/" + id);

            // Assert
            response.StatusCode.Should().Be(HttpStatusCode.NoContent);
        }

    }
}
