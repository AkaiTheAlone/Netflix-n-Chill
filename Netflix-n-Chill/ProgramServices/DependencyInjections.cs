using Netflix_n_Chill.Business.Abstractions;
using Netflix_n_Chill.Business.Implementations;
using Netflix_n_Chill.Data.Converter.Implementations;
using Netflix_n_Chill.Repository;
using Netflix_n_Chill.Repository.Generic;
using Netflix_n_Chill.Services;
using Netflix_n_Chill.Services.Implementations;
using System.IO;

namespace Netflix_n_Chill.ProgramServices
{
    public class DependencyInjections
    {
        private IServiceCollection Services { get; set; }
        public DependencyInjections(ref IServiceCollection serviceDescriptors)
        {
            Services = serviceDescriptors;
        }
        public void InjectDependencies()
        {
            Services.AddScoped<IPersonBusiness, PersonBusinessImplementation>();
            Services.AddScoped<IBookBusiness, BookBusinessImplementation>();
            Services.AddScoped<ILoginBussiness, LoginBussiness>();
            Services.AddScoped<BookConverter>();
            Services.AddScoped<PersonConverter, PersonConverter>();
            Services.AddScoped<IUserRepository, UserRepository>();
            Services.AddTransient<ITokenService, TokenService>();
        }

    }
}
