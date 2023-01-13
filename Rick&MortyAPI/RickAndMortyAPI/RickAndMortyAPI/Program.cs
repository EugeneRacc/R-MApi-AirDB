using AutoMapper;
using Microsoft.Extensions.Options;
using RickAndMortyAPI;
using RickAndMortyAPI.Middleware;
using RickAndMortyBLL.Interfaces;
using RickAndMortyBLL.Mapper;
using RickAndMortyBLL.Services;
using Swashbuckle.AspNetCore.SwaggerGen;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddVersionedApiExplorer(options =>
{
    options.GroupNameFormat = "'v'VVV";
});
builder.Services.AddTransient<IConfigureOptions<SwaggerGenOptions>, 
    ConfigureSwaggerOptions>();
builder.Services.AddSwaggerGen();
builder.Services.AddScoped<IPersonService, PersonService>();
builder.Services.AddResponseCaching();
builder.Services.AddApiVersioning();
var mapperConfig = new MapperConfiguration(mc =>
{
    mc.AddProfile(new AutoMapperProfile());
});
IMapper mapper = mapperConfig.CreateMapper();
builder.Services.AddSingleton(mapper);
var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseCustomExceptionHandler();

app.UseHttpsRedirection();

app.UseAuthorization();

app.UseApiVersioning();

app.UseResponseCaching();

app.MapControllers();

app.Run();