using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using NotificationSystem.Data;
using NotificationSystem.Extensions;
using NotificationSystem.Models;
using NotificationSystem.Repository.Abstractions;
using NotificationSystem.Repository.Implementations;
using NotificationSystem.Services.Abstractions;
using NotificationSystem.Services.Implementations;

namespace NotificationSystem;

public class Program
{
    public static void Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);

        builder.Services.AddDbContext<ApplicationContext>(options =>
               options.UseNpgsql(builder.Configuration.GetConnectionString("DatabaseContext") ?? throw new InvalidOperationException("Connection string 'BookStoreContext' not found.")));

        // Configure Identity to use the custom ApplicationUser model
        builder.Services.AddIdentity<User, IdentityRole>()
            .AddEntityFrameworkStores<ApplicationContext>()
            .AddDefaultTokenProviders();

        // Register repositories
        builder.Services.AddScoped<IUserRepository, UserRepository>();
        builder.Services.AddScoped<IChannelRepository, ChannelRepository>();

        // Register services
        builder.Services.AddScoped<IUserService, UserService>();
        builder.Services.AddScoped<IChannelService, ChannelService>();

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
