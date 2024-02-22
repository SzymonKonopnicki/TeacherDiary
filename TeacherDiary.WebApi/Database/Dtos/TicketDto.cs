namespace TeacherDiary.WebApi.Database.Dtos
{
    public class TicketDto
    {
        public required string Name { get; set; }
        public required double Price { get; set; }
        public required int EntryQuantity { get; set; }
    }
}
