
using HMSAPP.Application.Mapper;
using HMSAPP.Application.Services;
using HMSAPP.Contract.Abstractions;
using HMSAPP.Domainn.Repository;
using HMSAPP.Persistance.Data;
using HMSAPP.Persistance.Repository;
using Microsoft.EntityFrameworkCore;
using Serilog;

namespace HMSAPP.WebAPI
{
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

            // serilog
            Log.Logger = new LoggerConfiguration()
               .ReadFrom.Configuration(builder.Configuration)
               .Enrich.FromLogContext()
               .CreateLogger();

            builder.Host.UseSerilog();


            builder.Services.AddDbContext<HSDbContext>(options =>
                options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnectionString")));

            builder.Services.AddScoped(typeof(IGenericRepository<>), typeof(GenericRepository<>));




            builder.Services.AddAutoMapper(x => x.AddProfile(typeof(CustomProfile)));

            builder.Services.AddScoped<IDoctorService, DoctorService>();

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
}
