
using ElectricalLearning.Api.Middleware;
using ElectricalLearning.Repositories;
using ElectricalLearning.Repositories.Abstraction;
using ElectricalLearning.Services.Implementations;
using ElectricalLearning.Services.IServices;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using System.Text;

namespace ElectricalLearning.Api
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.

            builder.Services.AddControllers();
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle

            // CORS
            builder.Services.AddCors(options =>
            {
                options.AddPolicy("AllowFrontend", policyBuilder =>
                {
                    policyBuilder.WithOrigins(
                        "http://localhost:3000",
                        "https://fe-electronic-web2-d.vercel.app"
                    )
                    .AllowAnyHeader()
                    .AllowAnyMethod()
                    .AllowCredentials();
                });
            });


            builder.Services.AddEndpointsApiExplorer();
            //builder.Services.AddSwaggerGen();
            builder.Services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new() { Title = "ElectricalLearning API", Version = "v1" });

                c.AddSecurityDefinition("Bearer", new Microsoft.OpenApi.Models.OpenApiSecurityScheme
                {
                    Name = "Authorization",
                    Type = Microsoft.OpenApi.Models.SecuritySchemeType.Http,
                    Scheme = "Bearer",
                    BearerFormat = "JWT",
                    In = Microsoft.OpenApi.Models.ParameterLocation.Header,
                    Description = "Nhập JWT token vào đây. Ví dụ: Bearer {token}"
                });

                c.AddSecurityRequirement(new Microsoft.OpenApi.Models.OpenApiSecurityRequirement
                {
                    {
                        new Microsoft.OpenApi.Models.OpenApiSecurityScheme
                        {
                            Reference = new Microsoft.OpenApi.Models.OpenApiReference
                            {
                                Type = Microsoft.OpenApi.Models.ReferenceType.SecurityScheme,
                                Id = "Bearer"
                            }
                        },
                        new string[] {}
                    }
                });
            });

            builder.Services.AddDbContext<ApplicationDbContext>(
                options => options.UseSqlServer(
                builder.Configuration.GetConnectionString("DefaultConnection")));

            //JWT Authentication
            builder.Services.AddAuthentication(options =>
            {
                options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            })
                .AddJwtBearer(options =>
                {
                    var config = builder.Configuration.GetSection("JwtSettings");
                    var key = Encoding.UTF8.GetBytes(config["Secret"]);

                        options.TokenValidationParameters = new TokenValidationParameters
                    {
                        ValidateIssuer = true,
                        ValidateAudience = true,
                        ValidateLifetime = true,
                        ValidateIssuerSigningKey = true,
                        ValidIssuer = config["Issuer"],
                        ValidAudience = config["Audience"],
                        IssuerSigningKey = new SymmetricSecurityKey(key),
                        RoleClaimType = "http://schemas.microsoft.com/ws/2008/06/identity/claims/role"
                    };
                });


            builder.Services.AddScoped(typeof(IBaseRepository<,>), typeof(BaseRepository<,>));
            builder.Services.AddScoped<IAccountService, AccountService>();
            builder.Services.AddScoped<IJwtService, JwtService>();
            builder.Services.AddScoped<IFormulaService, FormulaService>();
            builder.Services.AddScoped<IGradeService, GradeService>();
            builder.Services.AddScoped<IChapterService, ChapterService>();
            builder.Services.AddScoped<ILessonService, LessonService>();

            builder.Services.AddTransient<GlobalExceptionHandling>();

            var app = builder.Build();

            //Auto migration
            using (var scope = app.Services.CreateScope())
            {
                var dbContext = scope.ServiceProvider.GetRequiredService<ApplicationDbContext>();
                if (dbContext.Database.IsRelational())
                {
                    dbContext.Database.Migrate();
                }
            }

            app.UseMiddleware<GlobalExceptionHandling>();

            app.UseSwagger();
            app.UseSwaggerUI();

            app.UseHttpsRedirection();

            app.UseCors("AllowFrontend");////

            app.UseAuthentication();///////////

            app.UseAuthorization();

            app.MapControllers();

            app.Run();
        }
    }
}
