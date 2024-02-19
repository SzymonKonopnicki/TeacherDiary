using Xunit;
using Microsoft.AspNetCore.Mvc.Testing;
using FluentAssertions;
using System.Net;
using TeacherDiary.WebApi.Database;
using Microsoft.EntityFrameworkCore;
using TeacherDiary.WebApi.Database.Entities;
using Newtonsoft.Json;
using System.Text;
using TeacherDiary.WebApi.Database.Dtos;
using Azure;

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
        [InlineData(1)]
        [InlineData(2)]
        public async Task GetPersonById_GetOnePersonByInt_StatusOk(int id)
        {
            // Arrange

            // Act
            var response = await _client.GetAsync("/api/Person/" + id);

            // Assert
            response.StatusCode.Should().Be(HttpStatusCode.OK);
        }

        [Theory]
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

        [Theory]
        [InlineData("JAcEk")]
        [InlineData("jan")]
        public async Task GetPersonByString_GetOnePersonByInt_StatusOk(string name)
        {
            // Arrange

            // Act
            var response = await _client.GetAsync("/api/Person/" + name);

            // Assert
            response.StatusCode.Should().Be(HttpStatusCode.OK);
        }

        [Theory]
        [InlineData("KkkkAWK")]
        public async Task GetPersonByString_GetOnePersonByInt_StatusNoContent(string name)
        {
            // Arrange

            // Act
            var response = await _client.GetAsync("/api/Person/" + name);
            var x = response.Content.ReadAsStringAsync();
            // Assert
            response.StatusCode.Should().Be(HttpStatusCode.NoContent);
        }

        [Fact]
        public async Task PersonAdd_AddPersonsToDb_StatusCreated()
        {
            // Arrange
            var person = new PersonCreateDto()
            {
                Name = "Szymon",
                Surname = "Kowalski",
                Email = "S.k@gmail.com",
                Phone = "333222333",
                Agreement = false,
                Comments = "Some comm...",
            };

            var json = JsonConvert.SerializeObject(person);

            var httpContent = new StringContent(json, UnicodeEncoding.UTF8, "application/json");

            // Act
            var response = await _client.PostAsync("/api/Person", httpContent);

            // Assert
            response.StatusCode.Should().Be(HttpStatusCode.Created);
        }

        [Theory]
        [InlineData(1)]
        [InlineData(2)]
        public async Task PersonDeleteById_RemovePersonFromDb_StatusOk(int x)
        {
            // Arrange

            // Act
            var response = await _client.DeleteAsync("/api/Person/" + x);

            // Assert
            response.StatusCode.Should().Be(HttpStatusCode.OK);

        }

        [Theory]
        [InlineData("JAn")]
        [InlineData("jaCek")]
        public async Task PersonDeleteByName_RemovePersonFromDb_StatusOk(string x)
        {
            // Arrange

            // Act
            var response = await _client.DeleteAsync("/api/Person/" + x);

            // Assert
            response.StatusCode.Should().Be(HttpStatusCode.OK);

        }

        //szukanie po mailu osoby
        [Fact]
        public async Task PersonEdit_EditPersonsInDb_StatusOk()
        {
            // Arrange
            var person = new PersonUpdateDto()
            {
                Name = "Szymon",
                Surname = "Kowalski",
                Email = "j.n@gmail.com",
                Phone = "333222333",
                Agreement = false,
                Comments = "Some comm...",
            };

            var json = JsonConvert.SerializeObject(person);

            var httpContent = new StringContent(json, UnicodeEncoding.UTF8, "application/json");

            // Act
            var response = await _client.PutAsync("/api/Person", httpContent);

            // Assert
            response.StatusCode.Should().Be(HttpStatusCode.OK);
        }

    }
}
