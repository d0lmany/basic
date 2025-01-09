using System;

namespace bool_calc
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string expression;
            if (args.Length == 0)
            {
                Console.WriteLine("Enter the expression:");
                expression = Console.ReadLine();
            }
            else
            {
                Console.WriteLine("Current expression:");
                expression = args[0];
            }
            Console.WriteLine(expression);
        }
    }
}