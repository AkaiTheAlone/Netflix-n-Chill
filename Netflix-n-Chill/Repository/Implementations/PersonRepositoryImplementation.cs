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
        //old prop for mocking data
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

            #region old mocking data
            //old mocking data
            //List<Person> Persons = new List<Person>();
            //for (int i = 0; i < 8; i++)
            //{
            //    Persons.Add(MockPerson(i));
            //}
            //return Persons;
            #endregion
        }
        public Person FindByID(long id)
        {
            return context.Person.SingleOrDefault(p => p.Id.Equals(id));
            #region old mocking data
            //return new Person
            //{
            //    Id = 1,
            //    FirstName = "Barba",
            //    LastName = "MONSTER",
            //    Adress = "panazzolo",
            //    Gender = "certified woman avoider."
            //};
            #endregion
        }

        public Person Update(Person person)
        {
            //if person does not exists
            if (!Exists(person.Id)) return new Person();

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

        #region old mocking data

        //private Person MockPerson(long i)
        //{
        //    return new Person
        //    {
        //        Id = 1,
        //        FirstName = $"Name {i}",
        //        LastName = $"Surname {i}",
        //        Gender = $"there are only {i}.",
        //        Adress = $"Adress Number {i}"
        //    };
        //}
        //private long IncrementAndGet()
        //{
        //    return Interlocked.Increment(ref Count);
        //}
        #endregion

    }
}
