using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using TonightPerfume.API;
using TonightPerfume.Data;
using TonightPerfume.Domain.Security;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddCors(options =>
{
    options.AddPolicy("DesktopLocalPolicy", builder => builder
                       .WithOrigins("https://localhost:3000")
                       .AllowAnyHeader()
                       .AllowAnyMethod()
                       .AllowCredentials());
    options.AddPolicy("MobileLocalPolicy", builder => builder
                       .WithOrigins("https://192.168.100.4:3000")
                       .AllowAnyHeader()
                       .AllowAnyMethod());
    options.AddPolicy("AllowAllPolicy", builder => builder
                       .AllowAnyOrigin()
                       .AllowAnyHeader()
                       .AllowAnyMethod());
});

builder.Services.AddControllers();

var connection = builder.Configuration.GetConnectionString("DefaultConnection");
builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseMySql(connection, ServerVersion.AutoDetect(connection), b => b.MigrationsAssembly("TonightPerfume.API"))
);

builder.Services.InitializeRepositories();
builder.Services.InitializeServices();

builder.Services.AddAuthentication(options =>
    {
        options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
        options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
        options.DefaultScheme = JwtBearerDefaults.AuthenticationScheme;
    })
    .AddJwtBearer(options =>
    {
        options.IncludeErrorDetails = true;
        options.TokenValidationParameters = SecurityConfig.GetValidationParameters();

        //new TokenValidationParameters
        //{
        //    ValidateIssuer = true,
        //    ValidIssuer = SecurityConfig.ISSUER,
        //    ValidateAudience = true,
        //    ValidAudience = SecurityConfig.AUDIENCE,
        //    ValidateLifetime = true,
        //    IssuerSigningKey = SecurityConfig.GetSymmetricAccessKey(),
        //    ValidateIssuerSigningKey = true
        //};
    });

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(option =>
{
    option.SwaggerDoc("v1", new OpenApiInfo { Title = "Demo API", Version = "v1" });
    option.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
    {
        In = ParameterLocation.Header,
        Description = "Please enter a valid token",
        Name = "Authorization",
        Type = SecuritySchemeType.Http,
        BearerFormat = "JWT",
        Scheme = "Bearer"
    });
    option.AddSecurityRequirement(new OpenApiSecurityRequirement
    {
        {
            new OpenApiSecurityScheme
            {
                Reference = new OpenApiReference
                {
                    Type=ReferenceType.SecurityScheme,
                    Id="Bearer"
                }
            },
            new string[]{}
        }
    });
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseCors("DesktopLocalPolicy");

app.UseAuthentication();
app.UseAuthorization();


app.MapControllers();

app.Run();
