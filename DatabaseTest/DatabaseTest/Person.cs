using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DatabaseTest
{
    class Person
    {
        public int ID { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string PLZ { get; set; }

        public Person(int id, string firstName, string lastName, string plz)
        {
            ID = id;
            FirstName = firstName;
            LastName = lastName;
            PLZ = plz;
        }

        public void Print()
        {
            Console.WriteLine("ID: {0}", ID);
            Console.WriteLine("  FirstName: {0}", FirstName);
            Console.WriteLine("  LastName: {0}", LastName);
            Console.WriteLine("  PLZ: {0}", PLZ);
        }
    }
}
