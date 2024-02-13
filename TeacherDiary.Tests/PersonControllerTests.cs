using Xunit;
using Microsoft.AspNetCore.Mvc.Testing;
using FluentAssertions;
using System.Net;

namespace TeacherDiary.Tests
{
    public class PersonControllerTests : IClassFixture<WebApplicationFactory<Program>>
    {
        private readonly WebApplicationFactory<Program> _factory;

        public PersonControllerTests(WebApplicationFactory<Program> factory)
        {
            _factory = factory;
        }

        [Fact]
        public async Task GetPerson_GetAllPersonsInDb_StatusOk()
        {
            // Arrange
            var client = _factory.CreateClient();

            // Act
            var response = await client.GetAsync("/api/Person");

            // Assert
            response.StatusCode.Should().Be(HttpStatusCode.OK);
        }

        [Theory]
        [InlineData(1)]
        [InlineData(2)]//nie działa bo w db nie ma osoby z tym id
        [InlineData(3)]//nie działa bo w db nie ma osoby z tym id
        public async Task GetPersonById_GetOnePersonByInt_StatusOk(int id)
        {
            // Arrange
            var client = _factory.CreateClient();

            // Act
            var response = await client.GetAsync("/api/Person/" + id);

            // Assert
            response.StatusCode.Should().Be(HttpStatusCode.OK);
        }

    }
}
