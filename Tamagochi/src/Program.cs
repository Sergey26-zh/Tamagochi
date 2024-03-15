using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tamagochi.src
{
    class Program
    {
        public static void Main(string[] args)
        {
            Console.WriteLine("Добро пожаловать в игру Тамагочи!");
            Console.Write("Введите имя питомца: ");
            string petName = Console.ReadLine();

            Pet pet = new Pet(petName);

            while (pet.isAlive)
            {
                Console.WriteLine("\nВыберите действие:");
                Console.WriteLine("1. Покормить");
                Console.WriteLine("2. Поиграть");
                Console.WriteLine("3. Укладывать спать");
                Console.WriteLine("4. Посмотреть показатели");
                Console.WriteLine("5. Выйти из игры");

                Console.Write("Ваш выбор: ");
                string choice = Console.ReadLine();

                switch (choice)
                {
                    case "1":
                        pet.Feed();
                        break;
                    case "2":
                        pet.Play();
                        break;
                    case "3":
                        pet.Sleep();
                        break;
                    case "4":
                        Console.WriteLine("\nПоказатели питомца:");
                        Console.WriteLine("Имя:"  + pet.name);
                        Console.WriteLine($"Уровень здоровья: {pet.healthPoints}");
                        Console.WriteLine($"Уровень голода: {pet.hungerLvl}");
                        Console.WriteLine($"Уровень усталости: { pet.fatigueLvl}");
                        break;
                    case "5":
                        Console.WriteLine("Выход из игры.");
                        return;
                    default:
                        Console.WriteLine("Некорректный ввод.");
                        break;
                }
            }

            Console.WriteLine("Игра окончена. Питомец заболел.");
        }
    }
}
