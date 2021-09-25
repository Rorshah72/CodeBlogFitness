using CodeBlogFitness.BL.Controller;
using CodeBlogFitness.BL.Model;
using System;
using System.Globalization;
using System.Resources;

namespace CodeBlogFitness.CMD
{
    class Program
    {


        static void Main(string[] args)
        {
            var culture = CultureInfo.CreateSpecificCulture("ua-ua");
            var resourceManager = new ResourceManager("CodeBlogFitness.CMD.Languages.Messages", typeof(Program).Assembly);

            Console.WriteLine(resourceManager.GetString("Hello"), culture);
            Console.WriteLine(resourceManager.GetString("EnterName"), culture);
            var name = Console.ReadLine();

            var userController = new UserController(name);
            var eatingController = new EatingController(userController.CurrentUser);
            var exerciseController = new ExerciseController(userController.CurrentUser);
            if (userController.IsNewUser)
            {
                Console.WriteLine(resourceManager.GetString("EnterGender"), culture);
                var gender = Console.ReadLine();
                var birthDate = ParseDateTime("народження (ДД.ММ.РРРР): ");
                var weight = ParseDouble("вага");
                var height = ParseDouble("рiст");

                userController.SetNewUserData(gender, birthDate, weight, height);
            }

            Console.WriteLine(userController.CurrentUser);


            while (true)
            {
                Console.WriteLine("Виберiть дiю: ");
                Console.WriteLine("E - Ввести прийом їжi.");
                Console.WriteLine("A - Вказати розминку.");
                Console.WriteLine("Q - Вихiд.");
                var key = Console.ReadKey();
                Console.WriteLine();

                switch (key.Key)
                {
                    case ConsoleKey.E:
                        var foods = EnterEating();
                        eatingController.Add(foods.Food, foods.Weight);

                        foreach (var item in eatingController.Eating.Foods)
                        {
                            // Console.WriteLine(item);
                            Console.WriteLine($"\t {item.Key} - {item.Value}");

                        }
                        break;
                    case ConsoleKey.A:
                        var act = EnterExercise();
                        exerciseController.Add(act.Activity, act.Begin, act.End);

                        foreach (var item in exerciseController.Exercises)
                        {
                            // Console.WriteLine(item);
                            Console.WriteLine($"\t {item.Activity} розминка тривала - з {item.Start.ToShortTimeString()}  по  {item.Finish.ToShortTimeString()}");

                        }

                        break;
                    case ConsoleKey.Q:
                        Environment.Exit(0);
                        break;
                    default:

                        break;
                }

                Console.ReadLine();
            }




        }


        private static (Activity Activity, DateTime Begin, DateTime End) EnterExercise()
        {
            Console.Write("Виберiть назву вправи: ");
            var name = Console.ReadLine();
            var energy = ParseDouble("Розхiд калорiй на хвилину пiд час розминки: ");
            var activity = new Activity(name, energy);

            var begin = ParseDateTime("початку розмини: ");
            var end = ParseDateTime("кiнця розминки: ");

            return (Activity: activity, Begin: begin, End: end);
        }

        private static (Food Food, double Weight) EnterEating()
        {
            Console.Write("Виберiть назву продутку: ");
            var food = Console.ReadLine();
            var proteins = ParseDouble("kiлькiсть бiлкiв на сто грам");
            var fats = ParseDouble("kiлькiсть жирiв на сто грам");
            var carbohydrates = ParseDouble("kiлькiсть вуглеводiв на сто грам");
            var callories = ParseDouble("kiлькiсть калорiй на сто грам");

            var product = new Food(food, proteins, fats, carbohydrates, callories);
            var weight = ParseDouble("Вагу порцiї в грамах: ");

            return (Food: product, Weight: weight);
        }

        private static DateTime ParseDateTime(string name)
        {
            DateTime birthDate;
            while (true)
            {
                Console.WriteLine($"Введiть дату {name} ");
                // var birthDate = Console.ReadLine(); //TODO: переписати.
                if (DateTime.TryParse(Console.ReadLine(), out birthDate))
                {
                    break;
                }
                else
                {
                    Console.WriteLine($"Неправильна дата {name}");
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
