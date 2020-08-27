using System;
using System.Collections.Generic;
using System.Linq;

namespace GW.AspNetTraining.LinqPlayground
{
    class Program
    {
        static void Main(string[] args)
        {

            //var result = PersonRepository.Persons.Select(x=>x.FirstName);
            //var result = PersonRepository.Persons.Select(x => $"{x.FirstName} {x.Name}");
            //var result = PersonRepository.Persons.Select(x=> new
            //{
            //    Name = x.Name,
            //    Vorname = x.FirstName,
            //    Geburtstag = x.Birthday
            //});

            //var result = PersonRepository.Persons.Select((item, index) => new { Index = index, Person = item });
            //var result = PersonRepository.Persons.SelectMany(x => x.PhoneNumers);

            //var query = from p in PersonRepository.Persons
            //            select p.FirstName;

            //var result = PersonRepository.Persons.Where(x => x.Address.City == "Hamburg");
            //var result = PersonRepository.Persons.Where(x => x.Address.City.IndexOf('H') >= 0);
            //var result = PersonRepository.Persons.First(x => x.Address.City == "Leipzig");
            //var result = PersonRepository.Persons.Where(x=>x.Address.City == "b")
            //    .Select(x=>x.Birthday).FirstOrDefault();

            //var result = PersonRepository.Persons.TakeWhile(x => x.Title == "Frau");
            var result = PersonRepository.Persons.OrderBy(x => x.Address);


            //var result = PersonRepository.Persons.OrderBy(x=>x);

            //var result = PersonRepository.Persons.GroupBy(x => x.Address.City).FirstOrDefault(c=>c.Key == "Hamburg");

            // 1) Suche alle Personen die  kein Telefon haben.
            //var result = PersonRepository.Persons.Where(x => !x.PhoneNumers.Any());

            // 2) Suche alle Personen die zwei oder mehr Telefone haben.
            //var result = PersonRepository.Persons.Where(x => x.PhoneNumers.Count() >= 2);

            // 3) Suche alle Personen die noch keine 40 Jahrea alt sind.
            //var result = PersonRepository.Persons.Where(x => DateTime.Now.AddYears(-40) < x.Birthday);

            // 4) Projizieren für alle Personen Title, Vorname und Nachname als ein Text, sortiert nach Titel und Nachname

            //var result = PersonRepository.Persons.OrderBy(x => x.Title).ThenBy(x => x.Name)
            //    .Select(x => $"{x.Title} {x.FirstName} {x.Name}");

            // 5) Suche alle Personen die zusammen wohnen (gleiche Anschrift)

            //var result = PersonRepository.Persons.GroupBy(x => new
            //{
            //    City = x.Address.City,
            //    Street = x.Address.Street,
            //    Zip = x.Address.ZipCode,
            //    Number = x.Address.Number
            //}).Where(x => x.Count() >= 2);

            //6) Suche den ältesten Mann.
            //var result = PersonRepository.Persons.Where(x => x.Title == "Herr").OrderBy(x => x.Birthday).First();
            //var min = PersonRepository.Persons.Where(x => x.Title == "Herr").Min(d => d.Birthday);
            //var result = PersonRepository.Persons.First(x => x.Birthday == min);

            // 7) Suche die erste Person aus Berlin, wenn vorhanden
            //var result = PersonRepository.Persons.Where(x => x.Address.City == "Berlin").FirstOrDefault();

            Print(result);

            Console.ReadLine();

        }

        public static void Print(object obj)
        {
            if (obj is IEnumerable<IGrouping<object, object>> groupedObject)
            {
                obj = groupedObject.Select(x => new
                {
                    Key = x.Key,
                    Items = x.ToArray()
                }).ToArray();
            }

            Console.WriteLine(JsonHelper.JsonPrettify(obj));

        }


    }
}
