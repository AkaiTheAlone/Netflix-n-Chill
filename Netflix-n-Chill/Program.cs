using Microsoft.EntityFrameworkCore;
using Netflix_n_Chill;
using Asp.Versioning;
using Netflix_n_Chill.Business;
using Netflix_n_Chill.Business.Implementations;
using Netflix_n_Chill.Repository;
using Netflix_n_Chill.Repository.Implementations;


var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();

//bank access
builder.
Services.
AddDbContext<AppDbContext>(options =>
                               options.UseMySql(builder.
                                                Configuration["SqlConnection:ConnectionString"],
                                                new MySqlServerVersion(new Version(8, 0, 3))));

//API versioning
builder.Services.AddApiVersioning(options =>
{
    options.AssumeDefaultVersionWhenUnspecified = true;
    options.DefaultApiVersion = new ApiVersion(1, 0);
    options.ReportApiVersions = true;
});

builder.Services.AddEndpointsApiExplorer();

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

//aspnet's dependency injections
builder.Services.AddScoped<IPersonRepository, PersonRepositoryImplementation>();
builder.Services.AddScoped<IPersonBusiness, PersonBusinessImplementation>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
