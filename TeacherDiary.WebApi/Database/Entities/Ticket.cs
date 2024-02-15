using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TeacherDiary.WebApi.Database.Entities
{
    public class Ticket
    {
        [Key]
        public int Id { get; set; }
        public required string Name { get; set; }
        public required double Price { get; set; }
        public required DateTime ValidFrom { get; set; }
        public required DateTime ValidTo { get; set; }
        public required bool Active { get; set; }
        public required int EntryQuantity { get; set; }
        public required int AvailableEntryQuantity { get; set; }
    }
}
