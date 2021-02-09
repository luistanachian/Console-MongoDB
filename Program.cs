using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Console_MongoDB
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Console-MongoDB");

            var client = new MongoClient("mongodb://localhost:27017");
            var testDB = client.GetDatabase("testDB");
            var employeesDB = testDB.GetCollection<EmployeeModel>("Employees");

            var starDate = DateTime.Now;
            var deleteResult = employeesDB.DeleteMany(e => true);
            
            Console.WriteLine($"Console-MongoDB - DeleteMany {deleteResult.DeletedCount} rows {(DateTime.Now - starDate).TotalSeconds}");

            starDate = DateTime.Now;
            var listEmployees = new List<EmployeeModel>();
            for (int i = 0; i < 1000000; i++)
            {
                var employee = new EmployeeModel
                {
                    Name = RandomText.RandomName(),
                    Age = new Random().Next(18, 60),
                    Sex = RandomText.RandomSex()
                };
                listEmployees.Add(employee);
            }
            Console.WriteLine($"Console-MongoDB - Create List {listEmployees.Count} rows {(DateTime.Now - starDate).TotalSeconds}");

            starDate = DateTime.Now;
            employeesDB.InsertMany(listEmployees);
            Console.WriteLine($"Console-MongoDB - InsertMany {listEmployees.Count} rows {(DateTime.Now - starDate).TotalSeconds}");

            starDate = DateTime.Now;
            listEmployees = employeesDB.Find(e => e.Age >= 45).ToList();
            Console.WriteLine($"Console-MongoDB - Read {listEmployees.Count} rows {(DateTime.Now - starDate).TotalSeconds}");
            Console.WriteLine();
        }
    }
}
