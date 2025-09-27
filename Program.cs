
using ChimeWebApi.Core.Enums;
using ChimeWebApi.Core.Services;
using ChimeWebApi.Database;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using Scalar.AspNetCore;
using System.Text;

namespace ChimeWebApi
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            builder.Services.AddControllers();
            builder.Services.AddOpenApi("v1");

			builder.Services.AddCors(options =>
			{
				options.AddPolicy(name: CorsPolicy.AllowChimeWebapp, policy =>
				{
					// allow angular webapp to access api
					policy.WithOrigins("http://localhost:4200")
					.AllowAnyHeader()
					.AllowAnyMethod();
				});
			});

			string connectionString = builder.Configuration.GetConnectionString("MainDb")!;
			builder.Services.AddDbContext<ChimeDatabase>(options =>
			{
				options.UseMySql(connectionString, ServerVersion.AutoDetect(connectionString));
			});

			builder.Services.AddScoped<AuthService>();
			builder.Services.AddScoped<ProductService>();

			builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
				.AddJwtBearer(options =>
				{
					options.TokenValidationParameters = new TokenValidationParameters()
					{
						ValidateIssuer = true,
						ValidateAudience = true,
						ValidateIssuerSigningKey = true,
						ValidateLifetime = true,
						ValidIssuer = builder.Configuration["JWT:Issuer"],
						ValidAudience = builder.Configuration["JWT:Audience"],
						IssuerSigningKey = new SymmetricSecurityKey(
							Encoding.UTF8.GetBytes(builder.Configuration["JWT:Key"]!))
					};
				});

			//var MyAllowSpecificOrigins = "AllowHyprLocalOrigins";
			//builder.Services.AddCors(options =>
			//{
			//	options.AddPolicy(name: MyAllowSpecificOrigins,
			//		policy =>
			//		{
			//			policy.WithOrigins("http://192.168.24.159:4200");
			//		});
			//});

			

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.MapOpenApi();
				app.MapScalarApiReference();
            }

            app.UseHttpsRedirection();

			app.UseCors(CorsPolicy.AllowChimeWebapp);

            app.UseAuthorization();


            app.MapControllers();

            app.Run();
        }
    }
}
