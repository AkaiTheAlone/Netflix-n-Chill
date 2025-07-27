using Netflix_n_Chill.Business.Abstractions;
using Netflix_n_Chill.Data.Converter.Implementations;
using Netflix_n_Chill.Data.ValueObject;
using Netflix_n_Chill.Models;
using Netflix_n_Chill.Repository.Generic;

namespace Netflix_n_Chill.Business.Implementations
{
    public class PersonBusinessImplementation : IPersonBusiness
    {
        private readonly IRepository<Person> repository;
        private readonly PersonConverter converter;
        public PersonBusinessImplementation(IRepository<Person> _rep)
        {
            repository = _rep;
            converter = new PersonConverter();
        }

        public void Delete(long id)
        {
            repository.Delete(id);
        }

        public PersonVO Create(PersonVO person)
        {
            return converter.Parse(repository.Create(converter.Parse(person)));
        }

        public List<PersonVO> FindAll()
        {
            return converter.Parse(repository.FindAll());
        }
        public PersonVO FindByID(long id)
        {
            return converter.Parse(repository.FindByID(id));
        }

        public PersonVO Update(PersonVO person)
        {
            return converter.Parse(repository.Update(converter.Parse(person)));
        }

    }
}
