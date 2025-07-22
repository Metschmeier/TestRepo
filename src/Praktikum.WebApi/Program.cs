using FluentValidation.AspNetCore;
using Microsoft.EntityFrameworkCore;
using Praktikum.Services.Data;
using Praktikum.Services.Repository;
using Praktikum.Types;
using Praktikum.WebApi.Validation;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContext<BuchhaltungDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

builder.Services.AddScoped<IBuchhaltungRepository, EfBuchhaltungRepository>();

builder.Services.AddControllers()
    .AddFluentValidation(fv => fv.RegisterValidatorsFromAssemblyContaining<BuchhaltungszeileDtoValidator>());

builder.Services.AddDbContext<PartnerDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

builder.Services.AddScoped<IPartnerRepository, EfPartnerRepository>();

builder.Services.AddControllers()
    .AddFluentValidation(fv => fv.RegisterValidatorsFromAssemblyContaining<PartnerzeileDtoValidator>());

builder.Services.AddDbContext<SteuersatzDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

builder.Services.AddScoped<ISteuersatzRepository, EfSteuersatzRepository>();

builder.Services.AddControllers()
    .AddFluentValidation(fv => fv.RegisterValidatorsFromAssemblyContaining<SteuersatzzeileDtoValidator>());

builder.Services.AddDbContext<KostenstelleDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

builder.Services.AddScoped<IKostenstelleRepository, EfKostenstelleRepository>();

builder.Services.AddControllers()
    .AddFluentValidation(fv => fv.RegisterValidatorsFromAssemblyContaining<KostenstellezeileDtoValidator>());

builder.Services.AddDbContext<KategorieDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

builder.Services.AddScoped<IKategorieRepository, EfKategorieRepository>();

builder.Services.AddControllers()
    .AddFluentValidation(fv => fv.RegisterValidatorsFromAssemblyContaining<KategoriezeileDtoValidator>());

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

//app.UseAuthorization();

app.MapControllers();

app.Run();