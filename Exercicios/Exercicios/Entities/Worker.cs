using System;
using System.Collections.Generic;
using System.Diagnostics.Contracts;
using Exercicios.Entities.Enums;

namespace Exercicios.Entities
{
    internal class Worker
    {
        public string Name { get; set; }
        //Passa a ser uma propriedade da classe atual
        WorkLevel Level { get; set; }
        public double baseSalary { get; set; }
        public Department Department { get; set; }
        List<HourContract> Contract = new List<HourContract>();

        public Worker()
        {
        }
        //Como teremos muitos contratos para um trabalhador, então precisaremos dos contratos em uma lista, entretanto, não é usual passar uma associação para muitos, dentro de um construtor.
        public Worker(string name, WorkLevel level, double baseSalary, Department department)
        {
            Name = name;
            Level = level;
            this.baseSalary = baseSalary;
            Department = department;
        }
                            //Recebe a lista e uma variavel para entrada
        public void AddContract(HourContract contract)
        {   //Adicionar na lista criada o novo contrado, no caso Contract é a lista criada de Contratos e contract é referente ao novo contrato
            Contract.Add(contract);
        }

        public void RemoveContract(HourContract contract) {  
            Contract.Remove(contract);
        }

        public double Income(int year, int month)
        {   //cria variavel soma temporario para armazenar o salario base
            double soma = baseSalary;

            //cria o laço for each para modicar o trabalhador utilizando a var obj
            foreach(HourContract obj in Contract) {
                    //Passa o argumento de entrada comparando com o objeto, muito importante a função
                if (obj.Date.Year == year && obj.Date.Month == month)
                {   //soma o salario base e utiliza a função criada na classe dos contratos
                    soma += obj.TotalValue();
                    
                }
            }
            return soma;
        }

    }
}
