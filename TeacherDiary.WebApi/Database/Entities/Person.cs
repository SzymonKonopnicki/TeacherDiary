// Ignore Spelling: Api

using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TeacherDiary.WebApi.Database.Entities
{
    public class Person
    {
        [Key]
        public int Id { get; set; }
        public required string Name { get; set; }
        public required string Surname { get; set; }
        public required string Email { get; set; }
        public required string Phone { get; set; }
        public required bool Agreement { get; set; }
        public string? Comments { get; set; }
        public int? TicketForUseId { get; set; }
        public TicketForUse? TicketsForUse { get; set; }
    }
}
