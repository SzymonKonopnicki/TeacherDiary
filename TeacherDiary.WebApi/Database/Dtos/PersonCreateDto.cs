using TeacherDiary.WebApi.Database.Entities;

namespace TeacherDiary.WebApi.Database.Dtos
{
    public class PersonCreateDto
    {
        public string Name { get; set; }
        public string Surname { get; set; }
        public string? Email { get; set; }
        public string Phone { get; set; }
        public bool Agreement { get; set; }
        public string? Comments { get; set; }
    }
}
