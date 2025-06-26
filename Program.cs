using System.Text.Json.Serialization;
using System.Text.Json;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using MVCEcommerce.Data;
using MVCEcommerce.Repository;
using MVCEcommerce.Services;

namespace Ecommerce
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);
            
            // Add services to the container
            builder.Services.AddControllersWithViews();
            builder.Services.AddControllers()
                .AddJsonOptions(options =>
                {
                    options.JsonSerializerOptions.PropertyNameCaseInsensitive = true;
                    options.JsonSerializerOptions.Converters.Add(new JsonStringEnumConverter(JsonNamingPolicy.CamelCase, allowIntegerValues: false));
                    options.JsonSerializerOptions.PropertyNamingPolicy = JsonNamingPolicy.CamelCase;
                });

            // Logging
            builder.Services.AddLogging(logging =>
            {
                logging.AddConsole();
                logging.AddDebug();
                logging.SetMinimumLevel(LogLevel.Debug);
            });

            // JWT Authentication
            builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
                .AddJwtBearer(options =>
                {
                    options.TokenValidationParameters = new TokenValidationParameters
                    {
                        ValidateIssuer = true,
                        ValidIssuer = builder.Configuration["AppSettings:Issuer"],
                        ValidateAudience = true,
                        ValidAudience = builder.Configuration["AppSettings:Audience"],
                        ValidateLifetime = true,
                        IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(builder.Configuration["AppSettings:Token"])),
                        ValidateIssuerSigningKey = true,
                    };
                });

            // Swagger
           

            // Database and custom services
            builder.Services.AddDbContext<ProductDbContext>(options =>
                options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));
            builder.Services.AddScoped<IAuthService, AuthService>();
            builder.Services.AddScoped<IProductRepository, ProductRepository>();
            builder.Services.AddScoped<IBuyProduct, BuyProduct>();



            var app = builder.Build();
            app.UseRouting();
            //app.MapControllerRoute(name: "Default", pattern: "{ Contoller=Prod}/{Action=Index}/{id?}");
          
            app.MapDefaultControllerRoute();
            app.UseHttpsRedirection();

            app.UseAuthentication(); //  Must come before UseAuthorization
            app.UseAuthorization();

            app.MapControllers();

            app.Run();
        }
    }
}
