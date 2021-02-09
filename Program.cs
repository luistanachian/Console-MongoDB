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

            //create instance of db
            var client = new MongoClient("mongodb://localhost:27017");
            var testDB = client.GetDatabase("testDB");
            var employeesDB = testDB.GetCollection<EmployeeModel>("Employees");

            //delete many items
            var deleteResult = employeesDB.DeleteMany(e => true);
            Console.WriteLine($"Console-MongoDB - DeleteMany {deleteResult.DeletedCount} rows");

            //create list object
            var listEmployees = new List<EmployeeModel>();
            for (int i = 0; i < 200; i++)
            {
                var employee = new EmployeeModel
                {
                    Name = RandomText.Name(),
                    LastName = RandomText.LastName(),
                    Age = new Random().Next(18, 100),
                    Status = "Working"
                };
                listEmployees.Add(employee);
            }
            Console.WriteLine($"Console-MongoDB - Create List {listEmployees.Count} rows");

            //insert many from list object
            employeesDB.InsertMany(listEmployees);
            Console.WriteLine($"Console-MongoDB - InsertMany {listEmployees.Count} rows");

            //read items from the DB
            listEmployees = employeesDB.Find(e => e.Age >= 60).ToList();
            Console.WriteLine($"Console-MongoDB - Read Age >= 60: {listEmployees.Count} rows");

            //update list
            foreach (var employee in listEmployees)
            {
                employee.Status = "Retired";
                employeesDB.ReplaceOne(e => e.Id == employee.Id, employee);
            }
            Console.WriteLine($"Console-MongoDB - Update Status == 'Retired': {listEmployees.Count} rows");

            //read items from the DB
            listEmployees = employeesDB.Find(e => e.Status == "Retired").ToList();
            Console.WriteLine($"Console-MongoDB - Read Status == 'Retired': {listEmployees.Count} rows");

            Console.WriteLine();
        }
    }
}
