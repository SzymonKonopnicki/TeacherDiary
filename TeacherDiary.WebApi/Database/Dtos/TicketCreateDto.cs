namespace TeacherDiary.WebApi.Database.Dtos
{
    public class TicketCreateDto
    {
        public required string Name { get; set; }
        public required double Price { get; set; }
        public required DateTime ValidFrom { get; set; }
        public required DateTime ValidTo { get; set; }
        public required bool Active { get; set; }
        public required int EntryQuantity { get; set; }

    }
}
