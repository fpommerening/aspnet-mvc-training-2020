using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LinqPlayground
{
    public class PersonRepository
    {
        private static List<PersonEntity> personEntities = new List<PersonEntity>
        {
            new PersonEntity
            {
                Address = new AddressEntity
                {
                    City = "Leipzig",
                    Number = "92c",
                    Street = "Gerichtsweg",
                    ZipCode = "04103"
                },
                Birthday = new DateTime(1972, 6, 24),
                FirstName = "Sabine",
                Name = "Müller",
                Title = "Frau",
                PhoneNumers = new[]
                {
                    "0177 10172248",
                    "0341 66061036"
                }
            },
            new PersonEntity
            {
                Address = new AddressEntity
                {
                    City = "Leipzig",
                    Number = "92c",
                    Street = "Gerichtsweg",
                    ZipCode = "04103"
                },
                Birthday = new DateTime(1968, 6, 24),
                FirstName = "Joachim",
                Name = "Müller",
                Title = "Herr",
                PhoneNumers = new[]
                {
                    "0172 10172248",
                    "0341 66061036"
                }
            },
            new PersonEntity
            {
                Address = new AddressEntity
                {
                    City = "Leipzig",
                    Number = "7",
                    Street = "Carlebachstraße",
                    ZipCode = "04357"
                },
                Birthday = new DateTime(1988, 11, 19),
                FirstName = "Kevin",
                Name = "Eisleben",
                Title = "Herr",
                PhoneNumers = new []
                {
                    "01531 92116667"
                }
            },
            new PersonEntity
            {
                Address = new AddressEntity
                {
                    City = "Hamburg",
                    Number = "64g",
                    Street = "Rotenhäuser Straße",
                    ZipCode = "21107"
                },
                Birthday = new DateTime(1979, 3, 9),
                FirstName = "Jens",
                Name = "Lehmann",
                Title = "Herr",
                PhoneNumers = new []
                {
                    "040 5077067",
                    "0177 71187367"
                }
            },
            new PersonEntity
            {
                Address = new AddressEntity
                {
                    City = "Hamburg",
                    Number = "117",
                    Street = "Langenfelder Straße",
                    ZipCode = "22769"
                },
                Birthday = new DateTime(1951, 3, 9),
                FirstName = "Rosemaria",
                Name = "Amwirkel",
                Title = "Frau",
                PhoneNumers = new []
                {
                    "040 2382291"
                }
            }
        };
             
        public static IEnumerable<PersonEntity> Persons => personEntities;
    }
}
