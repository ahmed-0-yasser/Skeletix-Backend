using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using Skeletix.Persistence;
using Skeletix.Services;
using Skeletix.Services.AuthService;
using Skeletix.Services.DashboardService;
using Skeletix.Services.Interfaces;
using Skeletix.Services.Reports;
using System.Text;

var builder = WebApplication.CreateBuilder(args);

// =========================
// CONFIG
// =========================
builder.Configuration
    .SetBasePath(Directory.GetCurrentDirectory())
    .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
    .AddJsonFile($"appsettings.{builder.Environment.EnvironmentName}.json", optional: true)
    .AddEnvironmentVariables();

// =========================
// Controllers
// =========================
builder.Services.AddControllers();

// =========================
// CORS (ADDED FIX)
// =========================
builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowFrontend", policy =>
    {
        policy.WithOrigins("https://skeletix-dsw7.vercel.app")
              .AllowAnyHeader()
              .AllowAnyMethod();
    });
});

// =========================
// DbContext
// =========================
builder.Services.AddDbContext<ApplicationDbContext>(options =>
{
    options.UseSqlServer(
        builder.Configuration.GetConnectionString("DefaultConnection"),
        sqlOptions => sqlOptions.EnableRetryOnFailure());
});

// =========================
// HttpContext
// =========================
builder.Services.AddHttpContextAccessor();

// =========================
// Services
// =========================
builder.Services.AddScoped<IMedicalFileService, MedicalFileService>();
builder.Services.AddScoped<IReportService, ReportService>();
builder.Services.AddScoped<IDashboardService, DashboardService>();
builder.Services.AddScoped<IAuthService, AuthService>();

// =========================
// AI SERVICE
// =========================
builder.Services.AddHttpClient<IAiService, AiService>();

// =========================
// HTTP CLIENT
// =========================
builder.Services.AddHttpClient();

// =========================
// Swagger
// =========================
builder.Services.AddEndpointsApiExplorer();

builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new OpenApiInfo
    {
        Title = "Skeletix API",
        Version = "v1"
    });

    c.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
    {
        Name = "Authorization",
        Type = SecuritySchemeType.Http,
        Scheme = "bearer",
        BearerFormat = "JWT",
        In = ParameterLocation.Header,
        Description = "Enter: Bearer {your token}"
    });

    c.AddSecurityRequirement(new OpenApiSecurityRequirement
    {
        {
            new OpenApiSecurityScheme
            {
                Reference = new OpenApiReference
                {
                    Type = ReferenceType.SecurityScheme,
                    Id = "Bearer"
                }
            },
            new string[] {}
        }
    });
});

// =========================
// JWT
// =========================
builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
.AddJwtBearer(options =>
{
    options.TokenValidationParameters = new TokenValidationParameters
    {
        ValidateIssuer = true,
        ValidateAudience = true,
        ValidateLifetime = true,
        ValidateIssuerSigningKey = true,

        ValidIssuer = builder.Configuration["Jwt:Issuer"],
        ValidAudience = builder.Configuration["Jwt:Audience"],

        IssuerSigningKey = new SymmetricSecurityKey(
            Encoding.UTF8.GetBytes(
                builder.Configuration["Jwt:Key"]
                ?? throw new InvalidOperationException("JWT Key is missing")
            ))
    };
});

// =========================
// Authorization
// =========================
builder.Services.AddAuthorization();

var app = builder.Build();

// =========================
// PIPELINE
// =========================
app.UseSwagger();

app.UseSwaggerUI(c =>
{
    c.SwaggerEndpoint("/swagger/v1/swagger.json", "Skeletix API v1");
    c.RoutePrefix = "swagger";
});

app.UseHttpsRedirection();

// ✅ ADDED CORS MIDDLEWARE (IMPORTANT)
app.UseCors("AllowFrontend");

app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

app.MapGet("/", () => "Skeletix API is running");

app.Run();