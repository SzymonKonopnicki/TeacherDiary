using Microsoft.EntityFrameworkCore;
using Microsoft.Net.Http.Headers;
using TeacherDiary.WebApi.Database;
using TeacherDiary.WebApi.Interfaces;
using TeacherDiary.WebApi.Middlewares;
using TeacherDiary.WebApi.Services;

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
        builder.Services.AddTransient<ITicketService, TicketService>();
        builder.Services.AddTransient<IAssignment, AssignmentService>();
        builder.Services.AddScoped<ExceptionHandlerMiddleware>();


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

        app.UseCors(policy =>
            policy.WithOrigins("https://localhost:7050", "http://localhost:7050")
            .AllowAnyMethod()
            .WithHeaders(HeaderNames.ContentType)
        );

        app.UseMiddleware<ExceptionHandlerMiddleware>();

        app.UseHttpsRedirection();

        app.UseAuthorization();

        app.MapControllers();

        app.Run();

    }
}