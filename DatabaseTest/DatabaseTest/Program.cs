using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DatabaseTest
{
    class Program
    {
        static void Main(string[] args)
        {
            List<Person> persList = PersonGateway.GetAll();

            foreach (Person pers in persList)
            {
                pers.Print();
            }

            Console.WriteLine("-----------------------");

            Person p = PersonGateway.Get("Paul", "Behofsics");

            if (p != null)
            {
                p.Print();
            }
        }
    }
}
