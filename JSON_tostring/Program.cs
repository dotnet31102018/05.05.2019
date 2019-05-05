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
            Person p = new Person()
            {
                Id = 1,
                Name = "Roy",
                Age = 12,
                City_ID = 12
            };
            Console.WriteLine(JsonConvert.SerializeObject(p));
        }
    }
}
