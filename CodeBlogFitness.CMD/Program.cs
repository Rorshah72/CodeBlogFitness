using CodeBlogFitness.BL.Controller;
using System;

namespace CodeBlogFitness.CMD
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Вас вiтає додаток CodeBlogFitness. ");
            Console.WriteLine("Введiть iмя користуваача: ");
            var name = Console.ReadLine();

            Console.WriteLine("Введiть стать користуваача: ");
            var genderName = Console.ReadLine();

            Console.WriteLine("Введiть дату народження користуваача: ");
            var birthDate = DateTime.Parse(Console.ReadLine()); //TODO: переписати.

            Console.WriteLine("Введiть вагу користуваача: ");
            var weight = double.Parse(Console.ReadLine());

            Console.WriteLine("Введiть рiст користуваача: ");
            var height = double.Parse(Console.ReadLine());


            var userController = new UserController(name, genderName, birthDate, weight, height);

            userController.Save();


        }
    }
}
