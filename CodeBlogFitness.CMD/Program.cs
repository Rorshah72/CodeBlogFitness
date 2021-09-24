using CodeBlogFitness.BL.Controller;
using CodeBlogFitness.BL.Model;
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
            var eatingController = new EatingController(userController.CurrentUser);
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
            Console.WriteLine("Виберiть дiю: ");
            Console.WriteLine("E - Ввести прийом їжi.");
            var key =  Console.ReadKey();
            Console.WriteLine();
            if(key.Key == ConsoleKey.E)
            {
                var foods = EnterEating();
                eatingController.Add(foods.Food, foods.Weight);

                foreach(var item in eatingController.Eating.Foods)
                {
                    Console.WriteLine(item);
                    Console.WriteLine($"\t {item.Key} - {item.Value}");
                    
                }
            }

            Console.ReadLine();

        }

        private static (Food Food, double Weight) EnterEating()
        {
            Console.Write("Виберiть назву продутку: ");
            var food = Console.ReadLine();
            var proteins = ParseDouble("kiлькiсть бiлкiв на сто грам");
            var fats = ParseDouble("kiлькiсть жирiв на сто грам");
            var carbohydrates = ParseDouble("kiлькiсть вуглеводiв на сто грам");
            var callories = ParseDouble("kiлькiсть калорiй на сто грам");
            
            var product = new Food(food,proteins,fats,carbohydrates,callories);
            var weight = ParseDouble("Вагу порцiї в грамах: ");

            return (Food: product,Weight: weight);
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
