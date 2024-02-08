namespace TeacherDiary.WebApi.Database.Entities
{
    public class Person
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public bool Agreement { get; set; }
        public string Comments { get; set; }
        public ICollection<Ticket> Tickets { get; set; }
    }
}
