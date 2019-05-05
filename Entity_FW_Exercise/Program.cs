using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace EF0505
{
    class Program
    {
        static void Main(string[] args)
        {
            // example for json serialize - instead of implementing ToString
            Person per = new Person()
            {
                Id = 1,
                Name = "Roy",
                Age = 12,
                City_ID = 12
            };
            Console.WriteLine(JsonConvert.SerializeObject(per));

            // DB Exercise
            using (Entities entities = new Entities())
            {
                // 1. Print all 
                Console.WriteLine("Print all: ");
                entities.Persons.ToList().ForEach(r => Console.WriteLine(JsonConvert.SerializeObject(r)));

                // 2. Print where age > 30
                Console.WriteLine("\nPrint for age > 30: ");
                entities.Persons.Where(p => p.Age > 30).ToList().ForEach(r => Console.WriteLine(JsonConvert.SerializeObject(r)));

                // 3. Print sort by Name
                Console.WriteLine("\nPrint sort by name: ");
                entities.Persons.OrderBy(p => p.Name).ToList().ForEach(r => Console.WriteLine(JsonConvert.SerializeObject(r)));

                // 4. Join between person and city table and print 
                Console.WriteLine("\nPrint join tables: ");
                entities.Persons.Join(entities.Cities,
                                                person => person.City_ID,
                                                city => city.Id,
                                                (person, city) => new
                                                {
                                                    Person_ID = person.Id,
                                                    Peron_Name = person.Name,
                                                    City_Name = city.Name,
                                                    City_ID = city.Id
                                                }).ToList().ForEach(r => Console.WriteLine(JsonConvert.SerializeObject(r)));

                // 5. Print sort by Name, then Age
                Console.WriteLine("\nPrint sort by name + age: ");
                entities.Persons.OrderBy(p => p.Name).ThenBy(p => p.Age).ToList().ForEach(r => Console.WriteLine(JsonConvert.SerializeObject(r)));

                // for Add to work, you must have a PRIMARY KEY defined in the table
                entities.Persons.Add(new Person {Name = "Incognito", Age = 12,City_ID = 1 });

                // update first row - changes name to "new name"
                entities.Persons.Take(1).FirstOrDefault().Name = "new name";

                // delete first person named "incognito"
                entities.Persons.Remove( entities.Persons.Where(p => p.Name.ToUpper() == "INCOGNITO").FirstOrDefault() );

                // for changes to be saved you must call save changes
                entities.SaveChanges();
            }
        }
    }
}
