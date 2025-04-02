using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using Rad302SampleExam2024.WebAPI;
using System.Text;
using Tracker.WebAPIClient;

public class Program
{
    public static void Main(string[] args)
    {
        // For CORS on localhost
        string LocalAllowSpecificOrigins = "_localAllowSpecificOrigins"; 
        
        var builder = WebApplication.CreateBuilder(args);

        ActivityAPIClient.Track(StudentID: "S00999995", StudentName: "Paul Powell",
                        activityName: "Rad302 Mock Exam 2025", Task: "Starting Mock Exam");

        //add Authentication to the Web App
        builder.Services.AddAuthentication(options =>
        {
            options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
            options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
        }).AddCookie().AddJwtBearer(cfg =>
        {
            cfg.TokenValidationParameters = new TokenValidationParameters()
            {
                ValidateIssuer = true,
                ValidIssuer = builder.Configuration["Tokens:Issuer"],
                ValidateAudience = true,
                ValidAudience = builder.Configuration["Tokens:Audience"],
                ValidateIssuerSigningKey = true,
                IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(builder.Configuration["Tokens:Key"]))
            };
        });
        builder.Services.AddCors(options =>
        {
            options.AddPolicy(name: LocalAllowSpecificOrigins,
                            builder =>
                            {
                                builder.WithOrigins("https://localhost:7235")
                                    .AllowAnyHeader().AllowAnyMethod();
                            });
        });
        builder.Services.AddControllers();
        // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
        builder.Services.AddEndpointsApiExplorer();
        builder.Services.AddSwaggerGen(c =>
        {
            c.SwaggerDoc("v1", new OpenApiInfo { Title = "Product Web API", Version = "v1" });
            c.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme()
            {
                Name = "Authorization",
                Type = SecuritySchemeType.ApiKey,
                BearerFormat = "JWT",
                In = ParameterLocation.Header,
                Description = "JWT Authorization Header using Bearer"
            });
            c.AddSecurityRequirement(new OpenApiSecurityRequirement
                {
                    {
                    new OpenApiSecurityScheme
                    {
                        Reference = new OpenApiReference
                        {
                            Type=ReferenceType.SecurityScheme,
                            Id="Bearer"
                        }
                    }, new String[] {}
                }
                });
        });

        var app = builder.Build();

        app.UseSwagger();
        app.UseSwaggerUI(c =>
        {
            c.SwaggerEndpoint("/swagger/v1/swagger.json", "ProductWepAPI v1");

        }
        );


        app.UseHttpsRedirection();

        app.UseAuthentication();

        app.UseRouting();

        app.UseAuthorization();

        app.UseEndpoints(endpoints =>
        {
            endpoints.MapControllers();
        });

        app.Run();
    }
    

}