using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using calenderApi.Data;
using calenderApi.Controllers;

namespace calenderApi
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);
            builder.Services.AddDbContext<calenderApiContext>(options =>
                options.UseSqlServer(builder.Configuration.GetConnectionString("calenderApiContext") ?? throw new InvalidOperationException("Connection string 'calenderApiContext' not found.")));

            // Add services to the container.

            builder.Services.AddControllers();
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

            builder.Services.AddCors(options =>           // -------------- for angular v
            {
                options.AddPolicy("AllowAngularDevClient",
                    policy =>
                    {
                        policy.WithOrigins("http://localhost:4200") // Angular dev server
                              .AllowAnyHeader()
                              .AllowAnyMethod();
                    });
            });                   // -------------- for angular  /\

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseHttpsRedirection();

            app.UseCors("AllowAngularDevClient");  // -------------- for angular

            app.UseHttpsRedirection();

            app.UseAuthorization();


            app.MapControllers();

            app.Run();
        }
    }
}
