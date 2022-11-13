using System.Text.Json.Serialization;
using api.engine_v2.Data;
using Microsoft.EntityFrameworkCore;

namespace api.engine_v2;

public class Program
{
    public static void Main(string[] args)
    {
        // cors with endpoint routing
        var MyAllowAllOrigins = "_myAllowAllOrigins";

        var builder = WebApplication.CreateBuilder(args);

        builder.Services.AddCors(options =>
        {
            options.AddPolicy(name: MyAllowAllOrigins,
                                policy =>
                                {
                                    policy.AllowAnyOrigin()
                                        .WithMethods("OPTIONS","HEAD","GET","POST","PUT","PATCH","DELETE")
                                        .AllowAnyHeader()
                                        .AllowAnyMethod();
                                });
        });

        // Add services to the container.

        builder.Services.AddControllers();
        // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
        builder.Services.AddEndpointsApiExplorer();
        builder.Services.AddSwaggerGen();

        // SQL Connection
        builder.Services.AddDbContext<DefaultDbContext>(options =>
        {
            options
                .UseNpgsql(builder.Configuration.GetConnectionString("DefaultDbContext"))
                .UseSnakeCaseNamingConvention()
                .UseLoggerFactory(LoggerFactory.Create(builder => builder.AddConsole()))
                .EnableSensitiveDataLogging();
        });

        // serialize enums as strings in api responses (e.g. Role) (ref: https://stackoverflow.com/a/72155642/15157918)
        builder.Services.AddControllers().AddJsonOptions(options =>
        {
            options.JsonSerializerOptions.Converters.
                   Add(new JsonStringEnumConverter());

            options.JsonSerializerOptions.DefaultIgnoreCondition =
                     JsonIgnoreCondition.WhenWritingNull;
        });

        var app = builder.Build();

        // Configure the HTTP request pipeline.
        if (app.Environment.IsDevelopment())
        {
            app.UseSwagger();
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "OptechX API Engine v2");
            });
        }

        // add static servce pages
        app.UseDefaultFiles();
        app.UseStaticFiles();

        // enable CORS
        app.UseCors();

        app.UseAuthorization();

        app.MapControllers();

        app.Run();
    }
}

