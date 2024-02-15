using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System.Data.Entity;
using TeacherDiary.WebApi.Database;
using TeacherDiary.WebApi.Database.Entities;
using TeacherDiary.WebApi.Interfaces;
using TeacherDiary.WebApi.Services;
using static System.Net.Mime.MediaTypeNames;
public class Program
{
    public static void Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);

        // Add services to the container.

        builder.Services.AddControllers();
        // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle

        builder.Services.AddAutoMapper(typeof(Program));

        builder.Services.AddEndpointsApiExplorer();
        builder.Services.AddSwaggerGen();
        builder.Services.AddDbContext<DiaryContext>(options =>
            options.UseSqlServer(connectionString: "Server=(localdb)\\mssqllocaldb;Database=DiaryDb;Trusted_Connection=True;"));
        builder.Services.AddScoped<DbSeeder>();
        builder.Services.AddTransient<IPersonService, PersonService>();



        var app = builder.Build();


        // Configure the HTTP request pipeline.
        if (app.Environment.IsDevelopment())
        {
            app.UseSwagger();
            app.UseSwaggerUI();

            var scope = app.Services.CreateScope();
            var seeder = scope.ServiceProvider.GetRequiredService<DbSeeder>();
            seeder.DataSeeder();
        }

        app.UseHttpsRedirection();

        app.UseAuthorization();

        app.MapControllers();

        app.Run();

    }
}