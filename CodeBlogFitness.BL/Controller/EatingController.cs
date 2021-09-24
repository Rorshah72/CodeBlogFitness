﻿using CodeBlogFitness.BL.Model;
using System;
using System.Collections.Generic;
using System.Linq;


namespace CodeBlogFitness.BL.Controller
{
    /// <summary>
    /// Контролер прийому їжi.
    /// </summary>
    public class EatingController : ControllerBase
    {
        private const string FOODS_FILE_NAME = "foods.dat";
        private const string EATINGS_FILE_NAME = "eatings.dat";

        /// <summary>
        /// Авторизований користувач.
        /// </summary>
        private readonly User user;

        /// <summary>
        /// Католог продуктiв.
        /// </summary>
        public List<Food> Foods { get; }

        /// <summary>
        /// Журнал прийому їжi.
        /// </summary>
        public Eating Eating { get; }

        /// <summary>
        /// Авторизацiя користувача.
        /// </summary>
        /// <param name="user">Користувач додатку.</param>
        public EatingController(User user)
        {
            this.user = user ?? throw new ArgumentNullException("Користувач не може бути пустим.", nameof(user));
            Foods = GetAllFoods();
            Eating = GetEating();
        }

        /// <summary>
        /// Добавлє продукт до журналу прйому їжi.
        /// </summary>
        /// <param name="foodName">Назва продукту.</param>
        /// <param name="weight">Вага продукту.</param>
        public void Add(Food food, double weight)
        {
            var product = Foods.SingleOrDefault(f => f.Name == food.Name);

            if (product == null)
            {
                Foods.Add(food);
                Eating.Add(food, weight);
                Save();
            }
            else
            {
                Eating.Add(product, weight);
                Save();
            }


        }
               
        /// <summary>
        /// Получення журналу прийому їжi.
        /// </summary>
        /// <returns>журнал прийому їжi.</returns>
        private Eating GetEating()
        {
            return Load<Eating>(EATINGS_FILE_NAME) ?? new Eating(user);
        }

        /// <summary>
        /// Получення каталогу продуктiв.
        /// </summary>
        /// <returns>Каталог продуктiв</returns>
        private List<Food> GetAllFoods()
        {
            return Load<List<Food>>(FOODS_FILE_NAME) ?? new List<Food>();

        }

        /// <summary>
        /// Збереження каталогу  та журналу прийому продуктiв.
        /// </summary>
        private void Save()
        {
            Save(FOODS_FILE_NAME, Foods);
            Save(EATINGS_FILE_NAME, Eating);
        }
    }
}
