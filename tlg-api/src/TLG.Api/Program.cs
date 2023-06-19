using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using Microsoft.OpenApi.Models;
using TLG.Api.Security;
using TLG.Application.AutoMapper;
using TLG.Application.Interfaces;
using TLG.Application.Services;
using TLG.Core.Repositories;
using TLG.Core.Repositories.Base;
using TLG.Infrastructure.Data;
using TLG.Infrastructure.Repositories;
using TLG.Infrastructure.Repositories.Base;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(c =>
            {
              c.SwaggerDoc("v1", new OpenApiInfo { Title = "TLG.api", Version = "v1" });
              c.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
              {
                Description = "Exemplo: \"bearer {token}\"",
                In = ParameterLocation.Header,
                Name = "Authorization",
                Type = SecuritySchemeType.ApiKey
              });

              c.AddSecurityRequirement(new OpenApiSecurityRequirement()
                {
                    {
                        new OpenApiSecurityScheme
                        {
                            Reference = new OpenApiReference
                            {
                                Type = ReferenceType.SecurityScheme,
                                Id = "Bearer"
                            },
                            Scheme = "oauth2",
                            Name = "Bearer",
                            In = ParameterLocation.Header,

                        },
                        new List<string>()
                    }
                });
            });

builder.Services.AddDbContext<Context>(options =>
{
  options.UseSqlServer(builder.Configuration.GetConnectionString("MSSQL"));
});

builder.Services.AddDbContext<ApiSecurityDbContext>(options =>
{
  options.UseSqlServer(builder.Configuration.GetConnectionString("MSSQL"));
});

builder.Services.AddAutoMapper(typeof(MappingProfile));

var tokenConfigurations = new TokenConfigurations();
new ConfigureFromConfigurationOptions<TokenConfigurations>(
    builder.Configuration.GetSection("TokenConfigurations"))
        .Configure(tokenConfigurations);

builder.Services.AddJwtSecurity(tokenConfigurations);

builder.Services.AddScoped<IdentityInitializer>();

builder.Services.AddScoped(typeof(IRepository<>), typeof(Repository<>));
builder.Services.AddScoped<IContentRepository, ContentRepository>();
builder.Services.AddScoped<IContentService, ContentService>();
builder.Services.AddScoped<IWishlistRepository, WishlistRepository>();
builder.Services.AddScoped<IWishlistService, WishlistService>();

builder.Services.AddCors(options =>
    {
      options.AddPolicy("Allow",
          builder =>
          {
            builder.AllowAnyOrigin()
                     .AllowAnyMethod()
                     .AllowAnyHeader();
          });
    });

var app = builder.Build();

app.UseCors("Allow");

// Configure the HTTP request pipeline.
app.UseSwagger();
app.UseSwaggerUI(c =>
{
  c.SwaggerEndpoint("/swagger/v1/swagger.json", "TLG.api v1");
  c.RoutePrefix = string.Empty;
});

app.UseHttpsRedirection();

app.UseAuthorization();

using var scope = app.Services.CreateScope();
scope.ServiceProvider.GetRequiredService<IdentityInitializer>().Initialize();
var services = scope.ServiceProvider;
var context = services.GetRequiredService<Context>();
PostSeed.Seed(context).Wait();

app.UseAuthorization();

app.MapControllers();

app.Run();
