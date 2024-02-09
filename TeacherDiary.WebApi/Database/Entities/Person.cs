﻿namespace TeacherDiary.WebApi.Database.Entities
{
    public class Person
    {
        public required int Id { get; set; }
        public required string Name { get; set; }
        public required string Surname { get; set; }
        public string? Email { get; set; }
        public required string Phone { get; set; }
        public required bool Agreement { get; set; }
        public string? Comments { get; set; }
        public ICollection<Ticket>? Tickets { get; set; }
    }
}
