using System.Text.Json.Serialization;
using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;

namespace api.engine_v2;

public class Program
{
    public static void Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);

        // Add services to the container.

        builder.Services.AddControllers();
        // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
        builder.Services.AddEndpointsApiExplorer();
        builder.Services.AddSwaggerGen();

        // SQL Connection
        //builder.Services.AddDbContext<"DefaultDbContext">

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
            app.UseSwaggerUI();
        }

        app.UseAuthorization();


        app.MapControllers();

        app.Run();
    }
}

