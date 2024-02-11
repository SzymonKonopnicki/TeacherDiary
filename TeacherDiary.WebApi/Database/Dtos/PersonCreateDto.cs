using TeacherDiary.WebApi.Database.Entities;

namespace TeacherDiary.WebApi.Database.Dtos
{
    public class PersonCreateDto
    {
        public required string Name { get; set; }
        public required string Surname { get; set; }
        public string? Email { get; set; }
        public required string Phone { get; set; }
        public required bool Agreement { get; set; }
        public string? Comments { get; set; }
    }
}
