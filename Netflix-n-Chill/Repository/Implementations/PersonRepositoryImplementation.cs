using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Netflix_n_Chill.Business;
using Netflix_n_Chill.Models;
using Netflix_n_Chill.Repository;

namespace Netflix_n_Chill.Repository.Implementations
{
    public class PersonRepositoryImplementation : IPersonRepository
    {
        //private volatile int Count;
        private AppDbContext context;
        public PersonRepositoryImplementation(AppDbContext _context)
        {
            context = _context;
        }

        public void Delete(long id)
        {
            var result = context.Person.SingleOrDefault(p => p.Id.Equals(id));

            if (result != null)
            {
                try
                {
                    context.Person.Remove(result);
                    context.SaveChanges();
                }
                catch { throw; }
            }
        }

        public Person Create(Person person)
        {
            try
            {
                context.Add(person);
                context.SaveChanges();
            }
            catch { throw; }

            return person;
        }

        public List<Person> FindAll()
        {
            //return context.Persons.ToList();
            return [.. context.Person]; //both ways work
        }
        public Person FindByID(long id)
        {
            return context.Person.SingleOrDefault(p => p.Id.Equals(id));
        }

        public Person Update(Person person)
        {
            //if person does not exists
            if (!Exists(person.Id)) return null;

            var result = context.Person.SingleOrDefault(p => p.Id.Equals(person.Id));
            if (result != null)
            {
                try
                {
                    //get the old values by entry and set its values to the new values received by the api
                    context.Entry(result).CurrentValues.SetValues(person);
                    context.SaveChanges();

                }
                catch { throw; }
            }
            return person;
        }
        public bool Exists(long id)
        {
            return context.Person.Any(p => p.Id.Equals(id));
        }

    }
}
