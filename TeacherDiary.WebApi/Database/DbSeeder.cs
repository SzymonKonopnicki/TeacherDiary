
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using TeacherDiary.WebApi.Database.Entities;
using System.Data.Entity;

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
                    var data = BasicDataInitialization();
                    _dbContext.AddRange(data);
                    _dbContext.SaveChanges();
                }
                
            }
        }

        private List<Person> BasicDataInitialization()
        {
            List<Person> defaultList = new List<Person>();

            defaultList.Add(new Person()
            {
                Name = "Jan",
                Surname = "Kowalski",
                Email = "j.k@gmail.com",
                Phone = "111222333",
                Agreement = true,
                Comments = "Some comm...",
                Tickets = new List<Ticket>()
                {
                    new Ticket() // Poprawione użycie słowa kluczowego "new"
                    {
                        Name = "Some ticket",
                        Price = 9.00,
                        ValidFrom = new DateTime(2024, 02, 14), // Poprawna składnia dla tworzenia daty
                        ValidTo = new DateTime(2024, 03, 14), // Poprawna składnia dla tworzenia daty
                        Active = true,
                        EntryQuantity = 2,
                        AvailableEntryQuantity = 1
                    }
                }
            });
            
            defaultList.Add(new Person()
            {
                Name = "Jacek",
                Surname = "Nowak",
                Email = "j.n@gmail.com",
                Phone = "333111222",
                Agreement = false,
                Comments = "Some comm...",
                Tickets = new List<Ticket>()
                {
                    new Ticket() // Poprawione użycie słowa kluczowego "new"
                    {
                        Name = "Some ticket x 2",
                        Price = 9.99,
                        ValidFrom = new DateTime(2024, 01, 14), // Poprawna składnia dla tworzenia daty
                        ValidTo = new DateTime(2024, 02, 14), // Poprawna składnia dla tworzenia daty
                        Active = true,
                        EntryQuantity = 10,
                        AvailableEntryQuantity = 1
                    }
                }
            });

            return defaultList;
        }
    }
}
