using System.Text.Json.Serialization;
using api.engine_v2.Data;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

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
                                    policy.AllowAnyMethod()
                                        .AllowAnyHeader()
                                        .SetIsOriginAllowed(origin => true)
                                        .AllowCredentials();
                                    // policy.AllowAnyOrigin()
                                    //     .WithMethods("OPTIONS", "HEAD", "GET", "POST", "PUT", "PATCH", "DELETE")
                                    //     .AllowAnyHeader()
                                    //     .AllowAnyMethod();
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
                .UseSnakeCaseNamingConvention();  //<-- need to remove the ';' if uncomment the following lines
                // .UseLoggerFactory(LoggerFactory.Create(builder => builder.AddConsole()))
                // .EnableSensitiveDataLogging();
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
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "OptechX API Engine v0.2-rc.1a");
            });
        }

        // add static servce pages
        app.UseDefaultFiles();
        app.UseStaticFiles();

        // add OPTIONS=200.OK middleware
        app.Use(async (context, next) =>
        {
            var methodvalue = context.Request.Method;
            if (!string.IsNullOrEmpty(methodvalue))
            {
 
                if (methodvalue == HttpMethods.Options || methodvalue == HttpMethods.Head)
                {
                    await context.Response.WriteAsync("Option Request");
                }
                else
                {
                    await next();
                }
            }
        });

        // enable CORS
        app.UseCors();

        app.UseAuthorization();

        app.MapControllers();

        app.Run();
    }
}

