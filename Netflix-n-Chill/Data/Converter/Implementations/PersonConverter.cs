using Netflix_n_Chill.Data.Converter.Contract;
using Netflix_n_Chill.Data.ValueObject;
using Netflix_n_Chill.Models;

namespace Netflix_n_Chill.Data.Converter.Implementations
{
    public class PersonConverter : IParser<Person, PersonVO>, IParser<PersonVO, Person>
    {
        public PersonVO Parse(Person origin)
        {

            if (origin == null) return null;

            return new PersonVO
            {
                Address = origin.Address,
                Gender = origin.Gender,
                FirstName = origin.FirstName,
                Id = origin.Id,
                LastName = origin.LastName
            };
        }
        public List<PersonVO> Parse(List<Person> origin)
        {
            if (origin == null) return null;
            return origin.Select(x => Parse(x)).ToList();
        }

        public Person Parse(PersonVO origin)
        {
            if (origin == null) return null;

            return new Person
            {
                Address = origin.Address,
                Gender = origin.Gender,
                FirstName = origin.FirstName,
                Id = origin.Id,
                LastName = origin.LastName
            };
        }

        public List<Person> Parse(List<PersonVO> origin)
        {
            if (origin == null) return null;

            return origin.Select(x => Parse(x)).ToList();
        }
    }
}
