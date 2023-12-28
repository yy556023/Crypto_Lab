
using Crypto_Lab.BLL.Exchanges;
using Crypto_Lab.DAL.EntityFrameworkCore;
using Crypto_Lab.DAL.EntityFrameworkCore.Symbols;
using Microsoft.EntityFrameworkCore;

namespace Crypto_Lab
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            builder.Services.AddDbContext<CryptoDbContext>(options =>
            {
                options.UseSqlServer(builder.Configuration.GetConnectionString("CryptoDbContext"));
            });

            // Add services to the container.
            builder.Services.AddScoped<IExchangeService, ExchangeService>();
            builder.Services.AddScoped<ExchangeRepository>();
            builder.Services.AddScoped<SymbolRepository>();

            builder.Services.AddDistributedMemoryCache();
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
            }

            app.UseHttpsRedirection();

            app.UseAuthorization();


            app.MapControllers();

            app.Run();
        }
    }
}
