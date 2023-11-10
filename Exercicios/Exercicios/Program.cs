/* 
  
Ler os dados de um trabalhador com N contratos (N fornecido pelo usuário). 
Depois, solicitar do usuário um mês e mostrar qual foi o salário do funcionário nesse mês, conforme exemplo (próxima página). 
 
*/

using Exercicios.Entities.Enums;
using System.Globalization;
using System;
using Exercicios.Entities;

namespace Exercicios;

class Program
{
    public static void Main()
    {
        Console.Write("Enter department's name: ");
        string depName = Console.ReadLine();
        Console.WriteLine("Enter worker data:");
        Console.Write("Name: ");
        string workName = Console.ReadLine();
        Console.Write("Level (Junior/MidLevel/Senior): ");
        //Reponsável por converter a string em int, aqui temos a demonstração do Enum
        WorkLevel workLevel = Enum.Parse<WorkLevel>(Console.ReadLine());
        Console.Write("Enter base salary: ");
        double salary = double.Parse(Console.ReadLine(), CultureInfo.InvariantCulture);

        //Instanciar a classe departamento
        Department department = new Department(depName);

        //Instanciar o trabalhador , passar também o departamento dentro 
        Worker worker = new Worker(workName, workLevel, salary, department);

        Console.Write("How many contracts to this worker? ");
        int numOfContracts = int.Parse(Console.ReadLine());

        for (int i = 0; i < numOfContracts; i++)
        {
            Console.WriteLine($"Enter #{i + 1} contract data: ");
            Console.Write("Date (DD/MM/YYYY): ");
            //O metodo datetime com o uso do parse aceita a / no formato da data
            DateTime date = DateTime.Parse(Console.ReadLine());
            Console.Write("Value per hour: ");
            double valorHora = double.Parse(Console.ReadLine(), CultureInfo.InvariantCulture);
            Console.Write("Duration (hours): ");
            int horas = int.Parse(Console.ReadLine());

            //Instância a classe hourcontract com a sobrecarga
            HourContract contract = new HourContract(date, valorHora, horas);

            //Adiciona contrato ao trabalhador
            worker.AddContract(contract);
        }
        Console.WriteLine();
        Console.WriteLine("Enter month and year to calculate income (MM/YYYY): ");
        string monthOfYear = Console.ReadLine();
        int month = int.Parse(monthOfYear.Substring(0, 2));
        int year  = int.Parse(monthOfYear.Substring (3));
        Console.WriteLine($"Name: {worker.Name}");
        Console.WriteLine($"Department: {worker.Department.Name}");
        Console.WriteLine($"Income for {monthOfYear}: {worker.Income(year, month).ToString("F2", CultureInfo.InvariantCulture)}");
    }
}