using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TeacherDiary.WebApi.Database.Entities
{
    public class TicketForUse
    {
        [Key]
        public int Id { get; set; }
        public required string Name { get; set; }
        public required double Price { get; set; }
        public required int EntryQuantity { get; set; }
        public DateTime ValidFrom { get; set; }
        public DateTime ValidTo { get; set; }
        public bool Active { get; set; }
        public int AvailableEntryQuantity { get; set; }
    }
}
