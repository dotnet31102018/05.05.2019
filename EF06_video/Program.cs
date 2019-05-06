using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EF0605
{
    class Program
    {
        static void Main(string[] args)
        {
            using (GlobeEntities1 entities = new GlobeEntities1())
            {
                // 1 students
                entities.Students.ToList().ForEach(s => Console.WriteLine(JsonConvert.SerializeObject(s)));

                Console.WriteLine();
                // 2 counries
                entities.Countries.ToList().ForEach(c => Console.WriteLine(JsonConvert.SerializeObject(c)));

                Console.WriteLine();
                Console.WriteLine("Students starts with 'V'");
                // 3 students starts with s
                entities.Students.Where(s => s.NAME.ToUpper().StartsWith("V")).ToList().ForEach(s => Console.WriteLine(JsonConvert.SerializeObject(s)));

                Console.WriteLine();
                Console.WriteLine("Students order by - by name");
                // 4 students starts with s
                entities.Students.OrderBy(s => s.NAME).ToList().ForEach(s => Console.WriteLine(JsonConvert.SerializeObject(s)));

                Console.WriteLine();
                Console.WriteLine("Students order by - by name - then by country id");
                // 5 students starts with s
                entities.Students.OrderBy(s => s.NAME).ThenBy(s => s.COUNTRY_ID).ToList().ForEach(s => Console.WriteLine(JsonConvert.SerializeObject(s)));

                //entities.Students.Add(new Student { NAME = "Hazan", COUNTRY_ID = 1 });
                //entities.SaveChanges();

                //entities.Students.Take(1).FirstOrDefault().NAME = "new name";
                //entities.SaveChanges();

                // entities.Students.Remove(entities.Students.Take(1).FirstOrDefault());
                //entities.SaveChanges();

                entities.Students.Join(entities.Countries,
                    s => s.COUNTRY_ID,
                    c => c.ID,
                    (s, c) => new
                    {
                        Student_ID = s.ID,
                        Studnet_Name = s.NAME,
                        Student_Country_ID = s.COUNTRY_ID,
                        Country_ID = c.ID,
                        Country_Name = c.NAME
                    }).ToList().ForEach(s => Console.WriteLine(JsonConvert.SerializeObject(s)));

                Console.WriteLine();
            }
        }
    }
}
