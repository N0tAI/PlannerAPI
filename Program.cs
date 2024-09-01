using Microsoft.EntityFrameworkCore;
using TaskPlanner.API.Database;
using TaskPlanner.API.Internal.Serialization;

namespace TaskPlanner.API;

public class Program
{
    public static void Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);
        // Add services to the container.
        builder.Services.AddDbContext<PlannerDbContext>(
            b => b.UseNpgsql(builder.Configuration.GetConnectionString("PostgresConnection"))
                  .UseSnakeCaseNamingConvention());

        builder.Services.AddTransient<CategoryRepository>()
                        .AddTransient<GoalRepository>()
                        .AddTransient<TaskRepository>();

        builder.Services.AddControllers();
        // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
        builder.Services.AddEndpointsApiExplorer();
        builder.Services.AddSwaggerGen();

        builder.Services.ConfigureHttpJsonOptions(
            options => {
                options.SerializerOptions.PropertyNameCaseInsensitive = true;
                options.SerializerOptions.AllowTrailingCommas = true;
                options.SerializerOptions.Converters.Add(new ApiResponseSerializer());
            });

        var app = builder.Build();

        // Configure the HTTP request pipeline.
        if (app.Environment.IsDevelopment())
        {
            app.UseSwagger();
            app.UseSwaggerUI();
        }

        app.UseHttpsRedirection();

        app.UseAuthorization();

        app.MapControllers();

        app.Run();
    }
}
