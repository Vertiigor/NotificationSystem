using Microsoft.EntityFrameworkCore;
using NotificationSystem.Data;
using NotificationSystem.Data.RabbitMQ.Connection;
using NotificationSystem.Extensions;
using NotificationSystem.Producers.Abstractions;
using NotificationSystem.Producers.Implementations;
using NotificationSystem.Repository.Abstractions;
using NotificationSystem.Repository.Implementations;
using NotificationSystem.Services.Abstractions;

namespace NotificationSystem;

public class Program
{
    public static void Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);

        // Add services to the container.
        builder.Services.AddDbContext<ApplicationContext>(options =>
              options.UseNpgsql(builder.Configuration.GetConnectionString("DatabaseContext") ?? throw new InvalidOperationException("Connection string 'BookStoreContext' not found.")));

        // Register repositories
        builder.Services.AddScoped<IPostRepository, PostRepository>();

        // Register services
        builder.Services.AddScoped<IPostService, NotificationSystem.Services.Implementations.PostService>();

        // Register RabbitMQ connection
        builder.Services.AddSingleton<IRabbitMqConnection, RabbitMqConnection>();

        // Register producers
        builder.Services.AddTransient<IMessageProducer, Producer>();

        builder.Services.AddControllers();

        // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
        builder.Services.AddEndpointsApiExplorer();
        builder.Services.AddSwaggerGen();

        var app = builder.Build();

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
