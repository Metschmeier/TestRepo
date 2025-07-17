using Praktikum.WebApi.Repositories;
using FluentValidation.AspNetCore;
using Praktikum.WebApi.Validation;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddSingleton<IBuchhaltungRepository, FileBuchhaltungRepository>();

builder.Services
    .AddControllers()
    .AddFluentValidation(config => config.RegisterValidatorsFromAssemblyContaining<BuchhaltungszeileDtoValidator>());

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseAuthorization();

app.MapControllers();

app.Run();