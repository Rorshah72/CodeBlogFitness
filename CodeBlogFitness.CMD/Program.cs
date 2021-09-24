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

            var userController = new UserController(name);
            if (userController.IsNewUser)
            {
                Console.WriteLine("Введiть стать користуваача: ");
                var gender = Console.ReadLine();
                var birthDate = ParseDateTime();
                var weight = ParseDouble("вагу");
                var height = ParseDouble("рiст");
                

                userController.SetNewUserData(gender, birthDate, weight, height);
            }

            Console.WriteLine(userController.CurrentUser);
            Console.ReadLine();

        }

        private static DateTime ParseDateTime()
        {
            DateTime birthDate;
            while (true)
            {
                Console.WriteLine("Введiть дату народження користуваача(dd.MM.yyyy): ");
                // var birthDate = Console.ReadLine(); //TODO: переписати.
                if (DateTime.TryParse(Console.ReadLine(), out birthDate))
                {
                    break;
                }
                else
                {
                    Console.WriteLine("Неправильна дата народження");
                }
            }

            return birthDate;
        }

        private static double ParseDouble(string name)
        {

            while (true)
            {

                Console.WriteLine($"Введiть {name}: ");
                if (double.TryParse(Console.ReadLine(), out double value))
                {
                    return value;
                }
                else
                {
                    Console.WriteLine($"Неправильний {name}: ");
                }
            }

        }
    }
}
