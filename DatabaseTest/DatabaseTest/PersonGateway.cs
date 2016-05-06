using System;
using System.Collections.Generic;
using System.Data;
using System.Data.OleDb;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DatabaseTest
{
    static class PersonGateway
    {
        /*
            Can be found when rightclicking the database
            in the Server Explorer and choosing Properties.
        */
        private const string connStr =
            @"Provider = Microsoft.ACE.OLEDB.12.0; "
            + @"Data Source = C:\Users\Paul\Documents\"
            + @"Visual Studio 2015\Projects\DatabaseTest\"
            + @"DatabaseTest\Test.accdb";

        public static List<Person> GetAll()
        {
            List<Person> persons = new List<Person>();

            try
            {
                OleDbConnection conn = new OleDbConnection(connStr);
                OleDbCommand cmd = new OleDbCommand(
                    "select * from TestTable;", conn);

                conn.Open();
                OleDbDataReader reader = cmd.ExecuteReader();

                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        Person p = new Person(
                            (int)reader["ID"],
                            (string)reader["FirstName"],
                            (string)reader["LastName"],
                            (string)reader["PLZ"]
                        );

                        persons.Add(p);
                    }
                }
            }
            catch
            {
                Console.WriteLine("Error: Database connection failed");
            }

            return persons;
        }

        public static Person Get(string firstName, string lastName)
        {
            try
            {
                OleDbConnection conn = new OleDbConnection(connStr);
                OleDbCommand cmd = new OleDbCommand(
                    "select * from TestTable where FirstName = '"
                    + firstName + "' and LastName = '" + lastName
                    + "';", conn);

                conn.Open();
                OleDbDataReader reader = cmd.ExecuteReader();

                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        Person p = new Person(
                            (int)reader["ID"],
                            (string)reader["FirstName"],
                            (string)reader["LastName"],
                            (string)reader["PLZ"]
                        );

                        return p;
                    }
                }
            }
            catch
            {
                Console.WriteLine("Error: Database connection failed");
            }

            return null;
        }
    }
}
