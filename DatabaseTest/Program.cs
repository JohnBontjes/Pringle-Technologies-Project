using System;
using System.Data.SqlClient;

namespace DatabaseTest
{
    class Program
    {
        static void Main(string[] args)
        {
            // test the database connection
            // debug prints around it to make sure everything went smoothly
            Console.WriteLine("Starting Program");
            var db = new DB("CustomerInfo");
            Console.WriteLine("Everything Worked");
            
        }
    }
    // Class to handle database interactions
    // pass in database name to constructor and be connected to database
    // will add methods of using the connection later when the project is farther along
    class DB
    {
        private SqlConnection conn;
        public DB(String dbname)
        {
            // setup the connection and print debug messages to make sure the connection was successful
            try
            {
                String conString = @"Data Source=localhost\SQLEXPRESS;Initial Catalog=" + dbname + ";Integrated Security=True";
                conn = new SqlConnection(conString);
                Console.WriteLine("Connection Successful");
            }
            catch (Exception ex)
            {
                Console.WriteLine("Failed to connect");
                Console.WriteLine("Error Occurred: " + ex);
            }
        }
    }
}
