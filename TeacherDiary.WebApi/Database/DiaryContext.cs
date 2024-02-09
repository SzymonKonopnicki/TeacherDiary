using Microsoft.EntityFrameworkCore;
using TeacherDiary.WebApi.Database.Entities;

namespace TeacherDiary.WebApi.Database
{
    public class DiaryContext : DbContext
    {
        public DbSet<Person> Persons { get; set; }
        public DbSet<Ticket> Tickets { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=(localdb)\\mssqllocaldb;Database=DiaryDb;Trusted_Connection=True;");
        }
    }
}
