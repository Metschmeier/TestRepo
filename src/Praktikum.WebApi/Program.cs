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

builder.Services.AddScoped<IPartnerRepository, EfPartnerRepository>();

builder.Services.AddControllers()
    .AddFluentValidation(fv => fv.RegisterValidatorsFromAssemblyContaining<PartnerzeileDtoValidator>());

builder.Services.AddScoped<ISteuersatzRepository, EfSteuersatzRepository>();

builder.Services.AddControllers()
    .AddFluentValidation(fv => fv.RegisterValidatorsFromAssemblyContaining<SteuersatzzeileDtoValidator>());

builder.Services.AddScoped<IKostenstelleRepository, EfKostenstelleRepository>();

builder.Services.AddControllers()
    .AddFluentValidation(fv => fv.RegisterValidatorsFromAssemblyContaining<KostenstellezeileDtoValidator>());

builder.Services.AddScoped<IKategorieRepository, EfKategorieRepository>();

builder.Services.AddControllers()
    .AddFluentValidation(fv => fv.RegisterValidatorsFromAssemblyContaining<KategoriezeileDtoValidator>());

builder.Services.AddAutoMapper(typeof(Program));

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

using (var scope = app.Services.CreateScope())
{
    var db = scope.ServiceProvider
                  .GetRequiredService<BuchhaltungDbContext>();
    db.Database.Migrate();
}




app.Run();