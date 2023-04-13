
using AirportAPI.Data;
using AirportAPI.Logic;
using AirportAPI.Repositories;
using Microsoft.EntityFrameworkCore;

namespace AirportAPI
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            #region SQL Connection
            var connectionString = builder.Configuration.GetConnectionString("Airport");
            builder.Services.AddDbContext<AirportContext>(options => options.UseSqlServer(connectionString));
            #endregion

            builder.Services.AddScoped<IAirportRepository, AirportRepository>();
            builder.Services.AddScoped<IAirportLogic, AirportLogic>();

            builder.Services.AddControllers();
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();


            var app = builder.Build();

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
}