using Microsoft.EntityFrameworkCore;
using TeacherDiary.WebApi.Database.Entities;

namespace TeacherDiary.WebApi.Database
{
    public class DbSeeder
    {
        private readonly DiaryContext _dbContext;
        public DbSeeder(DiaryContext dbContext)
        {
            _dbContext = dbContext;
        }

        public void DataSeeder()
        {
            if (_dbContext.Database.IsRelational())
            {
                //migracja
            }
            if (_dbContext.Database.CanConnect())
            {
                if (!_dbContext.Persons.Any())
                {
                    var data = BasicDataPersonInitialization();
                    _dbContext.AddRange(data);
                    _dbContext.SaveChanges();
                }
                if (!_dbContext.TicketsForUse.Any())
                {
                    var data = BasicDataTicketInitialization();
                    _dbContext.AddRange(data);
                    _dbContext.SaveChanges();
                }
            }
        }

        private List<Person> BasicDataPersonInitialization()
        {
            List<Person> defaultList = new List<Person>()
            {
                new Person()
                {
                    Name = "Jan",
                    Surname = "Kowalski",
                    Email = "JK@gmail.com",
                    Phone = "666111666",
                    Agreement = true,
                    Comments = "Text..."
                },
                new Person()
                {
                    Name = "Jacek",
                    Surname = "Wojciechowski",
                    Email = "JW@gmail.com",
                    Phone = "666777666",
                    Agreement = false,
                    Comments = "Text...",
                }
            };

            return defaultList;
        }

        private List<TicketForUse> BasicDataTicketInitialization()
        {
            List<TicketForUse> defaultList = new List<TicketForUse>()
            {
                new TicketForUse()
                {
                    Name = "Ticket S",
                    Price = 10.00,
                    EntryQuantity = 5
                },

                new TicketForUse()
                {
                    Name = "Ticket M",
                    Price = 15.00,
                    EntryQuantity = 10
                },

                new TicketForUse()
                {
                    Name = "Ticket L",
                    Price = 20.00,
                    EntryQuantity = 15
                }
            };

            return defaultList;
        }
    }
}
