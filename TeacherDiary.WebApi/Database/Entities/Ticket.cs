namespace TeacherDiary.WebApi.Database.Entities
{
    public class Ticket
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public double Price { get; set; }
        public DateTime ValidFrom { get; set; }
        public DateTime ValidTo { get; set; }
        public bool Active { get; set; }
        public int EntryQuantity { get; set; }
        public int AvailableEntryQuantity { get; set; }
    }
}
