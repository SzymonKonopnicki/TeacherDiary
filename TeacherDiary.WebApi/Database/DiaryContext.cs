using Microsoft.EntityFrameworkCore;
using System.Diagnostics.Metrics;
using TeacherDiary.WebApi.Database.Entities;

namespace TeacherDiary.WebApi.Database
{
    public class DiaryContext : DbContext
    {
        public DiaryContext(DbContextOptions<DiaryContext> options) : base(options)
        {

        } 

        public DbSet<Person> Persons { get; set; }
        public DbSet<Ticket> Tickets { get; set; }
        public DbSet<TicketForUse> TicketsForUse { get; set; }

    }
}
