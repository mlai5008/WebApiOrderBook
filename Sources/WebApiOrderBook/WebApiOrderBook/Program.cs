using Microsoft.EntityFrameworkCore;
using WebApiOrderBook.Data;
using WebApiOrderBook.Middleware;
using WebApiOrderBook.Repositories;
using WebApiOrderBook.Repositories.Interfaces;

namespace WebApiOrderBook
{
    public class Program
    {
        #region Methods
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            builder.Services.AddDbContext<ShopDbContext>(options =>
               options.UseSqlServer(builder.Configuration.GetConnectionString("MSSQLLocalDB") ?? throw new InvalidOperationException("Connection string 'WebApiAppContext' not found.")));

            builder.Services.AddControllers();
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

            builder.Services.AddScoped<IBookRepositoriy, BookRepositoriy>();
            builder.Services.AddScoped<IOrderRepositoriy, OrderRepositoriy>();

            builder.Services.AddTransient<FactoryMiddleware>();
            builder.Services.AddControllersWithViews().AddJsonOptions(options =>
            {
                options.JsonSerializerOptions.ReferenceHandler = System.Text.Json.Serialization.ReferenceHandler.Preserve;
            });
            builder.Services.AddMvc(options =>
            {
                options.SuppressAsyncSuffixInActionNames = false;
            });
            builder.Services.AddAutoMapper(typeof(Program).Assembly);

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseHttpsRedirection();

            app.UseAuthorization();

            app.UseMiddleware<FactoryMiddleware>();

            app.MapControllers();

            //for (localdb)\\MSSQLLocalDB
            using (var scope = app.Services.CreateScope())
            {
                var context = scope.ServiceProvider.GetRequiredService<ShopDbContext>();
                context.Database.Migrate();
            }

            app.Run();
        } 
        #endregion
    }
}
