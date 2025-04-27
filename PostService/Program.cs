using Microsoft.EntityFrameworkCore;
using NotificationService.Data;
using NotificationService.Data.RabbitMQ.Connection;
using NotificationService.Extensions;
using NotificationService.Producers.Abstractions;
using NotificationService.Producers.Implementations;
using NotificationService.Repository.Abstractions;
using NotificationService.Repository.Implementations;
using NotificationService.Services.Abstractions;

namespace NotificationService;

public class Program
{
    public static void Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);

        // Add services to the container.
        builder.Services.AddDbContext<ApplicationContext>(options =>
              options.UseNpgsql(builder.Configuration.GetConnectionString("DatabaseContext") ?? throw new InvalidOperationException("Connection string 'BookStoreContext' not found.")));

        builder.AddServiceDefaults();

        // Register repositories
        builder.Services.AddScoped<IPostRepository, PostRepository>();

        // Register services
        builder.Services.AddScoped<IPostService, NotificationService.Services.Implementations.PostService>();

        // Register RabbitMQ connection
        builder.Services.AddSingleton<IRabbitMqConnection, RabbitMqConnection>();

        // Register producers
        builder.Services.AddTransient<IMessageProducer, Producer>();

        builder.Services.AddControllers();

        // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
        builder.Services.AddEndpointsApiExplorer();
        builder.Services.AddSwaggerGen();

        var app = builder.Build();

        app.MapDefaultEndpoints();

        // Configure the HTTP request pipeline.
        if (app.Environment.IsDevelopment())
        {
            app.UseSwagger();
            app.UseSwaggerUI();
            app.ApplyMigrations();
        }

        app.UseHttpsRedirection();

        app.UseAuthorization();

        app.MapControllers();

        app.Run();
    }
}
