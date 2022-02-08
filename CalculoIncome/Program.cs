using System.Globalization;
using CalculoIncome.Entities.Enums;
using CalculoIncome.Entities;
namespace CalculoIncome
{
    class Program
    {
        static void Main(string[] args)
        {

            Console.WriteLine("Enter department´s name:");
            string deptName = Console.ReadLine();
            Console.WriteLine("Enter Worker data:");
            Console.WriteLine("Name:");
            string name = Console.ReadLine();
            Console.WriteLine("Level (Junior/MidLevel/Senior):");
            WorkerLevel workerLevel = Enum.Parse<WorkerLevel>(Console.ReadLine());
            Console.WriteLine("BaseSalary:");
            double baseSalary=Double.Parse(Console.ReadLine(),CultureInfo.InvariantCulture);

            Department dept = new Department(deptName);
            Worker worker = new Worker(name,workerLevel,baseSalary,dept);

            Console.WriteLine("How many contracts to this worker");
            int n = int.Parse(Console.ReadLine());

            for(int i = 1; i <= n; i++)
            {
                Console.WriteLine($"Enter #{i} contract data:");
                Console.WriteLine("Date  (DD/MM/YYYY):");
                DateTime date = DateTime.Parse(Console.ReadLine());
                Console.WriteLine("Value per hour:");
                double valuePerHour = Double.Parse(Console.ReadLine(), CultureInfo.InvariantCulture);
                Console.WriteLine("Duration:");
                int hours = int.Parse(Console.ReadLine());
                HourContract contract = new HourContract(date,valuePerHour,hours);
                worker.AddContract(contract);
             }

            Console.Write("Enter month and year to calculate income");
            string monthAndYear = Console.ReadLine();
            int month = int.Parse(monthAndYear.Substring(0,2));
            int year = int.Parse(monthAndYear.Substring(3, 4));
            Console.WriteLine("Name: "+ worker.Name);
            Console.WriteLine("Department: "+worker.Department.Name);
            Console.WriteLine("Income: " + worker.Income(year, month).ToString()) ;
           
            


        }
    }
}

