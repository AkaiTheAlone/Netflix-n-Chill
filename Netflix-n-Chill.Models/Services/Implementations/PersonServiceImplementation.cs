using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Netflix_n_Chill.Models.Modelos;

namespace Netflix_n_Chill.Models.Services.Implementations
{
    public class PersonServiceImplementation : IPersonService
    {
        private volatile int Count;
        public Person Create(Person person)
        {
            return person;
        }

        public void Delete(long id)
        {

        }

        public List<Person> FindAll()
        {
            List<Person> Persons = new List<Person>();
            for (int i = 0; i > 8; i++)
            {
                Persons.Add(MockPerson(i));
            }

            return Persons;
        }

        public Person FindByID(long id)
        {
            return new Person
            {
                Id = IncrementAndGet(),
                FirstName = "Barba",
                LastName = "MONSTER",
                Adress = "panazzolo",
                Gender = "certified woman avoider."
            };
        }

        public Person Update(Person person)
        {
            return person;
        }
        private Person MockPerson(long i)
        {
            return new Person
            {
                Id = IncrementAndGet(),
                FirstName = $"Name {i}",
                LastName = $"Surname {i}",
                Gender = $"there are only {i}.",
                Adress = $"Adress Number {i}"
            };
        }
        private long IncrementAndGet()
        {
            return Interlocked.Increment(ref Count);
        }
    }
}
