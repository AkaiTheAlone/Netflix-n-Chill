using Asp.Versioning;
using Microsoft.EntityFrameworkCore;
using Microsoft.Net.Http.Headers;
using Microsoft.OpenApi.Models;
using Netflix_n_Chill;
using Netflix_n_Chill.Business;
using Netflix_n_Chill.Business.Implementations;
using Netflix_n_Chill.Data.Converter.Implementations;
using Netflix_n_Chill.Hypermedia.Enricher;
using Netflix_n_Chill.Hypermedia.Filters;
using Netflix_n_Chill.Repository.Generic;

internal class Program
{
    private static void Main(string[] args)
    {
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

        builder.Services.AddCors(o => o.AddDefaultPolicy(builder =>
        {
            builder.AllowAnyOrigin().AllowAnyHeader();
        }));

        builder.Services.AddEndpointsApiExplorer();

        // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
        builder.Services.AddEndpointsApiExplorer();
        builder.Services.AddSwaggerGen(c =>
        {
            c.SwaggerDoc("v1", new OpenApiInfo
            {
                Title = "Netflix & Chill",
                Version = "v1",
                Description = "Restful API",
                Contact = new OpenApiContact
                {
                    Name = "Barbaman",
                    Url = new Uri("https://github.com/AkaiTheAlone")
                },
            });
        });

        var filterOptions = new HypermediaFilterOptions();
        filterOptions.ContentResponseEnricherList.Add(new PersonEnricher());

        builder.Services.AddSingleton(filterOptions);

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

        builder.Services.AddMvcCore(o =>
        {
            o.RespectBrowserAcceptHeader = true;
            o.FormatterMappings.SetMediaTypeMappingForFormat("xml", MediaTypeHeaderValue.Parse("application/xml"));
            o.FormatterMappings.SetMediaTypeMappingForFormat("json", MediaTypeHeaderValue.Parse("application/json"));
        }).AddXmlSerializerFormatters();

        var app = builder.Build();

        // Configure the HTTP request pipeline.
        if (app.Environment.IsDevelopment())
        {
            app.UseSwagger();
            app.UseSwaggerUI();
        }

        app.UseHttpsRedirection();

        app.UseAuthorization();


        //this feature is deprecated, not usable in .net core 8 
        //app.UseEndpoints(endpoints =>
        //{
        //endpoints.MapControllers();
        //endpoints.MapAreaControllerRoute("DefaultApi", "{controller=values}/{id?}");
        //);

        app.MapControllers();
        app.MapControllerRoute("DefaultApi", "{controller=values}/{id?}");

        app.Run();
    }
}