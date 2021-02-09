using Console_MongoDB.Models;
using MongoDB.Driver;
using System;

namespace Console_MongoDB
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Console-MongoDB");

            var client = new MongoClient("mongodb://localhost:27017");
            var testDB = client.GetDatabase("testDB");
            var employeesDB = testDB.GetCollection<Employees>("Employees");

            var employee = new Employees { Name = "Luis", Age = 31 };

            employeesDB.InsertOne(employee);
        }
    }
}
