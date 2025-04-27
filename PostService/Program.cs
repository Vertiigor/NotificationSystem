using Microsoft.EntityFrameworkCore;
using PostService.Producers.Abstractions;
using PostService.Producers.Implementations;
using SubscriptionService.Data;
using SubscriptionService.Data.RabbitMQ.Connection;
using SubscriptionService.Extensions;
using SubscriptionService.Producers.Abstractions;
using SubscriptionService.Repository.Abstractions;
using SubscriptionService.Repository.Implementations;
using SubscriptionService.Services.Abstractions;

namespace SubscriptionService;

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
        builder.Services.AddScoped<IPostService, SubscriptionService.Services.Implementations.PostService>();

        // Register RabbitMQ connection
        builder.Services.AddSingleton<IRabbitMqConnection, RabbitMqConnection>();

        // Register producers
        builder.Services.AddTransient<IPostCreatedProducer, PostCreatedProducer>();
        builder.Services.AddTransient<IPostDeletedProducer, PostDeletedProducer>();

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
