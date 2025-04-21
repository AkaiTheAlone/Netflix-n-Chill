using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.DataProtection;
using Microsoft.AspNetCore.Mvc;
using Netflix_n_Chill.Business;
using Netflix_n_Chill.Models;
using Netflix_n_Chill.Repository;
using Netflix_n_Chill.Repository.Implementations;

namespace Netflix_n_Chill.Business.Implementations
{
    public class PersonBusinessImplementation : IPersonBusiness
    {
        //old prop for mocking data
        //private volatile int Count;
        private readonly IPersonRepository repository;
        public PersonBusinessImplementation(IPersonRepository _rep)
        {
            repository = _rep;
        }

        public void Delete(long id)
        {
            repository.Delete(id);
        }

        public Person Create(Person person)
        {
            return repository.Create(person);
        }

        public List<Person> FindAll()
        {
            return repository.FindAll();
        }
        public Person FindByID(long id)
        {
            return repository.FindByID(id);
        }

        public Person Update(Person person)
        {
            return repository.Update(person);
        }

    }
}
