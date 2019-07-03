using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Globalization;
using _03_RLPCSharp.Entities;
using _03_RLPCSharp.Entities.Enums;

namespace _03_RLPCSharp
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.Write("Digite o nome do departamento: ");
            string deptName = Console.ReadLine();

            Console.WriteLine();
            Console.WriteLine("Entre com os dados do trabalhador: ");
            Console.Write("Name: ");
            string name = Console.ReadLine();
            Console.Write("Qual o Nivel do trabalhador (Junior/MidLevel/Senior): ");

            WorkerLevel workerLevel = new WorkerLevel();

            Enum.TryParse<WorkerLevel>(Console.ReadLine(), out workerLevel);

            Console.Write("Salário Base: ");
            double baseSalary = double.Parse(Console.ReadLine(), CultureInfo.InvariantCulture);


            Department dept = new Department(deptName);
            Worker worker = new Worker(name, workerLevel, baseSalary, dept);

            Console.Write("Quantos contratos tem esse trabalhador: #");
            int n = int.Parse(Console.ReadLine());

            for (int i = 1; i <= n; i++)
            {
                Console.WriteLine();
                Console.WriteLine($"Entre com #{i} contrato: ");
                Console.Write("Date (DD/MM/YYYY): ");
                DateTime date = DateTime.Parse(Console.ReadLine());
                Console.Write("Valor por Hora: $");
                double valuerPerHour = double.Parse(Console.ReadLine(), CultureInfo.InvariantCulture);
                Console.Write("Duração (Horas): ");
                int hours = int.Parse(Console.ReadLine());
                HourContract contract = new HourContract(date, valuerPerHour, hours);
                worker.AddContract(contract);
            }
            Console.WriteLine();

            Console.Write("Entre com mês e ano para calcular o ganho (MM/YYYY): ");
            string monthAndYear = Console.ReadLine();
            int month = int.Parse(monthAndYear.Substring(0, 2));
            int year = int.Parse(monthAndYear.Substring(3));
            Console.WriteLine($"Nome: {worker.Name}");
            Console.WriteLine($"Departamento: {worker.Department.Name}");
            Console.WriteLine($"Renda em {monthAndYear}: ${worker.Income(year, month).ToString("F2", CultureInfo.InvariantCulture)}");


        }
    }
}