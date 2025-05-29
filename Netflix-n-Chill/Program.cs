using Asp.Versioning;
using Microsoft.EntityFrameworkCore;
using Netflix_n_Chill;
using Netflix_n_Chill.Business;
using Netflix_n_Chill.Business.Implementations;
using Netflix_n_Chill.Data.Converter.Implementations;
using Netflix_n_Chill.Repository;
using Netflix_n_Chill.Repository.Generic;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();

//entity
//var SqlConn = builder.Configuration["SqlConnection:ConnectionString"];
var connectionString = builder.Configuration.GetConnectionString("DefaultConnection") ??
                throw new InvalidOperationException("String de conexão 'DefaultConnection' não foi encontrada.");

builder.Services.AddDbContext<AppDbContext>(options => options.UseSqlServer(connectionString));



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

builder.Services.AddScoped<IPersonBusiness, PersonBusinessImplementation>();
builder.Services.AddScoped<IBookBusiness, BookBusinessImplementation>();
builder.Services.AddScoped<BookConverter>();
builder.Services.AddScoped<PersonConverter, PersonConverter>();
//repositories
builder.Services.AddScoped(typeof(IRepository<>), typeof(GenericRepository<>));


//ensure database update
using (var scope = builder.Services.BuildServiceProvider().CreateScope())
{
    var dbContext = scope.ServiceProvider.GetRequiredService<AppDbContext>();
    dbContext.Database.Migrate(); // apply pending migrations
}

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