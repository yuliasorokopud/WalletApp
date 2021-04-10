using System;
using System.Collections.Generic;

namespace AV.ProgrammingWithCSharp.Budgets
{
    class Program
    {
        static void Main(string[] args)
        {
            var budget = new Budget("First Wallet");
            budget.AddTransaction(27.3);
            budget.AddTransaction(4.8);
            budget.AddTransaction(384.486);
            var budget2 = new Budget("Second Wallet");
            budget.AddTransaction(27.3);
            budget.AddTransaction(4.8);
            budget.AddTransaction(384.486);
            var result = budget.GetStatistics();
            var result2 = budget.GetStatistics();

            Console.WriteLine($"The average transaction is ${result:N2}");
            Console.WriteLine($"The lowest transaction is ${result.LowestTransaction} and the highest is ${result.HighestTransaction}.");
        }
    }
}
